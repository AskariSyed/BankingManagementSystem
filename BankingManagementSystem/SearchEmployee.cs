using MigraDoc.DocumentObjectModel.Tables;
using Org.BouncyCastle.Asn1.Cms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MigraDoc.DocumentObjectModel;
using System.Net.Mail;
using System.Net;
using Org.BouncyCastle.Crypto.Macs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Text.RegularExpressions;


namespace BankingManagementSystem
{
    public partial class SearchEmployee : Form
    {
        public SearchEmployee()
        {
            InitializeComponent(); 
            this.Paint += new PaintEventHandler(paint);

        }
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

        private Employee searchedEmployee;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    GlobalData.LogError("Error Fetching Employee Data", ex);
                    MessageBox.Show("Error fetching Employees data please check log file for further information" );
                }
            }
        }

        private void EmployeeLogsDataGridTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void SearchEmployee_Load(object sender, EventArgs e)
        {

        }

        private void Exit_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            searchedEmployee = null;
            this.Close();
           
        }

        private void AddNewEmployeeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmployeeLogsDataGridTable.Rows.Count < 2)
                {
                    MessageBox.Show("No data to add.");
                    return;
                }

                DataGridViewRow newRow = EmployeeLogsDataGridTable.Rows[EmployeeLogsDataGridTable.Rows.Count - 2];
                string firstName = newRow.Cells["FIRST_NAME"].Value?.ToString();
                string lastName = newRow.Cells["LAST_NAME"].Value?.ToString();
                string email = newRow.Cells["EMAIL"].Value?.ToString();
                string phoneNumber = newRow.Cells["PHONE_NUMBER"].Value?.ToString();
                string position = newRow.Cells["POSITION"].Value?.ToString();
                decimal salary = Convert.ToDecimal(newRow.Cells["SALARY"].Value);
                string branchId = newRow.Cells["BRANCH_ID"].Value?.ToString();
                string cnic = newRow.Cells["CNIC"].Value?.ToString();
                DateTime dob = Convert.ToDateTime(newRow.Cells["DATEOFBIRTH"].Value);
                string passwordHash;
                if (string.IsNullOrWhiteSpace(cnic))
                {
                    MessageBox.Show("CNIC cannot be empty.");
                    return;
                }
                var cnicWithoutHyphensRegex = new Regex(@"^\d{13}$");
                var cnicWithHyphensRegex = new Regex(@"^\d{5}-\d{7}-\d{1}$");
                if (cnicWithoutHyphensRegex.IsMatch(cnic))
                {
                    
                    cnic = $"{cnic.Substring(0, 5)}-{cnic.Substring(5, 7)}-{cnic.Substring(12)}";
                }
                else if (!cnicWithHyphensRegex.IsMatch(cnic))
                {
                    MessageBox.Show("Invalid CNIC format. Please enter a valid CNIC.");
                    return;
                }




                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(position)
                    || salary <= 0 || string.IsNullOrEmpty(branchId) || string.IsNullOrEmpty(cnic) || dob == DateTime.MinValue)
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return;
                }
                string username = lastName + firstName;

                string employeeQuery = @"INSERT INTO bankemployee (EMPLOYEE_ID, FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, HIRE_DATE, POSITION, SALARY, BRANCH_ID, CNIC, DATEOFBIRTH, USER_ID) 
                             VALUES (:employeeId, :firstName, :lastName, :email, :phoneNumber, :hireDate, :position, :salary, :branchId, :cnic, :dob, :userid)";

                string userQuery = @"INSERT INTO users (USER_ID, USERNAME, PASSWORDHASH, ROLE, EMPLOYEE_ID, EMAIL, FAILEDLOGINATTEMPT, STATUS) 
                         VALUES (:userid, :username, :passwordHash, :role, :employeeId, :email, :failedLoginAttempt, :status)";

                using (OracleConnection conn = new OracleConnection(GlobalData.connString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM USERS WHERE USERNAME = :username";
                    try
                    {
                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.Parameters.Add(new OracleParameter("username", username));

                            int usernameCount = Convert.ToInt32(cmd.ExecuteScalar());

                            if (usernameCount > 0)
                            {
                                MessageBox.Show("Username already exists. Please choose a different username. By Manual adding emooyee from add employee feature from home page", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        GlobalData.LogError("Error Checking Available username", ex);
                        MessageBox.Show("Error Checking Available username Please Check Log file for more info " + ex.Message);
                    }
                    using (OracleTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            using (OracleCommand employeeCmd = new OracleCommand(employeeQuery, conn))
                            using (OracleCommand userCmd = new OracleCommand(userQuery, conn))
                            {
                                int newEmployeeID = Employee.generateNewEmployeeId();
                                string newUserID = "EMP" + newEmployeeID;
                              
                                passwordHash = GlobalData.GeneratePassword();
                                string role = "Employee";
                                int failedLoginAttempt = 0;
                                string status = "Active";
                                employeeCmd.Parameters.Add(new OracleParameter("employeeId", newEmployeeID));
                                employeeCmd.Parameters.Add(new OracleParameter("firstName", firstName));
                                employeeCmd.Parameters.Add(new OracleParameter("lastName", lastName));
                                employeeCmd.Parameters.Add(new OracleParameter("email", email));
                                employeeCmd.Parameters.Add(new OracleParameter("phoneNumber", phoneNumber));
                                employeeCmd.Parameters.Add(new OracleParameter("hireDate", DateTime.Now.Date));
                                employeeCmd.Parameters.Add(new OracleParameter("position", position));
                                employeeCmd.Parameters.Add(new OracleParameter("salary", salary));
                                employeeCmd.Parameters.Add(new OracleParameter("branchId", branchId));
                                employeeCmd.Parameters.Add(new OracleParameter("cnic", cnic));
                                employeeCmd.Parameters.Add(new OracleParameter("dob", dob));
                                employeeCmd.Parameters.Add(new OracleParameter("userid", newUserID));
                                userCmd.Parameters.Add(new OracleParameter("userid", newUserID));
                                userCmd.Parameters.Add(new OracleParameter("username", username));
                                userCmd.Parameters.Add(new OracleParameter("passwordHash", passwordHash));
                                userCmd.Parameters.Add(new OracleParameter("role", role));
                                userCmd.Parameters.Add(new OracleParameter("employeeId", newEmployeeID));
                                userCmd.Parameters.Add(new OracleParameter("email", email));
                                userCmd.Parameters.Add(new OracleParameter("failedLoginAttempt", failedLoginAttempt));
                                userCmd.Parameters.Add(new OracleParameter("status", status));
                                employeeCmd.ExecuteNonQuery();
                                userCmd.ExecuteNonQuery();

                                string insertAuditLogQuery = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                                                "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";
                                using (OracleCommand insertCmd = new OracleCommand(insertAuditLogQuery, conn))
                                {
                                    insertCmd.Parameters.Add(new OracleParameter("auditLogId", signInpage.GenerateNewLogID()));
                                    insertCmd.Parameters.Add(new OracleParameter("userId", GlobalData.CurrentEmployee.userId));
                                    insertCmd.Parameters.Add(new OracleParameter("actionPerformed", "Added An Employee  : " + newEmployeeID));
                                    insertCmd.ExecuteNonQuery();
                                }
                                transaction.Commit();

                                MessageBox.Show("Employee added and user created successfully!");
                            }
                            SendAdminNotificationEmail(firstName +" "+lastName,position,email,phoneNumber, passwordHash);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            GlobalData.LogError("Error adding employee", ex);
                            MessageBox.Show("Failed to add employee to the DataBase Please Check Log file for more info " + ex.Message);
                        }
                    }
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void SendAdminNotificationEmail( string employeeName, string employeePosition, string employeeEmail, string employeePhoneNumber, string employeepassword)
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
                MessageBox.Show("Error sending email please check log file for further info" );
            }
        }

        private void DeleteEmployeeBtn_Click(object sender, EventArgs e)
        {
            if (EmployeeLogsDataGridTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee to delete.");
                return;
            }
            else if (EmployeeLogsDataGridTable.SelectedRows.Count>1){
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
                        try
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

                            string insertAuditLogQuery = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                                            "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";
                            using (OracleCommand insertCmd = new OracleCommand(insertAuditLogQuery, conn))
                            {
                                insertCmd.Parameters.Add(new OracleParameter("auditLogId", signInpage.GenerateNewLogID()));
                                insertCmd.Parameters.Add(new OracleParameter("userId", GlobalData.CurrentEmployee.userId));
                                insertCmd.Parameters.Add(new OracleParameter("actionPerformed", "Removed An Employee from Data : " + selectedEmployeeId));
                                insertCmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                            MessageBox.Show("Employee and corresponding user deleted successfully.");
                            SendAdminDeletionNotificationEmail(EmployeeLogsDataGridTable.SelectedRows[0].Cells["LAST_NAME"].Value.ToString() + " " + EmployeeLogsDataGridTable.SelectedRows[0].Cells["FIRST_NAME"].Value.ToString(),
        EmployeeLogsDataGridTable.SelectedRows[0].Cells["POSITION"].Value.ToString(), EmployeeLogsDataGridTable.SelectedRows[0].Cells["EMAIL"].Value.ToString(), EmployeeLogsDataGridTable.SelectedRows[0].Cells["PHONE_NUMBER"].Value.ToString());
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            GlobalData.LogError("Error Deleting Employee", ex);
                            MessageBox.Show("Error deleting employee please check log file for further info");
                        }
                    }
                }
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

        private void AccountSummary_label_HOmePageUSerForm_Click(object sender, EventArgs e)
        {

        }

        private void AttributeTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolTipForFullName_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
