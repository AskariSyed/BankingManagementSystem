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
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using PdfSharp.Snippets.Drawing;


public class BankStatementGenerator
{
    public static void GenerateStatementPDFFull()
    {
        string directoryPath = @"C:\Users\Dell\Desktop\Hassan University\5th Semester\Database systems\AccountStatements";
        string fileName = Path.Combine(directoryPath, "AccountStatement" + GlobalData.CurrentCustomer.customerId + "_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf");
        decimal totalDebit = 0;
        decimal totalCredit = 0;
        decimal runningBalance = 0; 

        try
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            using (var connection = new OracleConnection(GlobalData.connString))
            {
                connection.Open();

               
                string customerQuery = @"SELECT c.NAME, c.ADDRESS, c.CONTACT_NUMBER, a.ACCOUNT_ID, a.ACCOUNT_BALANCE, a.DATE_OPENED
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


                      
                        decimal openingBalance = closingBalance;

                        Document document = new Document();
                        Section section = document.AddSection();

                       
                        HeaderFooter header = section.Headers.Primary;
                        Paragraph para = header.AddParagraph();
                        para.Format.Alignment = ParagraphAlignment.Center;
                        Image image = para.AddImage(@"C:\Users\Dell\source\repos\BankingManagementSystem\BankingManagementSystem\Resources\New-Logo-1.png");
                        image.Width = Unit.FromCentimeter(8); 
                        

                        
                        HeaderFooter evenHeader = section.Headers.EvenPage;
                        Paragraph evenPara = evenHeader.AddParagraph();
                        evenPara.Format.Alignment = ParagraphAlignment.Center;
                        Image evenImage = evenPara.AddImage(@"C:\Users\Dell\source\repos\BankingManagementSystem\BankingManagementSystem\Resources\New-Logo-1.png");
                        evenImage.Width = Unit.FromCentimeter(8);
                        header.Format.SpaceAfter=Unit.FromInch(1);
                        evenHeader.Format.SpaceAfter = Unit.FromInch(1);
                        section.PageSetup.HeaderDistance = Unit.FromCentimeter(50); 


                        HeaderFooter footer = section.Footers.Primary;

                        section.PageSetup.TopMargin = Unit.FromCentimeter(3.5); // Adjust as needed
                        section.PageSetup.BottomMargin = Unit.FromCentimeter(3.5); // Adjust as needed

                        Paragraph paraFooter = footer.AddParagraph();
                        paraFooter.AddText("This is a computer-generated account statement for the purpose of the semester project. It may contain errors or omissions. For inquiries or feedback, please contact: AskariDigitalOTP@gmail.com.");

                        
                        paraFooter.Format.Alignment = ParagraphAlignment.Center;
                        paraFooter.Format.Font.Size = 8;
                        paraFooter.Format.SpaceBefore = Unit.FromPoint(20);



                        section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Portrait;
                        section.PageSetup.PageFormat = PageFormat.A4;

                       
                        section.PageSetup.HeaderDistance = -3;


                        var blankLine = section.AddParagraph();
                        blankLine.AddFormattedText("   ",TextFormat.Bold);
                        blankLine.Format.Font.Size = 10;



                       
                        var issuingDate = section.AddParagraph();
                        issuingDate.AddFormattedText("Issuing Date: ", TextFormat.Bold);
                        issuingDate.AddText("\t\t"+DateTime.Now.ToString("yyyy-MM-dd"));
                        issuingDate.Format.Font.Size = 10;
                        
                        var customerInfo = section.AddParagraph();
                        customerInfo.AddFormattedText("Customer Name: ", TextFormat.Bold);
                        customerInfo.AddText("\t"+customerName + "\n");

                        customerInfo.AddFormattedText("Address: ", TextFormat.Bold);
                        customerInfo.AddText("\t\t" + address + "\n");

                        customerInfo.AddFormattedText("Contact Number: ", TextFormat.Bold);
                        customerInfo.AddText("\t" + contactNumber + "\n");

                        customerInfo.AddFormattedText("Account ID: ", TextFormat.Bold);
                        customerInfo.AddText("\t\t" + accountId + "\n");

                        customerInfo.AddFormattedText("Date Opened: ", TextFormat.Bold);
                        customerInfo.AddText("\t\t" + dateOpened.ToString("yyyy-MM-dd"));

                        customerInfo.Format.SpaceAfter = Unit.FromPoint(20);

                        
                        Table table = section.AddTable();
                        table.Borders.Width = 0.75;
                        table.AddColumn(Unit.FromCentimeter(3));  
                        table.AddColumn(Unit.FromCentimeter(7));  
                        table.AddColumn(Unit.FromCentimeter(3));  
                        table.AddColumn(Unit.FromCentimeter(3));  

                        
                        Row row = table.AddRow();
                        row.Cells[0].AddParagraph("Date").Format.Alignment = ParagraphAlignment.Center;
                        row.Cells[1].AddParagraph("Description").Format.Alignment = ParagraphAlignment.Center;
                        row.Cells[2].AddParagraph("Amount").Format.Alignment = ParagraphAlignment.Center;
                        row.Cells[3].AddParagraph("Balance").Format.Alignment = ParagraphAlignment.Center;

                        row.Cells[0].Shading.Color = new MigraDoc.DocumentObjectModel.Color(255, 191, 0);
                        row.Cells[1].Shading.Color = new MigraDoc.DocumentObjectModel.Color(255, 191, 0);
                        row.Cells[2].Shading.Color = new MigraDoc.DocumentObjectModel.Color(255, 191, 0);
                        row.Cells[3].Shading.Color = new MigraDoc.DocumentObjectModel.Color(255, 191, 0);

                       
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

                                   
                                    row = table.AddRow();
                                    row.Cells[0].AddParagraph(transactionDate.ToString("yyyy-MM-dd")).Format.Alignment = ParagraphAlignment.Center;
                                    row.Cells[1].AddParagraph(description).Format.Alignment = ParagraphAlignment.Left;

                                    var amountParagraph = row.Cells[2].AddParagraph();
                                    amountParagraph.Format.Alignment = ParagraphAlignment.Center;
                                    amountParagraph.AddFormattedText((transactionType == "credit" ? "" : "-") + amount.ToString("C"));
                                    amountParagraph.Format.Font.Color = (transactionType == "credit") ? Colors.Green : Colors.Red;

                                    row.Cells[3].AddParagraph(runningBalance.ToString("C")).Format.Alignment = ParagraphAlignment.Center;
                                }
                            }
                        }

                      
                        openingBalance = ((closingBalance - totalCredit) + totalDebit);
                        var summary = section.AddParagraph();
                        summary.Format.SpaceBefore = "20pt";

                      
                        summary.Format.TabStops.AddTabStop(110, MigraDoc.DocumentObjectModel.TabAlignment.Left);

                      
                        summary.AddFormattedText("Opening Balance: ", TextFormat.Bold);
                        summary.AddFormattedText("\t", TextFormat.NotBold);
                        summary.AddFormattedText($"{openingBalance:C}", TextFormat.NotBold);

                      
                        summary.AddFormattedText("\nTotal Credits: ", TextFormat.Bold);
                        summary.AddFormattedText("\t", TextFormat.NotBold);
                        var creditFormatted = summary.AddFormattedText($"{totalCredit:C}", TextFormat.NotBold);
                        creditFormatted.Font.Color = Colors.Green;

                      
                        summary.AddFormattedText("\nTotal Debits: ", TextFormat.Bold);
                        summary.AddFormattedText("\t", TextFormat.NotBold);
                        var debitFormatted = summary.AddFormattedText($"{totalDebit:C}", TextFormat.NotBold);
                        debitFormatted.Font.Color = Colors.Red;

                      
                        summary.AddFormattedText("\nClosing Balance: ", TextFormat.Bold);
                        summary.AddFormattedText("\t", TextFormat.NotBold);
                        summary.AddFormattedText($"{runningBalance:C}", TextFormat.NotBold);
                      
                        PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
                        renderer.Document = document;
                        renderer.RenderDocument();
                        renderer.PdfDocument.Save(fileName);

                        MessageBox.Show("PDF generated successfully!");

                        sendPdfToEmail(GlobalData.CurrentCustomer.email, fileName);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error in generating PDF please see logs file for more info");
            GlobalData.LogError("Error in generating PDF", ex);
        }
    }


    
