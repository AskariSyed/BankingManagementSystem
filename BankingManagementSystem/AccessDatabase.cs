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
    public partial class AccessDatabase : Form
    {
        public AccessDatabase()
        {
            InitializeComponent();
        }

        private void runQueryBtn_Click(object sender, EventArgs e)
        {
            string query = QueryTxtBox.Text;
            if (query.IndexOf("DROP", StringComparison.OrdinalIgnoreCase) >= 0 ||
                query.IndexOf("DELETE", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                MessageBox.Show("Destructive queries are not allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Please enter a valid query.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(GlobalData.connString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        if (query.TrimStart().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                        {
                            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                            DataTable resultTable = new DataTable();
                            adapter.Fill(resultTable);
                            QueryResultDataGrid.DataSource = resultTable;
                        }
                        else
                        {
                            int affectedRows = cmd.ExecuteNonQuery();
                            MessageBox.Show($"Query executed successfully. Rows affected: {affectedRows}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                
                MessageBox.Show("Oracle Error Occured please see auit log for more information");
                GlobalData.LogError("Error Occured ", ex);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Oracle Error Occured please see auit log for more information");
                GlobalData.LogError("Error Occured ", ex);
            }
        }

        private void QueryResultDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Exit_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "ManagerHomePage")
                {
                    form.BringToFront();
                    form.Focus();
                    this.Close();
                    return;
                }
            }
            this.Close();
        }
    }
}

