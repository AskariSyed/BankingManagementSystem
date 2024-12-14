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
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }

        private void Username_label_signUpForm_Click(object sender, EventArgs e)
        {

        }

        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            try
            {

                string firstName = FirstNameTXTbox.Text.Trim();
                string lastName = LastName_TxtBox.Text.Trim();
                string email = Email_txtBox_.Text.Trim();
                string phoneNumber = ContactNumber_MaskedTextBox.Text.Trim();
                string position = PositionComboBox.Text;
                int salary = int.Parse(SalarytxtBox.Text.ToString());
                string branchId = Branch_ComboBox_.Text.Trim();
                string cnic = Cnic_maskedtextbox.Text;
                DateTime dob = DatofBirth_dateTimePicker.Value;
                string passwordHash = GlobalData.GeneratePassword();
                DateTime hireDate= HireDate_dateTimePicker.Value;
                if (!email.Contains("@") || !email.Contains("."))
                {
                    MessageBox.Show("Please enter a valid email address.");
                    return;
                }

                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(position)
                     || salary <= 0 || string.IsNullOrEmpty(branchId) || string.IsNullOrEmpty(cnic) || dob == DateTime.MinValue)
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return;
                }
                string employeeQuery = @"INSERT INTO bankemployee (EMPLOYEE_ID, FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, HIRE_DATE, POSITION, SALARY, BRANCH_ID, CNIC, DATEOFBIRTH, USER_ID) 
                             VALUES (:employeeId, :firstName, :lastName, :email, :phoneNumber, :hireDate, :position, :salary, :branchId, :cnic, :dob, :userid)";

                string userQuery = @"INSERT INTO users (USER_ID, USERNAME, PASSWORDHASH, ROLE, EMPLOYEE_ID, EMAIL, FAILEDLOGINATTEMPT, STATUS) 
                         VALUES (:userid, :username, :passwordHash, :role, :employeeId, :email, :failedLoginAttempt, :status)";

                using (OracleConnection conn = new OracleConnection(GlobalData.connString))
                {
                    conn.Open();
                    using (OracleTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            using (OracleCommand employeeCmd = new OracleCommand(employeeQuery, conn))
                            using (OracleCommand userCmd = new OracleCommand(userQuery, conn))
                            {
                                int newEmployeeID = Employee.generateNewEmployeeId();
                                string newUserID = "EMP" + newEmployeeID;
                                string username = lastName + firstName;
                                string role = "Employee";
                                int failedLoginAttempt = 0;
                                string status = "Active";
                                employeeCmd.Parameters.Add(new OracleParameter("employeeId", newEmployeeID));
                                employeeCmd.Parameters.Add(new OracleParameter("firstName", firstName));
                                employeeCmd.Parameters.Add(new OracleParameter("lastName", lastName));
                                employeeCmd.Parameters.Add(new OracleParameter("email", email));
                                employeeCmd.Parameters.Add(new OracleParameter("phoneNumber", phoneNumber));
                                employeeCmd.Parameters.Add(new OracleParameter("hireDate", hireDate)); 
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
                                transaction.Commit();

                                GlobalData.customizedPopup("Employee added and user created successfully!");
                                this.Close();
                            }
                            SendAdminNotificationEmail(firstName + " " + lastName, position, email, phoneNumber, passwordHash);
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
                GlobalData.LogError("Error sending admin notification email", ex);
                MessageBox.Show("Error Sending Email Please Check Log file for further information");
            }
        }

    }
}
