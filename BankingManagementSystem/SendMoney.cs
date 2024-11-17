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

                                        // Commit transaction
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
    }
}
