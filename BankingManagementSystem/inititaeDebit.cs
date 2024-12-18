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
                        string nameQuery = "SELECT NAME FROM CUSTOMERS WHERE CUSTOMER_ID = :customerId";
                        string receiverName = "";

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

                                    using (var creditTransactionCommand = new OracleCommand(creditTransactionQuery, connection))
                                    {
                                        creditTransactionCommand.Parameters.Add(new OracleParameter("transactionId", SendMoney.generateTransactionId()));
                                        creditTransactionCommand.Parameters.Add(new OracleParameter("receiverAccountId", CustomerAccountNotxtBox.Text.ToString()));
                                        creditTransactionCommand.Parameters.Add(new OracleParameter("transactionType", "Debit"));
                                        creditTransactionCommand.Parameters.Add(new OracleParameter("amount", Int32.Parse(AmountTxtBox.Text.ToString())));
                                        creditTransactionCommand.Parameters.Add(new OracleParameter("description", "Funds Debited Via Teller "));
                                        creditTransactionCommand.Parameters.Add(new OracleParameter("branchId", GlobalData.CurrentEmployee.branchId.ToString()));
                                        creditTransactionCommand.Parameters.Add(new OracleParameter("referenceId", referenceId));
                                        creditTransactionCommand.ExecuteNonQuery();
                                    }
                                    transaction.Commit();
                                    MessageBox.Show("Funds Debited successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Exit_btn__SendMoney_Form_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AmountTxtBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
