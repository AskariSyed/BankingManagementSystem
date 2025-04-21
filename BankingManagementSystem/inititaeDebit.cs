using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace BankingManagementSystem
{
    public partial class inititaeDebit : Form
    {
        public inititaeDebit()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(initiateDebit_Paint);

        }

        private void initiateDebit_Paint(object sender, PaintEventArgs e)
        {
           
            int borderWidth = 5;
            Color borderColor = Color.FromArgb(255, 191, 0);
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void inititateButtonButton_Click(object sender, EventArgs e)
        {
            if (Int64.Parse(AmountTxtBox.Text) <= 0)
            {
                MessageBox.Show("Please Enter a valid Amount");
                return;
            }
            string receiverName = "";
            string recieverEmail = "";

            using (var connection = new OracleConnection(GlobalData.connString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM ACCOUNT WHERE ACCOUNT_ID = :accountId";
                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("accountId", CustomerAccountNotxtBox.Text.ToString()));

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        
                        
                        string balanceQuery = "SELECT ACCOUNT_BALANCE FROM ACCOUNT WHERE ACCOUNT_ID = :senderAccountId";

                        using (var balanceCommand = new OracleCommand(balanceQuery, connection))
                        {
                            balanceCommand.Parameters.Add(new OracleParameter("senderAccountId", CustomerAccountNotxtBox.Text.ToString()));

                            decimal senderBalance = Convert.ToDecimal(balanceCommand.ExecuteScalar());
                            if (senderBalance < Int64.Parse(AmountTxtBox.Text.ToString()))
                            {
                                MessageBox.Show("Insufficient Funds in Customer Account \n Current Balance : " + senderBalance);
                                return;
                            }
                        }


                        string customerQuery = "SELECT CUSTOMER_ID FROM ACCOUNT WHERE ACCOUNT_ID = :receiverAccountId";
                        int CustomerId = 0;

                        using (var customerCommand = new OracleCommand(customerQuery, connection))
                        {
                            customerCommand.Parameters.Add(new OracleParameter("receiverAccountId", CustomerAccountNotxtBox.Text.ToString()));
                            CustomerId = Convert.ToInt32(customerCommand.ExecuteScalar());
                        }
                        string recieverEmailQuery = "SELECT email FROM CUSTOMERS WHERE CUSTOMER_ID = :customerId";
                        using (var nameCommand = new OracleCommand(recieverEmailQuery, connection))
                        {
                            nameCommand.Parameters.Add(new OracleParameter("customerId", CustomerId));
                            recieverEmail = Convert.ToString(nameCommand.ExecuteScalar());
                        }
                        string nameQuery = "SELECT NAME FROM CUSTOMERS WHERE CUSTOMER_ID = :customerId";
                      

                        using (var nameCommand = new OracleCommand(nameQuery, connection))
                        {
                            nameCommand.Parameters.Add(new OracleParameter("customerId", CustomerId));
                            receiverName = Convert.ToString(nameCommand.ExecuteScalar());
                        }
                        DialogResult dialogResult = MessageBox.Show("Account Title: " + receiverName + "\nAre you sure you want to Debit : RS " + AmountTxtBox.Text.ToString(),
                                                                    "Confirm Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.Yes)
                        {
                            long referenceId = SendMoney.generateReferenceId();

                            using (var transaction = connection.BeginTransaction())
                            {
                                try
                                {


                                    string creditQuery = "UPDATE ACCOUNT SET ACCOUNT_BALANCE = ACCOUNT_BALANCE - :amount WHERE ACCOUNT_ID = :receiverAccountId";
                                    using (var creditCommand = new OracleCommand(creditQuery, connection))
                                    {
                                        creditCommand.Parameters.Add(new OracleParameter("amount", Int32.Parse(AmountTxtBox.Text.ToString())));
                                        creditCommand.Parameters.Add(new OracleParameter("receiverAccountId", Int64.Parse(CustomerAccountNotxtBox.Text.ToString())));
                                        creditCommand.ExecuteNonQuery();
                                    }
                                    string creditTransactionQuery = @"
                                    INSERT INTO TRANSACTION (
                                        TRANSACTION_ID, 
                                        ACCOUNT_ID, 
                                        TRANSACTION_TYPE, 
                                        AMOUNT, 
                                        TRANSACTION_DATE, 
                                        DESCRIPTION, 
                                        BRANCH_ID,
                                        REFERENCE_ID) 
                                    VALUES (
                                        :transactionId, 
                                        :receiverAccountId, 
                                        :transactionType, 
                                        :amount, 
                                        SYSDATE, 
                                        :description, 
                                        :branchId, 
                                        :referenceId)";
                                    long transactionid = SendMoney.generateTransactionId();
                                    using (var creditTransactionCommand = new OracleCommand(creditTransactionQuery, connection))
                                    {
                                        creditTransactionCommand.Parameters.Add(new OracleParameter("transactionId", transactionid));
                                        creditTransactionCommand.Parameters.Add(new OracleParameter("receiverAccountId", CustomerAccountNotxtBox.Text.ToString()));
                                        creditTransactionCommand.Parameters.Add(new OracleParameter("transactionType", "Debit"));
                                        creditTransactionCommand.Parameters.Add(new OracleParameter("amount", Int32.Parse(AmountTxtBox.Text.ToString())));
                                        creditTransactionCommand.Parameters.Add(new OracleParameter("description", "Funds Debited Via Teller "));
                                        creditTransactionCommand.Parameters.Add(new OracleParameter("branchId", GlobalData.CurrentEmployee.branchId.ToString()));
                                        creditTransactionCommand.Parameters.Add(new OracleParameter("referenceId", referenceId));
                                        creditTransactionCommand.ExecuteNonQuery();
                                    }
                                    transaction.Commit();
                                    GlobalData.customizedPopup("Funds Debited successfully.");
                                    NotifyCustomerForAccountDebit(recieverEmail, Convert.ToDecimal(AmountTxtBox.Text.Trim()), transactionid.ToString(), CustomerAccountNotxtBox.Text.ToString(), GlobalData.CurrentEmployee.lastName,GlobalData.CurrentEmployee.branchId.ToString());
                                    foreach (Form form in Application.OpenForms)
                                    {
                                        if (form.Name == "ManagerHomePage" || form.Name == "tellerHomePage")
                                        {
                                            form.BringToFront();
                                            form.Focus();
                                            this.Close();
                                            return;
                                        }
                                    }
                                    this.Close();
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("An error occurred: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            return;

                        }

                    }
                    else
                    {
                        MessageBox.Show("Invalid Account Number : " + CustomerAccountNotxtBox.Text, "Error!", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
        }
        private void NotifyCustomerForAccountDebit(
    string recipientEmail, decimal amount, string transactionID, string accountNumber, string tellerName,string branchNumber)
        {
            this.Cursor = Cursors.WaitCursor;
            string from, pass, messageBody, to, emailUsername;
            emailUsername = "Askari Digital Bank Ltd.";
            from = "AskariDigitalOTP@gmail.com";
            pass = GlobalData.password;
            to = recipientEmail;

            messageBody = $"Dear Customer,\n\n" +
                          $"Your account has been debited as per the details below:\n\n" +
                          $"Transaction Details:\n" +
                          $"- Transaction ID: {transactionID}\n" +
                          $"- Amount Debited: Rs.{amount}\n" +
                          $"- Account Number: {accountNumber}\n" +
                          $"- Processed By: {tellerName} from Branch {branchNumber}\n\n" +
                          "If you have any queries or did not authorize this transaction, please contact our support team immediately.\n\n" +
                          "Thank you for banking with Askari Digital Bank Ltd.\n\n" +
                          "Best Regards,\n" +
                          "Askari Digital Bank Ltd.";

            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from, emailUsername);
            message.Body = messageBody;
            message.Subject = "Account Debit Notification - Askari Digital Banking";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(from, pass)
            };

            try
            {
                smtpClient.Send(message);
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show($"Failed to send notification: {ex.Message}");
            }
        }





        private void Exit_btn__SendMoney_Form_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "ManagerHomePage" || form.Name == "tellerHomePage")
                {
                    form.BringToFront();
                    form.Focus();
                    this.Close();
                    return;
                }
            }
            this.Close();
           
        }

        private void AmountTxtBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
