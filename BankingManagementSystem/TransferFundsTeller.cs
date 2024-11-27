using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
namespace BankingManagementSystem
{
    public partial class TransferFundsTeller : Form
    {
        public TransferFundsTeller()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(FundsTransfer_Paint);

        }

        private void FundsTransfer_Paint(object sender, PaintEventArgs e)
        {
            // Define border color and width
            int borderWidth = 5;
            Color borderColor = Color.FromArgb(255, 191, 0);


            // Draw the border
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void TransferButton_TransferFundTelleForm_Click(object sender, EventArgs e)
        {


            using (var connection = new OracleConnection(GlobalData.connString))
            {
                connection.Open();
                string query1 = "SELECT COUNT(*) FROM ACCOUNT WHERE ACCOUNT_ID = :accountId";

                using (var command = new OracleCommand(query1, connection))
                {
                    command.Parameters.Add(new OracleParameter("accountId", SenderAccountNoTXTbox.Text.ToString()));

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count ==0) {
                        MessageBox.Show("Invalid Sender Account ");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Valid Sender Account ");
                    }
                }




                        string query = "SELECT COUNT(*) FROM ACCOUNT WHERE ACCOUNT_ID = :accountId";

                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("accountId", RecieverAccountNotxtBox.Text.ToString()));

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        //furtherqueries here 
                        string balanceQuery = "SELECT ACCOUNT_BALANCE FROM ACCOUNT WHERE ACCOUNT_ID = :senderAccountId";

                        using (var balanceCommand = new OracleCommand(balanceQuery, connection))
                        {
                            balanceCommand.Parameters.Add(new OracleParameter("senderAccountId", SenderAccountNoTXTbox.Text));

                            decimal senderBalance = Convert.ToDecimal(balanceCommand.ExecuteScalar());

                            if (senderBalance < Int32.Parse(SendingAmountTxtBox.Text.ToString()))//Sender balance is less give error 
                            {
                                MessageBox.Show("Insufficient balance in the sender's account.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else//if AccountNo is valid and Sender balnce is enough
                            {
                                string customerQuery = "SELECT CUSTOMER_ID FROM ACCOUNT WHERE ACCOUNT_ID = :receiverAccountId";
                                int receiverCustomerId = 0;


                                using (var customerCommand = new OracleCommand(customerQuery, connection))
                                {
                                    customerCommand.Parameters.Add(new OracleParameter("receiverAccountId", RecieverAccountNotxtBox.Text.ToString()));
                                    receiverCustomerId = Convert.ToInt32(customerCommand.ExecuteScalar());
                                }

                              
                                string nameQuery = "SELECT NAME FROM CUSTOMERS WHERE CUSTOMER_ID = :customerId";
                                string receiverName = "";


                                using (var nameCommand = new OracleCommand(nameQuery, connection))
                                {
                                    nameCommand.Parameters.Add(new OracleParameter("customerId", receiverCustomerId));
                                    receiverName = Convert.ToString(nameCommand.ExecuteScalar());
                                }
                               
                                
                                string SenderQuery = "SELECT CUSTOMER_ID FROM ACCOUNT WHERE ACCOUNT_ID = :senderAccountId";
                                int senderCustomerId = 0;


                                using (var customerCommand = new OracleCommand(SenderQuery, connection))
                                {
                                    customerCommand.Parameters.Add(new OracleParameter("senderAccountId", SenderAccountNoTXTbox.Text.ToString()));
                                    senderCustomerId = Convert.ToInt32(customerCommand.ExecuteScalar());
                                }


                                string senderNameQuery = "SELECT NAME FROM CUSTOMERS WHERE CUSTOMER_ID = :customerId";
                                string senderName = "";

                                using (var nameCommand = new OracleCommand(senderNameQuery, connection))
                                {
                                    nameCommand.Parameters.Add(new OracleParameter("customerId", senderCustomerId));
                                    senderName = Convert.ToString(nameCommand.ExecuteScalar());
                                }



                                DialogResult dialogResult = MessageBox.Show("Sender Account Title: " + senderName + "\nReciever Account Title: " + receiverName + "\nAre you sure you want to transfer funds?",
                                                                            "Confirm Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                                if (dialogResult == DialogResult.Yes)
                                {
                                    long referenceId = SendMoney.generateReferenceId();

                                    using (var transaction = connection.BeginTransaction())
                                    {
                                        try
                                        {
                                            // Debit from sender account
                                            string debitQuery = "UPDATE ACCOUNT SET ACCOUNT_BALANCE = ACCOUNT_BALANCE - :amount WHERE ACCOUNT_ID = :senderAccountId";
                                            using (var debitCommand = new OracleCommand(debitQuery, connection))
                                            {
                                                debitCommand.Parameters.Add(new OracleParameter("amount", Int32.Parse(SendingAmountTxtBox.Text.ToString())));
                                                debitCommand.Parameters.Add(new OracleParameter("senderAccountId",SenderAccountNoTXTbox.Text));
                                                debitCommand.ExecuteNonQuery();
                                            }

                                            // Credit to receiver account
                                            string creditQuery = "UPDATE ACCOUNT SET ACCOUNT_BALANCE = ACCOUNT_BALANCE + :amount WHERE ACCOUNT_ID = :receiverAccountId";
                                            using (var creditCommand = new OracleCommand(creditQuery, connection))
                                            {
                                                creditCommand.Parameters.Add(new OracleParameter("amount", Int32.Parse(SendingAmountTxtBox.Text.ToString())));
                                                creditCommand.Parameters.Add(new OracleParameter("receiverAccountId", Int64.Parse(RecieverAccountNotxtBox.Text.ToString())));
                                                creditCommand.ExecuteNonQuery();
                                            }

                                            string transactionQuery = @"
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
                                        :senderAccountId, 
                                        :transactionType, 
                                        :amount, 
                                        SYSDATE, 
                                        :description, 
                                        :branchId,
                                        :referenceid)";

                                            using (var transactionCommand = new OracleCommand(transactionQuery, connection))
                                            {
                                                transactionCommand.Parameters.Add(new OracleParameter("transactionId", SendMoney.generateTransactionId())); // Assuming GenerateTransactionId is a method to create a unique ID
                                                transactionCommand.Parameters.Add(new OracleParameter("senderAccountId", SenderAccountNoTXTbox.Text.ToString()));
                                                transactionCommand.Parameters.Add(new OracleParameter("transactionType", "Debit"));
                                                transactionCommand.Parameters.Add(new OracleParameter("amount", Int32.Parse(SendingAmountTxtBox.Text.ToString())));
                                                transactionCommand.Parameters.Add(new OracleParameter("description", "Funds Transfer to account " + RecieverAccountNotxtBox.Text.ToString() + " Via Teller"));
                                                transactionCommand.Parameters.Add(new OracleParameter("branchId", GlobalData.CurrentEmployee.branchId.ToString()));
                                                transactionCommand.Parameters.Add(new OracleParameter("referenceid", referenceId));

                                                transactionCommand.ExecuteNonQuery();
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

                                            using (var creditTransactionCommand = new OracleCommand(creditTransactionQuery, connection))
                                            {
                                                
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("transactionId", SendMoney.generateTransactionId()));
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("receiverAccountId", RecieverAccountNotxtBox.Text.ToString()));
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("transactionType", "Credit"));
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("amount", Int32.Parse(SendingAmountTxtBox.Text.ToString())));
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("description", "Funds Transfer from account "+SenderAccountNoTXTbox.Text.ToString()+" Via Teller "));
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("branchId", GlobalData.CurrentEmployee.branchId.ToString()));
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("referenceId", referenceId));
                                                creditTransactionCommand.ExecuteNonQuery();
                                            }
                                            transaction.Commit();
                                            MessageBox.Show("Funds transferred successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        }




                    }
                    else
                    {
                        MessageBox.Show("Invalid Account Number : " + RecieverAccountNotxtBox.Text, "Error!", MessageBoxButtons.OK);
                        return;
                    }
                }
            }

        }

        private void Exit_btn__SendMoney_Form_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
