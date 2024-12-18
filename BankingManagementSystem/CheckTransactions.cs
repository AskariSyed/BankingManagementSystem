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
    public partial class CheckTransactions : Form
    {
        public CheckTransactions()
        {
            InitializeComponent();
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

        private void Exit_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            this.Close();
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
                MessageBox.Show("Please Enter A valid Account Number ");
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
                        TransactionDataGridTable.Rows.Clear();

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
                            TransactionDataGridTable.Rows.Add(row);
                        }
                    }
                    TransactionDataGridTable.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching transactions: " + ex.Message);
                }
            }
        }

        private void SearchByTransaction_btn_Click(object sender, EventArgs e)
        {
            string transactionId = AttributeTxtBox.Text.Trim();
            if (string.IsNullOrEmpty(transactionId))
            {
                MessageBox.Show("Please enter a transaction ID.");
                return;
            }
            if (transactionId.Length != 7)
            {
                MessageBox.Show("Please Enter Valid 7 digits Transaction ID");
            }
            if (!long.TryParse(transactionId, out long transactionIdParsed))
            {
                MessageBox.Show("Invalid transaction ID. Please enter a valid number.");
                return;
            }
            string query = "SELECT TRANSACTION_ID, ACCOUNT_ID, TRANSACTION_TYPE, AMOUNT, TRANSACTION_DATE, DESCRIPTION, BRANCH_ID, REFERENCE_ID " +
                           "FROM transaction WHERE TRANSACTION_ID = :transactionId";

            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("transactionId", transactionIdParsed));

                        OracleDataReader reader = cmd.ExecuteReader();
                        TransactionDataGridTable.Rows.Clear();

                        if (!reader.HasRows)
                        {
                            MessageBox.Show("No transaction found for the entered ID.");
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
                            TransactionDataGridTable.Rows.Add(row);
                        }
                    }
                    TransactionDataGridTable.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching transaction details: " + ex.Message);
                }
            }
        }

        private void SearchByReferenceId_btn_Click(object sender, EventArgs e)
        {

            string referenceId = AttributeTxtBox.Text.Trim();


            if (string.IsNullOrEmpty(referenceId))
            {
                MessageBox.Show("Please enter a reference ID.");
                return;
            }
            if (referenceId.Length != 7)
            {
                MessageBox.Show("Please Enter Valid 7 digits Transaction ID");
            }



            if (!long.TryParse(referenceId, out long referenceIdParsed))
            {
                MessageBox.Show("Invalid reference ID. Please enter a valid number.");
                return;
            }
            string query = "SELECT TRANSACTION_ID, ACCOUNT_ID, TRANSACTION_TYPE, AMOUNT, TRANSACTION_DATE, DESCRIPTION, BRANCH_ID, REFERENCE_ID " +
                           "FROM transaction WHERE REFERENCE_ID = :referenceId";

            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("referenceId", referenceIdParsed));

                        OracleDataReader reader = cmd.ExecuteReader();
                        TransactionDataGridTable.Rows.Clear();

                        if (!reader.HasRows)
                        {
                            MessageBox.Show("No transactions found for the entered reference ID.");
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
                            TransactionDataGridTable.Rows.Add(row);
                        }
                    }
                    TransactionDataGridTable.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching transaction details: " + ex.Message);
                }
            }

        }
    }
}
