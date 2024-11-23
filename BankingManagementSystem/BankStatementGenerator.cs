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
        Decimal totalDebit=0;
        Decimal totalCredit=0;
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
                        decimal closingBalance = Convert.ToDecimal(reader["ACCOUNT_BALANCE"]); 
                        DateTime dateOpened = Convert.ToDateTime(reader["DATE_OPENED"]);

                        PdfDocument pdfDoc = new PdfDocument();
                        PdfPage page = pdfDoc.AddPage();
                        XGraphics gfx = XGraphics.FromPdfPage(page);
                        XFont font = new XFont("Arial", 12);
                        XFont Boldfont = new XFont("Arial", 12, XFontStyleEx.Bold);
                        double x = 40;
                        double y = 40;

                        string imagePath = @"C:\Users\Dell\source\repos\BankingManagementSystem\BankingManagementSystem\Resources\askari-bank-seeklogo.png";
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

                      
                        gfx.DrawString("Transaction History", Boldfont, XBrushes.Black, x, y);
                        y += 20;
                        gfx.DrawString("Date", font, XBrushes.Black, x, y);
                        gfx.DrawString("Description", font, XBrushes.Black, x + 100, y);
                        gfx.DrawString("Amount", font, XBrushes.Black, x + 343, y);
                        gfx.DrawString("Balance", font, XBrushes.Black, x + 443, y);
                        y += 20;

                        gfx.DrawLine(XPens.Black, x - 7, y - 14, x + 512, y - 14);

                        decimal runningBalance = 0; 
                        decimal openingBalance = closingBalance;

                        string transactionQuery = @"SELECT TRANSACTION_DATE, DESCRIPTION, AMOUNT, TRANSACTION_TYPE
                                                FROM TRANSACTION
                                                WHERE ACCOUNT_ID = :AccountID
                                                ORDER BY TRANSACTION_DATE ASC";

                        using (var transactionCommand = new OracleCommand(transactionQuery, connection))
                        {
                            transactionCommand.Parameters.Add(new OracleParameter("AccountID", accountId));

                            using (var transactionReader = transactionCommand.ExecuteReader())
                            {
                                while (transactionReader.Read())
                                {
                                    DateTime transactionDate = Convert.ToDateTime(transactionReader["TRANSACTION_DATE"]);
                                    string description = transactionReader["DESCRIPTION"].ToString();
                                    decimal amount = Convert.ToDecimal(transactionReader["AMOUNT"]);
                                    string transactionType = transactionReader["TRANSACTION_TYPE"].ToString().ToLower().Trim();

                                  
                                    gfx.DrawString(transactionDate.ToString("yyyy-MM-dd"), font, XBrushes.Black, x, y);
                                    gfx.DrawString(description, font, XBrushes.Black, x + 100, y);

                                   
                                    if (transactionType == "credit")
                                    {
                                        runningBalance += amount;
                                        totalCredit += amount;
                                    }
                                    else if (transactionType == "debit")
                                    {
                                        runningBalance -= amount; 
                                        totalDebit += amount;
                                    }

                                    XBrush amountBrush = transactionType == "credit" ? XBrushes.Green : XBrushes.Red;

                                    gfx.DrawString((transactionType == "debit" ? "-" : "") + amount.ToString("C"), font, amountBrush, x + 343, y);
                                    gfx.DrawString(runningBalance.ToString("C"), font, XBrushes.Black, x + 443, y);

                                    gfx.DrawLine(XPens.Gray, x - 7, y + 5, x + 512, y + 5);

                                    gfx.DrawLine(XPens.Gray, x - 7, y - 15, x - 7, y + 5);
                                    gfx.DrawLine(XPens.Gray, x + 93, y - 15, x + 93, y + 5);
                                    gfx.DrawLine(XPens.Gray, x + 340, y - 15, x + 340, y + 5);
                                    gfx.DrawLine(XPens.Gray, x + 441, y - 15, x + 441, y + 5);
                                    gfx.DrawLine(XPens.Gray, x + 512, y - 15, x + 512, y + 5);
                                    gfx.DrawLine(XPens.Black, x - 7, y + 5, x + 512, y + 5);


                                    y += 20;
                                }

                            
                            }
                        }
                        openingBalance = ((closingBalance-totalCredit) + totalDebit);
                       
                        y += 20;
                        gfx.DrawString("Summary", Boldfont, XBrushes.Black, x, y);
                        y += 20;
                        gfx.DrawString($"Opening Balance: {openingBalance:C}", font, XBrushes.Black, x, y); 
                        
                        gfx.DrawString($"Total Credits: {totalCredit:C}", font, XBrushes.Green, x, y + 20);
                        y += 20;
                        
                        gfx.DrawString($"Total Debits: {totalDebit:C}", font, XBrushes.Red, x, y + 20);
                        y += 20;
                        gfx.DrawString($"Closing Balance: {closingBalance:C}", font, XBrushes.Black, x, y + 20); 



                        y = page.Height - 40;

                        XFont footerFont = new XFont("Arial", 8);

                        string footerLine1 = "This is a computer-generated account statement for the purpose of the semester project.";
                        string footerLine2 = "It may contain errors or omissions. For inquiries or feedback, please contact: AskariDigitalOTP@gmail.com.";

                        gfx.DrawString(footerLine1, footerFont, XBrushes.Black, x, y);

                        y += footerFont.GetHeight();

                        gfx.DrawString(footerLine2, footerFont, XBrushes.Black, x, y);

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
        string messageBody = "Please find the Account statement for you account.";
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
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("AskariDigitalOTP@gmail.com", "mitxehwlyexurspx")
            };
            smtpClient.Send(message);
       
            MessageBox.Show("Email with attachment sent successfully!");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to send email: {ex.Message}");
        }


    }
}


