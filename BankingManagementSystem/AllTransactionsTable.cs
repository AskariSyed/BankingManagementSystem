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
            

            // Set DataGridView auto-sizing for columns and rows
            TransactionDatagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            TransactionDatagridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Apply custom styling
            CustomizeDataGridView();
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

        private void CustomizeDataGridView()
        {
            // Custom colors
            Color headerColor = Color.FromArgb(255, 191, 0); // Golden yellow
            Color selectionBackColor = SystemColors.MenuHighlight; // Blue
            Color rowBackColor = Color.WhiteSmoke; // Light row background

            // Column header style
            TransactionDatagridview.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            TransactionDatagridview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            TransactionDatagridview.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            TransactionDatagridview.EnableHeadersVisualStyles = false; // Allow custom header colors

            // Default row style
            TransactionDatagridview.DefaultCellStyle.BackColor = rowBackColor;
            TransactionDatagridview.DefaultCellStyle.ForeColor = Color.Black;
            TransactionDatagridview.DefaultCellStyle.Font = new Font("Arial", 10);

            // Alternating row style
            TransactionDatagridview.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Selection style
            TransactionDatagridview.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            TransactionDatagridview.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid and border style
            TransactionDatagridview.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            TransactionDatagridview.GridColor = Color.Gray;
        }

        private void TransactionDatagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void AdjustFormSizeToDataGridView()
        {
            TransactionDatagridview.Dock = DockStyle.None;
            this.ClientSize = new Size(TransactionDatagridview.PreferredSize.Width ,
                                       TransactionDatagridview.PreferredSize.Height ); // Add padding
            this.AutoSize = true;
            this.AutoSizeMode=AutoSizeMode.GrowAndShrink;
        this.Size = this.ClientSize;    
         
            TransactionDatagridview.Location = new Point(10, 10);
        }

        

        private void TransactionDatagridview_DataSourceChanged_1(object sender, EventArgs e)
        {
            AdjustFormSizeToDataGridView();
        }
    }
}