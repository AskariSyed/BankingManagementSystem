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
    public partial class TellerAccountStatement : Form
    {
        public TellerAccountStatement()
        {
            InitializeComponent(); this.Paint += new PaintEventHandler(AccounStatement_Paint);

        }

        private void AccounStatement_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 5;
            Color borderColor = Color.FromArgb(255, 191, 0);
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        

        private void RecieverAccountNotxtBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
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

        private void TransferButton_SendMoneyForm_Click(object sender, EventArgs e)
        {
            if (CustomerAccountNotxtBox.Text.Length != 10)
            {
                MessageBox.Show("Please Enter Valid 10 digit Account Number");
                return;
            }
            populateCustomer(CustomerAccountNotxtBox.Text.ToString());
            BankStatementGenerator.GenerateAccountStatementRange(fromDatePicker, toDatePicker);
            GlobalData.CurrentCustomer = null;

        }

        private void Email_Label_ForgO
            Form_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void populateCustomer(string value)
        {
            string query = $"SELECT customer_id FROM account WHERE account_id= :value";
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {

                        cmd.Parameters.Add(new OracleParameter("value",value));
                        OracleDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)  
                        {
                            GlobalData.customizedPopup("customer found with the given Account Number");
                        }
                        else
                        {
                            MessageBox.Show("Reader does not have any value");
                            return;
                        }

                        while (reader.Read())
                        {
                            Customer customer = new Customer("CUS" + reader["customer_id"].ToString());
                            GlobalData.CurrentCustomer = customer;
                            customer.customerId = Convert.ToInt32(reader["customer_id"]);
                            MessageBox.Show(Convert.ToString(reader["customer_id"]));
                            Account account = new Account(customer.customerId);
                            GlobalData.CustomerAccount = account;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

            }


        }

        private void GenerateFullAccountStatement_Click(object sender, EventArgs e)
        {
            if(CustomerAccountNotxtBox.Text.Length!=10)
            {
                MessageBox.Show("Please Enter Valid 10 digit Account Number");
                return;
            }
            populateCustomer(CustomerAccountNotxtBox.Text.ToString());
            BankStatementGenerator.GenerateStatementPDFFull();
            GlobalData.CurrentCustomer = null;

        }
    }
}
