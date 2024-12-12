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
    public partial class CheckEmployeeLogs : Form
    {
        public CheckEmployeeLogs()
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

        private void SearchByFirstName_BTN_Click(object sender, EventArgs e)
        {
            populateEmployee("first_name", AttributeTxtBox.Text, "bankemployee");
        }
        Employee searchedEmployee;
        private void populateEmployee(string attribute, string value, string table)
        {
            string query = $"SELECT Employee_id FROM {table} WHERE {attribute} = :value";
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {

                        cmd.Parameters.Add(new OracleParameter("value", value));
                        OracleDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Employee found with the given " + attribute);

                        }
                        else
                        {
                            MessageBox.Show("Reader does not have any value");
                            return;
                        }

                        while (reader.Read())
                        {

                            searchedEmployee = new Employee("EMP" + reader["employee_id"].ToString());
                            MessageBox.Show(Convert.ToString(reader["employee_id"]));
                            EmployeeLogsDataGridTable.Visible = true;
                            FetchAuditLogs();
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

        private void EmployeeLogsDataGridTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FetchAuditLogs()
        {
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                string logQuery = "SELECT AUDIT_LOG_ID, ACTION_PERFORMED, ACTION_DATE FROM auditlog WHERE USER_ID = :userId ORDER BY ACTION_DATE desc";

                try
                {
                    conn.Open();
                    using (OracleCommand logCmd = new OracleCommand(logQuery, conn))
                    {
                        logCmd.Parameters.Add(new OracleParameter("userId", searchedEmployee.userId));
                        OracleDataReader logReader = logCmd.ExecuteReader();
                        EmployeeLogsDataGridTable.Rows.Clear();

                        if (!logReader.HasRows)
                        {
                            EmployeeLogsDataGridTable.Visible = false;
                            MessageBox.Show("No recent activities found for this user.");
                            return;
                        }
                        while (logReader.Read())
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["AUDIT_LOG_ID"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["ACTION_PERFORMED"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["ACTION_DATE"] });
                            EmployeeLogsDataGridTable.Rows.Add(row);
                        }
                        EmployeeLogsDataGridTable.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching audit logs: " + ex.Message);
                }
            }
        }

        private void SearchByCNIC_btn_Click(object sender, EventArgs e)
        {
            string value = AttributeTxtBox.Text;
            string formattedValue = null;
            if (value.Length == 13)
            {
                formattedValue = $"{value.Substring(0, 5)}-{value.Substring(5, 7)}-{value.Substring(12, 1)}";
            }
            else
            {
                MessageBox.Show("Invalid input. Ensure it contains 13 digits.");
                return;
            }
            populateEmployee("CNIC", formattedValue, "bankemployee");

        }

        private void SearchByEmployeeNumber_btn_Click(object sender, EventArgs e)
        {
            if (AttributeTxtBox.Text.Length != 5)
            {
                MessageBox.Show("Please enter a valid employeeID");
                return;
            }
            populateEmployee("Employee_ID", AttributeTxtBox.Text, "bankemployee");
        }

        private void Exit_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckEmployeeLogs_Load(object sender, EventArgs e)
        {

        }
    }
}
