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
    public partial class TransactionReversal : Form
    {
        public TransactionReversal()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(paint);
        }
        private void paint(object sender, PaintEventArgs e)
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
                        // Add the account number as a parameter to avoid SQL injection
                        cmd.Parameters.Add(new OracleParameter("accountNo", accountNo));

                        OracleDataReader reader = cmd.ExecuteReader();

                        // Clear existing rows in the DataGridView
                        TransactionDataGridTable.Rows.Clear();

                        if (!reader.HasRows)
                        {
                            // If no transactions are found for the given account number
                            MessageBox.Show("No transactions found for this account.");
                            return;
                        }

                        // Populate the DataGridView with the fetched data
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

                            // Add the row to the DataGridView
                            TransactionDataGridTable.Rows.Add(row);
                        }
                    }

                    // Optionally, you can make the DataGridView visible after populating it
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
            // Get the reference ID entered by the user in the input box (assuming it's a TextBox named ReferenceIdTxtBox)
            string referenceId = AttributeTxtBox.Text.Trim();

            // Ensure the reference ID is not empty
            if (string.IsNullOrEmpty(referenceId))
            {
                MessageBox.Show("Please enter a reference ID.");
                return;
            }
            if (referenceId.Length != 7)
            {
                MessageBox.Show("Please Enter Valid 7 digits Transaction ID");
            }


            // Validate if the entered reference ID is a valid number (assuming REFERENCE_ID is a number)
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

        private void AuditLogDataGridTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ReverseSelectedTransaction_Click(object sender, EventArgs e)
        {
            if (TransactionDataGridTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to reverse.");
                return;
            }
            DataGridViewRow selectedRow = TransactionDataGridTable.SelectedRows[0];
            int referenceId = Convert.ToInt32(selectedRow.Cells["ReferenceID"].Value);

            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
              
                conn.Open();
                OracleTransaction transaction = conn.BeginTransaction();

                // Query to fetch both the debit and credit transactions with the same reference ID
                string fetchTransactionsQuery = @"
            SELECT TRANSACTION_ID, ACCOUNT_ID, TRANSACTION_TYPE, AMOUNT, TRANSACTION_DATE, DESCRIPTION, BRANCH_ID, REFERENCE_ID 
            FROM transaction
            WHERE REFERENCE_ID = :referenceId";

                // Insert query for reversal of transactions
                string insertReversalQuery = @"
            INSERT INTO transaction (
                TRANSACTION_ID, ACCOUNT_ID, TRANSACTION_TYPE, AMOUNT, TRANSACTION_DATE, DESCRIPTION, BRANCH_ID, REFERENCE_ID
            ) VALUES (
                :transactionId, :accountId, :transactionType, :amount, :transactionDate, :description, :branchId, :referenceId
            )";

                // Update query for adjusting account balance
                string updateAccountBalanceQuery = @"
            UPDATE account
            SET ACCOUNT_BALANCE = ACCOUNT_BALANCE + :amount
            WHERE ACCOUNT_ID = :accountId";

                try
                {
                    List<OracleCommand> reversalCommands = new List<OracleCommand>();
                    List<OracleCommand> balanceUpdateCommands = new List<OracleCommand>();

                    // Fetch debit and credit transactions with the same reference ID
                    using (OracleCommand fetchCmd = new OracleCommand(fetchTransactionsQuery, conn))
                    {
                        fetchCmd.Parameters.Add(new OracleParameter("referenceId", referenceId));
                        using (OracleDataReader reader = fetchCmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("No transactions found for the selected Reference ID.");
                                return;
                            }

                            // Iterate through the fetched transactions (debit and credit)
                            while (reader.Read())
                            {
                                int originalTransactionId = Convert.ToInt32(reader["TRANSACTION_ID"]);
                                string accountId = reader["ACCOUNT_ID"].ToString();
                                string transactionType = reader["TRANSACTION_TYPE"].ToString();
                                decimal amount = Convert.ToDecimal(reader["AMOUNT"]);
                                int branchId = Convert.ToInt32(reader["BRANCH_ID"]);
                                string reversalType = transactionType.Equals("Debit", StringComparison.OrdinalIgnoreCase) ? "Credit" : "Debit"; // Reverse the type
                                string description = $"Reversal of transaction ID {originalTransactionId}";
                                DateTime reversalDate = DateTime.Now;

                                // Reversal command
                                OracleCommand reversalCmd = new OracleCommand();
                                reversalCmd.Connection = conn;
                                reversalCmd.Transaction = transaction;
                                reversalCmd.CommandText = insertReversalQuery;
                                reversalCmd.Parameters.Add(new OracleParameter("transactionId", SendMoney.generateTransactionId())); // Generate new transaction ID
                                reversalCmd.Parameters.Add(new OracleParameter("accountId", accountId));
                                reversalCmd.Parameters.Add(new OracleParameter("transactionType", reversalType));
                                reversalCmd.Parameters.Add(new OracleParameter("amount", amount));
                                reversalCmd.Parameters.Add(new OracleParameter("transactionDate", reversalDate));
                                reversalCmd.Parameters.Add(new OracleParameter("description", description));
                                reversalCmd.Parameters.Add(new OracleParameter("branchId", branchId));
                                reversalCmd.Parameters.Add(new OracleParameter("referenceId", referenceId)); // Use the same reference ID for both transactions

                                reversalCommands.Add(reversalCmd);

                                // Balance update command
                                decimal balanceAdjustment = transactionType.Equals("Debit", StringComparison.OrdinalIgnoreCase) ? amount : -amount;
                                OracleCommand balanceUpdateCmd = new OracleCommand();
                                balanceUpdateCmd.Connection = conn;
                                balanceUpdateCmd.Transaction = transaction;
                                balanceUpdateCmd.CommandText = updateAccountBalanceQuery;
                                balanceUpdateCmd.Parameters.Add(new OracleParameter("amount", balanceAdjustment));
                                balanceUpdateCmd.Parameters.Add(new OracleParameter("accountId", accountId));

                                balanceUpdateCommands.Add(balanceUpdateCmd);
                            }
                        }
                    }
                    foreach (var cmd in reversalCommands)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    foreach (var cmd in balanceUpdateCommands)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();

                    MessageBox.Show("Transactions reversed and account balances updated successfully!");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error reversing transactions: " + ex.Message);
                }
            }
        }

        private void AttributeTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AccountSummary_label_HOmePageUSerForm_Click(object sender, EventArgs e)
        {

        }

        private void Exit_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {

        }

        private void toolTipForFullName_Popup(object sender, PopupEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
