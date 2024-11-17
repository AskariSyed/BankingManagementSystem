using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace BankingManagementSystem
{
    public partial class SendMoney : Form
    {
        
        public SendMoney()
        {
            InitializeComponent();
        }

        

        private void SendMoney_Load(object sender, EventArgs e)
        {

        }

        private void Exit_btn__SendMoney_Form_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TransferButton_SendMoneyForm_Click(object sender, EventArgs e)
        {

           
                using (var connection = new OracleConnection(GlobalData.connString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM ACCOUNT WHERE ACCOUNT_ID = :accountId";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("accountId", RecieverAccountNotxtBox.Text.ToString()));

                        int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0) {
                        //furtherqueries here 
                        string balanceQuery = "SELECT ACCOUNT_BALANCE FROM ACCOUNT WHERE ACCOUNT_ID = :senderAccountId";

                        using (var balanceCommand = new OracleCommand(balanceQuery, connection))
                        {
                            balanceCommand.Parameters.Add(new OracleParameter("senderAccountId", GlobalData.CustomerAccount.accountId));

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

                                // Fetch the customer name from the CUSTOMERS table
                                string nameQuery = "SELECT NAME FROM CUSTOMERS WHERE CUSTOMER_ID = :customerId";
                                string receiverName = "";

                                using (var nameCommand = new OracleCommand(nameQuery, connection))
                                {
                                    nameCommand.Parameters.Add(new OracleParameter("customerId", receiverCustomerId));
                                    receiverName = Convert.ToString(nameCommand.ExecuteScalar());
                                }

                                // Prompt user with receiver's name (account title)
                                DialogResult dialogResult = MessageBox.Show("Account Title: " + receiverName + "\nAre you sure you want to transfer funds?",
                                                                            "Confirm Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                                if (dialogResult == DialogResult.Yes)
                                {
                                    long referenceId = generateReferenceId();

                                    using (var transaction = connection.BeginTransaction())
                                    {
                                        try
                                        {
                                            // Debit from sender account
                                            string debitQuery = "UPDATE ACCOUNT SET ACCOUNT_BALANCE = ACCOUNT_BALANCE - :amount WHERE ACCOUNT_ID = :senderAccountId";
                                            using (var debitCommand = new OracleCommand(debitQuery, connection))
                                            {
                                                debitCommand.Parameters.Add(new OracleParameter("amount", Int32.Parse(SendingAmountTxtBox.Text.ToString())));
                                                debitCommand.Parameters.Add(new OracleParameter("senderAccountId", GlobalData.CustomerAccount.accountId));
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
                                                transactionCommand.Parameters.Add(new OracleParameter("transactionId", generateTransactionId())); // Assuming GenerateTransactionId is a method to create a unique ID
                                                transactionCommand.Parameters.Add(new OracleParameter("senderAccountId", GlobalData.CustomerAccount.accountId));
                                                transactionCommand.Parameters.Add(new OracleParameter("transactionType", "Debit"));
                                                transactionCommand.Parameters.Add(new OracleParameter("amount", Int32.Parse(SendingAmountTxtBox.Text.ToString())));
                                                transactionCommand.Parameters.Add(new OracleParameter("description", "Funds transfer to account " + RecieverAccountNotxtBox.Text));
                                                transactionCommand.Parameters.Add(new OracleParameter("branchId", 1954));
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
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("transactionId", generateTransactionId())); 
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("receiverAccountId", RecieverAccountNotxtBox.Text.ToString()));
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("transactionType", "Credit"));
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("amount", Int32.Parse(SendingAmountTxtBox.Text.ToString())));
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("description", "Funds received from account " + GlobalData.CustomerAccount.accountId));
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("branchId", 1954)); 
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
                        MessageBox.Show("Invalid Account Number : "+RecieverAccountNotxtBox.Text,"Error!",MessageBoxButtons.OK);
                        return;
                    }
                    }
                }
            



        }


        private long generateTransactionId()
        {
            bool isUnique = false;
            long transactionIDAssigned = 0;
            Random random = new Random();
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                conn.Open();
                while (!isUnique)
                {
                    transactionIDAssigned = random.Next(1000000, 10000000); 

                    try
                    {
                        string query = "SELECT COUNT(*) FROM transaction WHERE transaction_ID = :transactionid";
                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.Parameters.Add(new OracleParameter("transactionid", transactionIDAssigned));

                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (count == 0)
                            {
                                isUnique = true;
                                MessageBox.Show($"Unique Transaction ID Assigned: {transactionIDAssigned}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error while checking transaction ID: {ex.Message}");
                        break; 
                    }
                }
            }

            return transactionIDAssigned;
        }


        private long generateReferenceId()
        {
            bool isUnique = false;
            long referenceIDAssigned = 0;
            Random random = new Random();
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                conn.Open();
                while (!isUnique)
                {
                    referenceIDAssigned = random.Next(1000000, 10000000);

                    try
                    {
                        string query = "SELECT COUNT(*) FROM transaction WHERE REFERENCE_ID = :referenceid";
                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.Parameters.Add(new OracleParameter("referenceid", referenceIDAssigned));

                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (count == 0)
                            {
                                isUnique = true;
                                MessageBox.Show($"Unique Reference ID Assigned: {referenceIDAssigned}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error while checking refernce ID: {ex.Message}");
                        break;
                    }
                }
            }

            return referenceIDAssigned;
        }

    }
}
