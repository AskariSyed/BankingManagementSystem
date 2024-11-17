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
    public partial class AllTransactionsTable : Form
    {
        public AllTransactionsTable()
        {
            InitializeComponent();
            TransactionDatagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            TransactionDatagridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void AllTransactionsTable_Load(object sender, EventArgs e)
        {

                string query = @"SELECT TRANSACTION_ID, TRANSACTION_TYPE, AMOUNT, TRANSACTION_DATE, DESCRIPTION, BRANCH_ID 
                     FROM TRANSACTION 
                     WHERE ACCOUNT_ID = :accountId";

                using (var connection = new OracleConnection(GlobalData.connString))
                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("accountId", GlobalData.CustomerAccount.accountId));

                    var dataTable = new DataTable();

                    try
                    {
                        connection.Open();
                        using (var adapter = new OracleDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        TransactionDatagridview.DataSource = dataTable; // Bind data to the DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to load transactions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    
}
