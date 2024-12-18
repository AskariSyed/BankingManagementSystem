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
    public partial class TransactionHistory : Form
    {
        public TransactionHistory()
        {
            InitializeComponent();
            TransactionGridTable.Visible = false;
            this.Paint += new PaintEventHandler(paint);
        }
        private void paint(object sender, PaintEventArgs e)
        {
         
            int borderWidth = 5;
            Color borderColor = Color.FromArgb(255, 191, 0);
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }


        private void SearchByAccountNo_BTN_Click(object sender, EventArgs e)
        {
            string accountNo = AttributeTxtBox.Text.Trim();


            if (string.IsNullOrEmpty(accountNo))
            {
                MessageBox.Show("Please enter an account number.");
                return;
            }
            if (accountNo.Length != 10)
            {
                MessageBox.Show("Please Enter A valid 10 digit Account Number ");
                return;
            }
            string query = "SELECT TRANSACTION_ID, ACCOUNT_ID, TRANSACTION_TYPE, AMOUNT, TRANSACTION_DATE, DESCRIPTION, BRANCH_ID, REFERENCE_ID " +
                           "FROM transaction WHERE ACCOUNT_ID = :accountNo ORDER BY TRANSACTION_DATE DESC";

            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        
                        cmd.Parameters.Add(new OracleParameter("accountNo", accountNo));

                        OracleDataReader reader = cmd.ExecuteReader();

                        
                        TransactionGridTable.Rows.Clear();

                        if (!reader.HasRows)
                        {
                            
                            MessageBox.Show("No transactions found for this account.");
                            return;
                        }

                        
                        while (reader.Read())
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["TRANSACTION_ID"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["ACCOUNT_ID"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["TRANSACTION_TYPE"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["AMOUNT"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["TRANSACTION_DATE"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["DESCRIPTION"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["BRANCH_ID"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["REFERENCE_ID"] });

                           
                            TransactionGridTable.Rows.Add(row);
                        }
                    }

                    TransactionGridTable.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching transactions: " + ex.Message);
                }
            }
        }

        private void Exit_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AttributeTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void TransactionGridTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AttributeTxtBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void AttributeTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
