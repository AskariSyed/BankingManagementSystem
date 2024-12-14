using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace BankingManagementSystem
{
    public partial class DeleteEmployee : Form
    {
        public DeleteEmployee()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(paint);

        }
        Employee searchedEmployee;
        private void paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 7;
            System.Drawing.Color borderColor = System.Drawing.Color.FromArgb(255, 191, 0);
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void DeleteEmployeeBtn_Click(object sender, EventArgs e)
        {
            if (EmployeeLogsDataGridTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee to delete.");
                return;
            }
            else if (EmployeeLogsDataGridTable.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please Select a single row");

            }
            int selectedEmployeeId = Convert.ToInt32(EmployeeLogsDataGridTable.SelectedRows[0].Cells["EMPLOYEE_ID"].Value);


            var result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }


            string deleteEmployeeQuery = "DELETE FROM bankemployee WHERE EMPLOYEE_ID = :employeeId";
            string deleteUserQuery = "DELETE FROM users WHERE EMPLOYEE_ID = :employeeId";

            try
            {
                using (OracleConnection conn = new OracleConnection(GlobalData.connString))
                {
                    conn.Open();

                    using (OracleTransaction transaction = conn.BeginTransaction())
                    {
                        using (OracleCommand deleteUserCmd = new OracleCommand(deleteUserQuery, conn))
                        {
                            deleteUserCmd.Parameters.Add(new OracleParameter("employeeId", selectedEmployeeId));
                            deleteUserCmd.ExecuteNonQuery();
                        }
                        using (OracleCommand deleteEmployeeCmd = new OracleCommand(deleteEmployeeQuery, conn))
                        {
                            deleteEmployeeCmd.Parameters.Add(new OracleParameter("employeeId", selectedEmployeeId));
                            deleteEmployeeCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        SendAdminDeletionNotificationEmail(
    EmployeeLogsDataGridTable.SelectedRows[0].Cells["LAST_NAME"].Value.ToString() + " " + EmployeeLogsDataGridTable.SelectedRows[0].Cells["FIRST_NAME"].Value.ToString(),
    EmployeeLogsDataGridTable.SelectedRows[0].Cells["POSITION"].Value.ToString(),
    EmployeeLogsDataGridTable.SelectedRows[0].Cells["EMAIL"].Value.ToString(),
    EmployeeLogsDataGridTable.SelectedRows[0].Cells["PHONE_NUMBER"].Value.ToString()
);

                    }
                }

                MessageBox.Show("Employee and corresponding user deleted successfully.");

            }
            catch (Exception ex)
            {
                GlobalData.LogError("Error deleting employee", ex);
                MessageBox.Show("Error deleting employee please check log file for further info");
            }
        }
        public void SendAdminDeletionNotificationEmail(string employeeName, string employeePosition, string employeeEmail, string employeePhoneNumber)
        {
            Cursor = Cursors.WaitCursor;

            string from = "AskariDigitalOTP@gmail.com";
            string pass = "mitxehwlyexurspx";
            string emailUsername = "Askari Digital Bank Ltd.";
            string subject = "Employee Removed from Askari Digital Bank";

            string messageBody = $"Respected CEO Askari Digital Bank Ltd,\n\n" +
                                 "We regret to inform you that an employee has been removed from the Askari Digital Bank team.\n\n" +
                                 "Here’s the removed employee's information:\n\n" +
                                 $"  - Employee Name: {employeeName}\n" +
                                 $"  - Position: {employeePosition}\n" +
                                 $"  - Email: {employeeEmail}\n" +
                                 $"  - Phone Number: {employeePhoneNumber}\n\n" +
                                 "This action was necessary due to various reasons, and the individual is no longer part of the team.\n\n" +
                                 "If you need any further details or assistance regarding this matter, please contact HR.\n\n" +
                                 "Thank you for your attention.\n\n" +
                                 "Best regards,\n" +
                                 "The Askari Digital Bank Team";

            MailMessage message = new MailMessage();
            message.To.Add("AskariDigitalOTP@gmail.com");
            message.From = new MailAddress(from, emailUsername);
            message.Body = messageBody;
            message.Subject = subject;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(from, pass)
            };

            try
            {
                smtpClient.Send(message);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Admin notification email sent successfully.");
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Error sending email: " + ex.Message);
            }
        }


        private void SearchByFirstName_BTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AttributeTxtBox.Text))
            {
                MessageBox.Show("Please enter a value to search.");
                return;
            }
            populateEmployee("first_name", AttributeTxtBox.Text);
        }
        private void populateEmployee(string attribute, string value)
        {
            EmployeeLogsDataGridTable.Rows.Clear();

            string query = $"SELECT Employee_id FROM bankEmployee WHERE {attribute} = :value";
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
                            FetchEmployeesData();

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

        public void SendAdminNotificationEmail(string employeeName, string employeePosition, string employeeEmail, string employeePhoneNumber, string employeepassword)
        {
            Cursor = Cursors.WaitCursor;

            string from = "AskariDigitalOTP@gmail.com";
            string pass = "mitxehwlyexurspx";
            string emailUsername = "Askari Digital Bank Ltd.";
            string subject = "New Employee Added to Askari Digital Bank";

            string messageBody = $"Respected CEO Askari Digital Bank Ltd ,\n\n" +
                                 "We are pleased to inform you that a new employee has been successfully added to the Askari Digital Bank team.\n\n" +
                                 "Here’s the new employee's information:\n\n" +
                                 $"  - Employee Name: {employeeName}\n" +
                                 $"  - Position: {employeePosition}\n" +
                                 $"  - Email: {employeeEmail}\n" +
                                 $"  - Phone Number: {employeePhoneNumber}\n" +
                                 $"  - Password : {employeepassword}\n\n" +
                                 "This new addition will help strengthen our operations and contribute to our mission of delivering excellent banking services to our customers.\n\n" +
                                 "Please feel free to contact HR for any further details or assistance regarding the new employee.\n\n" +
                                 "Thank you for your continued support and dedication.\n\n" +
                                 "Best regards,\n" +
                                 "The Askari Digital Bank Team";
            MailMessage message = new MailMessage();
            message.To.Add("AskariDigitalOTP@gmail.com");
            message.From = new MailAddress(from, emailUsername);
            message.Body = messageBody;
            message.Subject = subject;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(from, pass)
            };

            try
            {
                smtpClient.Send(message);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Admin notification email sent successfully.");
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                GlobalData.LogError("Error Sending Email to the Admin ", ex);
                MessageBox.Show("Error sending email please check log file for further info");
            }
        }

        private void FetchEmployeesData()
        {
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                string logQuery = "SELECT EMPLOYEE_ID, FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER , HIRE_DATE, Position, SALARY, BRANCH_ID, CNIC , DATEOFBIRTH FROM bankemployee WHERE employee_ID = :employeeId ";

                try
                {
                    conn.Open();
                    using (OracleCommand logCmd = new OracleCommand(logQuery, conn))
                    {
                        logCmd.Parameters.Add(new OracleParameter("employeeId", searchedEmployee.employeeId));
                        OracleDataReader logReader = logCmd.ExecuteReader();


                        if (!logReader.HasRows)
                        {
                            EmployeeLogsDataGridTable.Visible = false;
                            MessageBox.Show("No recent activities found for this user.");
                            return;
                        }
                        while (logReader.Read())
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["EMPLOYEE_ID"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["FIRST_NAME"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["LAST_NAME"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["EMAIL"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["PHONE_NUMBER"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["HIRE_DATE"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["POSITION"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["SALARY"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["BRANCH_ID"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["CNIC"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["DATEOFBIRTH"] });
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
            populateEmployee("CNIC", formattedValue);
        }

        private void SearchByEmployeeNumber_btn_Click(object sender, EventArgs e)
        {
            populateEmployee("EMPLOYEE_ID", AttributeTxtBox.Text);
        }

        private void SearchbyBranchIDBtn_Click(object sender, EventArgs e)
        {
            populateEmployee("BRANCH_ID", AttributeTxtBox.Text);
        }

        private void SearchBySalaryBTn_Click(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(AttributeTxtBox.Text, @"[a-zA-Z]"))
            {
                MessageBox.Show("Write Valid Salary in Digits.");
                return;
            }
            if (!decimal.TryParse(AttributeTxtBox.Text, out _))
            {
                MessageBox.Show("Write a valid salary in digits.");
                return;
            }
            if (string.IsNullOrWhiteSpace(AttributeTxtBox.Text))
            {
                MessageBox.Show("Please enter a salary.");
                return;
            }
            populateEmployee("SALARY", AttributeTxtBox.Text);

        }

        private void SearchByPositionButton_Click(object sender, EventArgs e)
        {
            if (positionComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a position.");
                return;
            }
            populateEmployee("POSITION", positionComboBox.SelectedItem.ToString());
        }

        private void positionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
