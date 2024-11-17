using System;
using System.Data;
using System.IO;
using Oracle.ManagedDataAccess.Client;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Windows.Forms;
using BankingManagementSystem;

public class BankStatementGenerator
{
    public void GenerateStatementPDF()
    {
        string directoryPath = @"C:\Users\Dell\Desktop\Hassan University\5th Semester\Database systems\AccountStatements"; // Changed path
        string fileName = Path.Combine(directoryPath, "AccountStatement"+GlobalData.CurrentCustomer.customerId+".pdf");

        try
        {
            // Ensure that the file path is valid and accessible
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("File name is invalid.");
                return;
            }

            // Check if the directory exists, and create it if it doesn't
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (var connection = new OracleConnection(GlobalData.connString))
            {
                connection.Open();

                // Step 1: Retrieve Customer and Account Information
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

                        // Extract customer and account information
                        string customerName = reader["NAME"].ToString();
                        string address = reader["ADDRESS"].ToString();
                        string contactNumber = reader["CONTACT_NUMBER"].ToString();
                        string accountId = reader["ACCOUNT_ID"].ToString();
                        decimal openingBalance = Convert.ToDecimal(reader["ACCOUNT_BALANCE"]);
                        DateTime dateOpened = Convert.ToDateTime(reader["DATE_OPENED"]);

                        // Initialize PDF document
                        PdfDocument pdfDoc = new PdfDocument();
                        PdfPage page = pdfDoc.AddPage();
                        XGraphics gfx = XGraphics.FromPdfPage(page);
                        XFont font = new XFont("Arial", 12);

                        // Set starting position for text
                        double x = 40;
                        double y = 40;

                        // Add customer and account details to PDF
                        gfx.DrawString("Account Statement", font, XBrushes.Black, x, y);
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

                        // Add table for transaction history
                        gfx.DrawString("Date", font, XBrushes.Black, x, y);
                        gfx.DrawString("Description", font, XBrushes.Black, x + 100, y);
                        gfx.DrawString("Amount", font, XBrushes.Black, x + 350, y); // Adjusted position
                        gfx.DrawString("Balance", font, XBrushes.Black, x + 450, y); // Adjusted position
                        y += 20;

                        decimal runningBalance = openingBalance;
                        gfx.DrawString("Opening Balance", font, XBrushes.Black, x, y);
                        gfx.DrawString("", font, XBrushes.Black, x + 100, y);
                        gfx.DrawString("", font, XBrushes.Black, x + 350, y);
                        gfx.DrawString(runningBalance.ToString("C"), font, XBrushes.Black, x + 450, y); // Adjusted position
                        y += 20;

                        // Step 2: Retrieve and Process Transaction History
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

                                    gfx.DrawString(transactionDate.ToString("yyyy-MM-dd"), font, XBrushes.Black, x, y);
                                    gfx.DrawString(description, font, XBrushes.Black, x + 100, y);
                                    gfx.DrawString((transactionType == "debit" ? "-" : "") + amount.ToString("C"), font, XBrushes.Black, x + 350, y); // Adjusted position
                                    gfx.DrawString(runningBalance.ToString("C"), font, XBrushes.Black, x + 450, y); // Adjusted position
                                    y += 20;
                                }
                            }

                            // Step 3: Summary Section
                            y += 20;
                            gfx.DrawString("Summary", font, XBrushes.Black, x, y);
                            y += 20;
                            gfx.DrawString($"Total Credits: {totalCredits:C}", font, XBrushes.Black, x, y);
                            y += 20;
                            gfx.DrawString($"Total Debits: {totalDebits:C}", font, XBrushes.Black, x, y);
                            y += 20;
                            gfx.DrawString($"Closing Balance: {runningBalance:C}", font, XBrushes.Black, x, y);
                        }

                        // Save the PDF document
                        pdfDoc.Save(fileName);
                        MessageBox.Show("PDF generated successfully!");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error in database connection: {ex.Message}");
        }
    }
}