public static void  GenerateAccountStatementRange(DateTimePicker fromDatePicker, DateTimePicker toDatePicker)
{
    string directoryPath = @"C:\Users\Dell\Desktop\Hassan University\5th Semester\Database systems\AccountStatements";
        string fileName = Path.Combine(
            directoryPath,
            "AccountStatement"
            + GlobalData.CurrentCustomer.customerId + "_"
            + DateTime.Now.ToString("yyyyMMdd")
            + "_From_" + fromDatePicker.Text.Replace("/", "-")
            + "_To_" + toDatePicker.Text.Replace("/", "-")
            + ".pdf"
        );
        decimal totalDebit = 0;
    decimal totalCredit = 0;
    decimal runningBalance = 0;
        decimal openingBalance = 0;

    
    DateTime fromDate = fromDatePicker.Value.Date;
    DateTime toDate = toDatePicker.Value.Date.AddDays(1).AddTicks(-1); 

    try
    {
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        using (var connection = new OracleConnection(GlobalData.connString))
        {
            connection.Open();

            
            string customerQuery = @"SELECT c.NAME, c.ADDRESS, c.CONTACT_NUMBER, a.ACCOUNT_ID, a.ACCOUNT_BALANCE, a.DATE_OPENED
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



                       
                        string balanceQuery = @"SELECT NVL(SUM(CASE WHEN TRANSACTION_TYPE = 'Credit' THEN AMOUNT 
                                                              WHEN TRANSACTION_TYPE = 'Debit' THEN -AMOUNT 
                                                              ELSE 0 END), 0) AS BALANCE
                                            FROM TRANSACTION
                                            WHERE ACCOUNT_ID = :AccountID AND TRANSACTION_DATE < :FromDate";

                        using (var balanceCommand = new OracleCommand(balanceQuery, connection))
                        {
                            balanceCommand.Parameters.Add(new OracleParameter("AccountID", accountId));
                            balanceCommand.Parameters.Add(new OracleParameter("FromDate", fromDate));

                            openingBalance = Convert.ToDecimal(balanceCommand.ExecuteScalar());
                            runningBalance = openingBalance;  
                        }

                        Document document = new Document();
                    Section section = document.AddSection();
                        
                        HeaderFooter header = section.Headers.Primary;
                        Paragraph para = header.AddParagraph();
                        para.Format.Alignment = ParagraphAlignment.Center;
                        Image image = para.AddImage(@"C:\Users\Dell\source\repos\BankingManagementSystem\BankingManagementSystem\Resources\New-Logo-1.png");
                        image.Width = Unit.FromCentimeter(8); 
                        header.Format.SpaceAfter=Unit.FromCentimeter(8);

                        
                        HeaderFooter evenHeader = section.Headers.EvenPage;
                        
                        Paragraph evenPara = evenHeader.AddParagraph();
                        evenPara.Format.Alignment = ParagraphAlignment.Center;
                        Image evenImage = evenPara.AddImage(@"C:\Users\Dell\source\repos\BankingManagementSystem\BankingManagementSystem\Resources\New-Logo-1.png");
                        evenImage.Width = Unit.FromCentimeter(8);


                        HeaderFooter footer = section.Footers.Primary;
                        Paragraph paraFooter = footer.AddParagraph();
                        paraFooter.AddText("This is a computer-generated account statement for the purpose of the semester project. It may contain errors or omissions. For inquiries or feedback, please contact: AskariDigitalOTP@gmail.com.");
                        paraFooter.Format.Alignment = ParagraphAlignment.Center;
                        paraFooter.Format.Font.Size = 8;
                        paraFooter.Format.SpaceBefore = Unit.FromPoint(20);

                        section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Portrait;
                        section.PageSetup.PageFormat = PageFormat.A4;
                        section.PageSetup.HeaderDistance = -3;





                        
                        var issuingDate = section.AddParagraph();
                        issuingDate.Format.SpaceBefore += Unit.FromPoint(20);
                        issuingDate.AddFormattedText("Issuing Date: ", TextFormat.Bold);
                        issuingDate.AddText("\t\t" + DateTime.Now.ToString("yyyy-MM-dd"));
                        issuingDate.Format.Font.Size = 10;

                        section.PageSetup.TopMargin = Unit.FromCentimeter(3.5); 
                        section.PageSetup.BottomMargin = Unit.FromCentimeter(3.5); 

                        var customerInfo = section.AddParagraph();
                        customerInfo.AddFormattedText("Customer Name: ", TextFormat.Bold);
                        customerInfo.AddText("\t" + customerName + "\n");

                        customerInfo.AddFormattedText("Address: ", TextFormat.Bold);
                        customerInfo.AddText("\t\t" + address + "\n");

                        customerInfo.AddFormattedText("Contact Number: ", TextFormat.Bold);
                        customerInfo.AddText("\t" + contactNumber + "\n");

                        customerInfo.AddFormattedText("Account ID: ", TextFormat.Bold);
                        customerInfo.AddText("\t\t" + accountId + "\n");

                        customerInfo.AddFormattedText("Date Opened: ", TextFormat.Bold);
                        customerInfo.AddText("\t\t" + dateOpened.ToString("yyyy-MM-dd"));

                        customerInfo.Format.SpaceAfter = Unit.FromPoint(20);




                        Table table = section.AddTable();
                    table.Borders.Width = 0.75;
                    table.AddColumn(Unit.FromCentimeter(3));  
                    table.AddColumn(Unit.FromCentimeter(7));  
                    table.AddColumn(Unit.FromCentimeter(3));  
                    table.AddColumn(Unit.FromCentimeter(3));  

                    Row row = table.AddRow();
                    row.Cells[0].AddParagraph("Date").Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[1].AddParagraph("Description").Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[2].AddParagraph("Amount").Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[3].AddParagraph("Balance").Format.Alignment = ParagraphAlignment.Center;

                    
                    string transactionQuery = @"SELECT TRANSACTION_DATE, DESCRIPTION, AMOUNT, TRANSACTION_TYPE
                                                FROM TRANSACTION
                                                WHERE ACCOUNT_ID = :AccountID 
                                                AND TRANSACTION_DATE BETWEEN :FromDate AND :ToDate
                                                ORDER BY TRANSACTION_DATE ASC";

                    using (var transactionCommand = new OracleCommand(transactionQuery, connection))
                    {
                        transactionCommand.Parameters.Add(new OracleParameter("AccountID", accountId));
                        transactionCommand.Parameters.Add(new OracleParameter("FromDate", fromDate));
                        transactionCommand.Parameters.Add(new OracleParameter("ToDate", toDate));

                        using (var transactionReader = transactionCommand.ExecuteReader())
                        {
                            while (transactionReader.Read())
                            {
                                DateTime transactionDate = Convert.ToDateTime(transactionReader["TRANSACTION_DATE"]);
                                string description = transactionReader["DESCRIPTION"].ToString();
                                decimal amount = Convert.ToDecimal(transactionReader["AMOUNT"]);
                                string transactionType = transactionReader["TRANSACTION_TYPE"].ToString().ToLower().Trim();

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
                                row = table.AddRow();
                                row.Cells[0].AddParagraph(transactionDate.ToString("yyyy-MM-dd")).Format.Alignment = ParagraphAlignment.Center;
                                row.Cells[1].AddParagraph(description).Format.Alignment = ParagraphAlignment.Left;

                                var amountParagraph = row.Cells[2].AddParagraph();
                                amountParagraph.Format.Alignment = ParagraphAlignment.Center;
                                amountParagraph.AddFormattedText((transactionType == "credit" ? "" : "-") + amount.ToString("C"));
                                amountParagraph.Format.Font.Color = (transactionType == "credit") ? Colors.Green : Colors.Red;

                                row.Cells[3].AddParagraph(runningBalance.ToString("C")).Format.Alignment = ParagraphAlignment.Center;
                            }
                        }
                    }

                        
                        openingBalance = ((closingBalance - totalCredit) + totalDebit);
                        var summary = section.AddParagraph();
                        summary.Format.SpaceBefore = "20pt";

                        
                        summary.Format.TabStops.AddTabStop(110, MigraDoc.DocumentObjectModel.TabAlignment.Left);

                        
                        summary.AddFormattedText("Opening Balance: ", TextFormat.Bold);
                        summary.AddFormattedText("\t", TextFormat.NotBold);
                        summary.AddFormattedText($"{openingBalance:C}", TextFormat.NotBold);

                        
                        summary.AddFormattedText("\nTotal Credits: ", TextFormat.Bold);
                        summary.AddFormattedText("\t", TextFormat.NotBold);
                        var creditFormatted = summary.AddFormattedText($"{totalCredit:C}", TextFormat.NotBold);
                        creditFormatted.Font.Color = Colors.Green;

                        
                        summary.AddFormattedText("\nTotal Debits: ", TextFormat.Bold);
                        summary.AddFormattedText("\t", TextFormat.NotBold);
                        var debitFormatted = summary.AddFormattedText($"{totalDebit:C}", TextFormat.NotBold);
                        debitFormatted.Font.Color = Colors.Red;

                        
                        summary.AddFormattedText("\nClosing Balance: ", TextFormat.Bold);
                        summary.AddFormattedText("\t", TextFormat.NotBold);
                        summary.AddFormattedText($"{runningBalance:C}", TextFormat.NotBold);

                        PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
                    renderer.Document = document;
                    renderer.RenderDocument();
                    renderer.PdfDocument.Save(fileName);
                        

                        GlobalData.customizedPopup("PDF generated successfully!");
                    sendPdfToEmail(GlobalData.CurrentCustomer.email, fileName);
                }
            }
        }
    }
    catch (Exception ex)
    {
            MessageBox.Show($"Error in generating PDF please see logs file for more info");
            GlobalData.LogError("Error in generating PDF", ex);
        }
}


    public static void sendPdfToEmail(string recipientEmail,string filePath)
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
            GlobalData.customizedPopup("Email with attachment sent successfully!");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to send email please see logs file for more info");
            GlobalData.LogError("Failed to send Email", ex);
            
        }


    }
}


