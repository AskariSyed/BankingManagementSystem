using System;
using System.Data;
using System.IO;
using Oracle.ManagedDataAccess.Client;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Windows.Forms;
using BankingManagementSystem;
using System.Net.Mail;
using System.Net;

public class BankStatementGenerator
{
    public void GenerateStatementPDF()
    {
        string directoryPath = @"C:\Users\Dell\Desktop\Hassan University\5th Semester\Database systems\AccountStatements";
        string fileName = Path.Combine(directoryPath, "AccountStatement" + GlobalData.CurrentCustomer.customerId + "_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf");

        try
        {
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("File name is invalid.");
                return;
            }

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (var connection = new OracleConnection(GlobalData.connString))
            {
                connection.Open();

                string customerQuery = @"SELECT c.NAME, c.ADDRESS, c.CONTACT_NUMBER, a.ACCOUNT_ID, 
                                         a.ACCOUNT_BALANCE, a.DATE_OPENED
                                         FROM CUSTOMERS c
                                         JOIN ACCOUNT a ON c.CUSTOMER_ID = a.CUSTOMER_ID
                                         WHERE c.CUSTOMER_ID = :CustomerID";

                using (var customerCommand = new OracleCommand(customerQuery, connection))
                {
                    customerCommand.Parameters.Add(new OracleParameter("CustomerID", GlobalData.CurrentCustomer.customerId));

                    using (var reader = customerCommand.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Customer not found.");
                            return;
                        }

                        string customerName = reader["NAME"].ToString();
                        string address = reader["ADDRESS"].ToString();
                        string contactNumber = reader["CONTACT_NUMBER"].ToString();
                        string accountId = reader["ACCOUNT_ID"].ToString();
                        decimal openingBalance = Convert.ToDecimal(reader["ACCOUNT_BALANCE"]);
                        DateTime dateOpened = Convert.ToDateTime(reader["DATE_OPENED"]);

                        PdfDocument pdfDoc = new PdfDocument();
                        PdfPage page = pdfDoc.AddPage();
                        XGraphics gfx = XGraphics.FromPdfPage(page);
                        XFont font = new XFont("Arial", 12);
                        XFont Boldfont = new XFont("Arial", 12, XFontStyleEx.Bold);
                        double x = 40;
                        double y = 40;

                        string imagePath = @"C:\Users\Dell\source\repos\BankingManagementSystem\BankingManagementSystem\Resources\askari-bank-seeklogo.png"; // Set your image path
                        XImage backgroundImage = XImage.FromFile(imagePath);

                        double imageWidth = backgroundImage.PixelWidth;
                        double imageHeight = backgroundImage.PixelHeight;

                        double aspectRatio = imageWidth / imageHeight;

                        double scaledWidth = page.Width;
                        double scaledHeight = scaledWidth / aspectRatio;

                        if (scaledHeight > page.Height)
                        {
                            scaledHeight = page.Height;
                            scaledWidth = scaledHeight * aspectRatio;
                        }

                        double xOffset = (page.Width - scaledWidth) / 2;  
                        double yOffset = (page.Height - scaledHeight) / 2;  
                        gfx.DrawImage(backgroundImage, xOffset, yOffset, scaledWidth, scaledHeight);

                        XBrush semiTransparentBrush = new XSolidBrush(XColor.FromArgb(100, 255, 255, 255)); 
                        gfx.DrawRectangle(semiTransparentBrush, 0, 0, page.Width, page.Height);

                        XBrush semiTransparentBrush2 = new XSolidBrush(XColor.FromArgb(100, 255, 255, 255)); 
                        gfx.DrawRectangle(semiTransparentBrush2, 0, 0, page.Width, page.Height);
                        // Header Info
                        gfx.DrawString("Account Statement", Boldfont, XBrushes.Black, x, y);
                        y += 20;
                        gfx.DrawString($"Customer Name: {customerName}", font, XBrushes.Black, x, y);
                        y += 20;
                        gfx.DrawString($"Address: {address}", font, XBrushes.Black, x, y);
                        y += 20;
                        gfx.DrawString($"Contact Number: {contactNumber}", font, XBrushes.Black, x, y);
                        y += 20;
                        gfx.DrawString($"Account ID: {accountId}", font, XBrushes.Black, x, y);
                        y += 20;
                        gfx.DrawString($"Date Opened: {dateOpened:yyyy-MM-dd}", font, XBrushes.Black, x, y);
                        y += 40;

                        // Table Header
                        gfx.DrawString("Transaction History", Boldfont, XBrushes.Black, x, y);
                        y += 20;
                        gfx.DrawString("Date", font, XBrushes.Black, x, y);
                        gfx.DrawString("Description", font, XBrushes.Black, x + 100, y);
                        gfx.DrawString("Amount", font, XBrushes.Black, x + 343, y); 
                        gfx.DrawString("Balance", font, XBrushes.Black, x + 443, y);
                        y += 20;

                        gfx.DrawLine(XPens.Black, x - 7, y - 14, x + 512, y - 14);

                        decimal runningBalance = openingBalance;
                        string transactionQuery = @"SELECT TRANSACTION_DATE, DESCRIPTION, AMOUNT, TRANSACTION_TYPE
                                                    FROM TRANSACTION
                                                    WHERE ACCOUNT_ID = :AccountID
                                                    ORDER BY TRANSACTION_DATE";

                        using (var transactionCommand = new OracleCommand(transactionQuery, connection))
                        {
                            transactionCommand.Parameters.Add(new OracleParameter("AccountID", accountId));
                            decimal totalCredits = 0;
                            decimal totalDebits = 0;

                            using (var transactionReader = transactionCommand.ExecuteReader())
                            {
                                while (transactionReader.Read())
                                {
                                    DateTime transactionDate = Convert.ToDateTime(transactionReader["TRANSACTION_DATE"]);
                                    string description = transactionReader["DESCRIPTION"].ToString();
                                    decimal amount = Convert.ToDecimal(transactionReader["AMOUNT"]);
                                    string transactionType = transactionReader["TRANSACTION_TYPE"].ToString().ToLower();

                                    if (transactionType == "credit")
                                    {
                                        runningBalance += amount;
                                        totalCredits += amount;
                                    }
                                    else if (transactionType == "debit")
                                    {
                                        runningBalance -= amount;
                                        totalDebits += amount;
                                    }

                                    XBrush amountBrush = transactionType == "credit" ? XBrushes.Green : XBrushes.Red;

                                    gfx.DrawString(transactionDate.ToString("yyyy-MM-dd"), font, XBrushes.Black, x, y);
                                    gfx.DrawString(description, font, XBrushes.Black, x + 100, y);
                                    gfx.DrawString((transactionType == "debit" ? "-" : "") + amount.ToString("C"), font, amountBrush, x + 343, y);
                                    gfx.DrawString(runningBalance.ToString("C"), font, XBrushes.Black, x + 443, y); 

                                    gfx.DrawLine(XPens.Gray, x - 7, y - 15, x - 7, y + 5); 
                                    gfx.DrawLine(XPens.Gray, x + 93, y - 15, x + 93, y + 5); 
                                    gfx.DrawLine(XPens.Gray, x + 340, y - 15, x + 340, y + 5); 
                                    gfx.DrawLine(XPens.Gray, x + 441, y - 15, x + 441, y + 5); 
                                    gfx.DrawLine(XPens.Gray, x + 512, y - 15, x + 512, y + 5); 
                                     gfx.DrawLine(XPens.Black, x - 7, y + 5, x + 512, y +5);



                                    y += 20;
                                }
                            }

                            y += 20;
                            gfx.DrawString("Summary", Boldfont, XBrushes.Black, x, y);
                            y += 20;
                            gfx.DrawString($"Total Credits: {totalCredits:C}", font, XBrushes.Black, x, y);
                            y += 20;
                            gfx.DrawString($"Total Debits: {totalDebits:C}", font, XBrushes.Black, x, y);
                            y += 20;
                            gfx.DrawString($"Closing Balance: {runningBalance:C}", font, XBrushes.Black, x, y);
                        }

                        pdfDoc.Save(fileName);
                        MessageBox.Show("PDF generated successfully!");
                        sendPdfToEmail(GlobalData.CurrentCustomer.email, fileName);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error in database connection: {ex.Message}");
        }
    }



    public void sendPdfToEmail(string recipientEmail,string filePath)
    {
      
        // Email message body
        string messageBody = "Please find the Account statement for you account.";

        // Set up the email
        MailMessage message = new MailMessage
        {
            From = new MailAddress("AskariDigitalOTP@gmail.com", "Askari Digital Bank Ltd."),
            Subject = "Account Statement",
            Body = messageBody
        };

        try
        {   message.To.Add(recipientEmail);
            if (!string.IsNullOrEmpty(filePath))
            {
                Attachment attachment = new Attachment(filePath);
                message.Attachments.Add(attachment);
            }

            // Configure SMTP client
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("AskariDigitalOTP@gmail.com", "mitxehwlyexurspx")
            };

            // Send email
            smtpClient.Send(message);

            // Restore the cursor and show success message
       
            MessageBox.Show("Email with attachment sent successfully!");
        }
        catch (Exception ex)
        {
            // Restore the cursor and show error message

            MessageBox.Show($"Failed to send email: {ex.Message}");
        }


    }
}


