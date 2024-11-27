using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;


namespace BankingManagementSystem
{
    public partial class InitiateCredit : Form
    {
        public InitiateCredit()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(initiateCredit_Paint);

        }

        private void initiateCredit_Paint(object sender, PaintEventArgs e)
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

        private void TransferButton_SendMoneyForm_Click(object sender, EventArgs e)
        {
            if (int.Parse(SendingAmountTxtBox.Text) <= 0)
            {
                MessageBox.Show("Please Enter a valid Amount");
                return;
            }

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
                        string customerQuery = "SELECT CUSTOMER_ID FROM ACCOUNT WHERE ACCOUNT_ID = :receiverAccountId";
                        int CustomerId = 0;

                                using (var customerCommand = new OracleCommand(customerQuery, connection))
                                {
                                    customerCommand.Parameters.Add(new OracleParameter("receiverAccountId", CustomerAccountNotxtBox.Text.ToString()));
                                    CustomerId = Convert.ToInt32(customerCommand.ExecuteScalar());
                                }
                                string nameQuery = "SELECT NAME FROM CUSTOMERS WHERE CUSTOMER_ID = :customerId";
                                string receiverName = "";

                                using (var nameCommand = new OracleCommand(nameQuery, connection))
                                {
                                    nameCommand.Parameters.Add(new OracleParameter("customerId", CustomerId));
                                    receiverName = Convert.ToString(nameCommand.ExecuteScalar());
                                }
                                DialogResult dialogResult = MessageBox.Show("Account Title: " + receiverName + "\nAre you sure you want to Credit : RS "+SendingAmountTxtBox.Text.ToString(),
                                                                            "Confirm Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (dialogResult == DialogResult.Yes)
                                {
                                    long referenceId = SendMoney.generateReferenceId();

                                    using (var transaction = connection.BeginTransaction())
                                    {
                                        try
                                        {

                                            
                                            string creditQuery = "UPDATE ACCOUNT SET ACCOUNT_BALANCE = ACCOUNT_BALANCE + :amount WHERE ACCOUNT_ID = :receiverAccountId";
                                            using (var creditCommand = new OracleCommand(creditQuery, connection))
                                            {
                                                creditCommand.Parameters.Add(new OracleParameter("amount", Int32.Parse(SendingAmountTxtBox.Text.ToString())));
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

                                            using (var creditTransactionCommand = new OracleCommand(creditTransactionQuery, connection))
                                            {
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("transactionId", SendMoney.generateTransactionId()));
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("receiverAccountId", CustomerAccountNotxtBox.Text.ToString()));
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("transactionType", "Credit"));
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("amount", Int32.Parse(SendingAmountTxtBox.Text.ToString())));
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("description", "Funds Credited Via Teller "));
                                                creditTransactionCommand.Parameters.Add(new OracleParameter("branchId", GlobalData.CurrentEmployee.branchId));
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
                    else
                    {
                        MessageBox.Show("Invalid Account Number : " + CustomerAccountNotxtBox.Text, "Error!", MessageBoxButtons.OK);
                        return;
                    }
                }
            }


        }

        private void CustomerAccountNotxtBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void SendingAmountTxtBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Exit_btn__SendMoney_Form_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Label_ForgOPasswordForm_Click(object sender, EventArgs e)
        {

        }
    }
}
