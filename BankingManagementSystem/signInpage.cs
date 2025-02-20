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
using System.Xml.Linq;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace BankingManagementSystem
{
    public partial class signInpage : Form
    {
        public signInpage()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(SiginPage_Paint);
        }

        private void Exit_btn_signinForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void SiginPage_Paint(object sender, PaintEventArgs e)
        {
           
            int borderWidth = 5;
            Color borderColor = Color.FromArgb(255, 191, 0);


           
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
        private void Signup_btn_signinForm_Click(object sender, EventArgs e)
        {
            SignupPage signupPage = new SignupPage();
            this.Hide();
            signupPage.Show();
        }

        private void signInpage_Load(object sender, EventArgs e)
        {

        }

        private void AKBL_logoimage_picturebox_signin_page_Click(object sender, EventArgs e)
        {

        }

        private void SignIn_btn_SigninForm_Click(object sender, EventArgs e)
        {
            string username = Username_txtBox_signinForm.Text;
            string password = Passworde_txtBox_signinForm.Text;
            string customerEmailFetched = "";


            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT CUSTOMER_ID FROM USERS WHERE (EMAIL = :email OR USERNAME = :username) AND PASSWORDHASH = :password AND Status ='Active' AND ROLE='Customer'";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("username", username));
                        cmd.Parameters.Add(new OracleParameter("email", username));

                        cmd.Parameters.Add(new OracleParameter("password", password));
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            int customerId = Convert.ToInt32(result);
                            Customer customer = new Customer(customerId,username);
                            GlobalData.CurrentCustomer = customer;
                            HomePageCustomers homePageCustomers = new HomePageCustomers(customer);
                         
                            homePageCustomers.Show();
                            GlobalData.customizedPopup("Signin Successfull");
                            this.Hide();

                            string userId = "CUS" + customerId;

                          

                            int newAuditID = GenerateNewLogID();

                            string insertAuditLogQuery = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                                            "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";
                            try
                            {
                                using (OracleCommand insertCmd = new OracleCommand(insertAuditLogQuery, conn))
                                {
                                    insertCmd.Parameters.Add(new OracleParameter("auditLogId", newAuditID));
                                    insertCmd.Parameters.Add(new OracleParameter("userId", userId)); 
                                    insertCmd.Parameters.Add(new OracleParameter("actionPerformed", "Logged In successfully"));
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("Error Occured while inserting data in auditlog see log file ofr more info ");
                                GlobalData.LogError("Error Occured while inserting data in auditlog", ex);
                            }
                            string lastloginQuery = "update users set last_login =:lastlogin where user_ID =:userid";
                            try
                            {


                                using (OracleCommand lastLogincmd = new OracleCommand(lastloginQuery, conn))
                                {
                                    lastLogincmd.Parameters.Add(new OracleParameter("lastlogin", DateTime.Now));
                                    lastLogincmd.Parameters.Add(new OracleParameter("userid",GlobalData.CurrentCustomer.userID));
                                    lastLogincmd.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Unable to update your last login timestamp. Your account functionality is unaffected. Please contact support if necessary.");
                                GlobalData.LogError("Failed to update last login timestamp", ex);
                            }
                            string incrementSuccessfulLoginQuery = "UPDATE users SET failedLoginAttempt = 0 WHERE USER_ID = :userId AND ROLE='Customer'";

                            try
                            {
                                using (OracleCommand incrementFailedCmd = new OracleCommand(incrementSuccessfulLoginQuery, conn))
                                {
                                    incrementFailedCmd.Parameters.Add(new OracleParameter("userId", userId));
                                    incrementFailedCmd.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("Error occured while updating customers data see log file for details");
                                GlobalData.LogError("Error occured while updating customers data ",ex);
                            }


                        }


                        else
                        {

                            object result2 = null;
                            int customerId = 0;
                            string userId = null; 
                            string CheckingIfBlocked = "SELECT CUSTOMER_ID FROM USERS WHERE (EMAIL = :email OR USERNAME = :username) AND PASSWORDHASH = :password AND Status ='Blocked' AND ROLE='Customer'";
                            try
                            {
                                using (OracleCommand cmdd = new OracleCommand(CheckingIfBlocked, conn))
                                {
                                    cmdd.Parameters.Add(new OracleParameter("username", username));
                                    cmdd.Parameters.Add(new OracleParameter("email", username));
                                    cmdd.Parameters.Add(new OracleParameter("password", password));
                                    result2= cmdd.ExecuteScalar();
                                }
                                customerId = Convert.ToInt32(result2);
                                userId = "CUS" + customerId;
                                
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error occured while sigingin please see log file for more info"); 
                                GlobalData.LogError("Exception while sigingin ",ex);
                            }

                                if (result2 != null)
                                {
                                    DialogResult res = MessageBox.Show("Your account is Blocked. Please Verify Yourself to access your account.",
                                              "Account Blocked",
                                              MessageBoxButtons.OKCancel,
                                              MessageBoxIcon.Error);

                                int newAuditID = GenerateNewLogID();

                                string insertAuditLogQuery = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                                           "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";
                                try
                                {
                                    using (OracleCommand insertCmd = new OracleCommand(insertAuditLogQuery, conn))
                                    {
                                        insertCmd.Parameters.Add(new OracleParameter("auditLogId", newAuditID));
                                        insertCmd.Parameters.Add(new OracleParameter("userId", userId)); 
                                        insertCmd.Parameters.Add(new OracleParameter("actionPerformed", "Login Restricted Due to Blocked Status"));
                                        insertCmd.ExecuteNonQuery();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error occured while writing audit log for further iinfo check logs file");
                                    GlobalData.LogError("Audit Log writing Error ", ex);
                                }

                                if (res == DialogResult.OK)
                                    {
                                        this.Hide();
                                        ForgotPassword forgotPassword = new ForgotPassword();
                                        MessageBox.Show("You clicked OK. Proceeding with verification.", "Proceeding");
                                        forgotPassword.Show();
                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show("You clicked Cancel. No action will be taken.", "No Action");
                                        return;
                                    }
                                }
                                else { 
                                string userCheckQuery = "SELECT USER_ID, CUSTOMER_ID FROM USERS WHERE EMAIL = :email OR USERNAME = :username AND ROLE='Customer'";
                                userId = null;
                                try
                                {
                                    using (OracleCommand checkCmd = new OracleCommand(userCheckQuery, conn))
                                    {
                                        checkCmd.Parameters.Add(new OracleParameter("email", username));
                                        checkCmd.Parameters.Add(new OracleParameter("username", username));

                                        using (OracleDataReader reader = checkCmd.ExecuteReader())
                                        {
                                            if (reader.Read())
                                            {
                                                userId = reader.GetString(0);
                                            }
                                        }
                                    }
                                    if (userId != null)
                                    {
                                        string fetchEmail = "Select email from users where user_id= : userid";

                                        try
                                        {
                                            using(OracleCommand emailcmd= new OracleCommand(fetchEmail, conn)){
                                                emailcmd.Parameters.Add(new OracleParameter("userid", userId));
                                                using (OracleDataReader reader = emailcmd.ExecuteReader())
                                                {
                                                    if (reader.Read())
                                                    {
                                                        customerEmailFetched = reader.GetString(0);
                                                    }
                                                } 
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                            GlobalData.LogError("Updating user for failed login attempt ", ex);
                                        }


                                        string incrementFailedLoginQuery = "UPDATE users SET failedLoginAttempt = failedLoginAttempt + 1 WHERE USER_ID = :userId";

                                        try
                                        {
                                            using (OracleCommand incrementFailedCmd = new OracleCommand(incrementFailedLoginQuery, conn))
                                            {
                                                incrementFailedCmd.Parameters.Add(new OracleParameter("userId", userId));
                                                incrementFailedCmd.ExecuteNonQuery();
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                            GlobalData.LogError("Updating user for failed login attempt ", ex);
                                        }
                                        int failedLoginAttempt = 0;
                                        string fetchFailedLoginAttemptQuery = "SELECT failedLoginAttempt FROM users WHERE USER_ID = :userId";
                                        try
                                        {
                                            using (OracleCommand fetchFailedCmd = new OracleCommand(fetchFailedLoginAttemptQuery, conn))
                                            {
                                                fetchFailedCmd.Parameters.Add(new OracleParameter("userId", userId));

                                                using (OracleDataReader reader = fetchFailedCmd.ExecuteReader())
                                                {
                                                    if (reader.Read())
                                                    {
                                                        failedLoginAttempt = reader.GetInt32(0);
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Unable to fetch the login attempt count for your account. Please try again or check log file.");
                                            GlobalData.LogError("Failed to fetch failed login attempt count for user", ex);
                                        }

                                        int newAuditID = GenerateNewLogID();
                                        string failedLoginInsertQuery = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                                "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";

                                        try
                                        {
                                            using (OracleCommand insertFailedCmd = new OracleCommand(failedLoginInsertQuery, conn))
                                            {
                                                insertFailedCmd.Parameters.Add(new OracleParameter("auditLogId", newAuditID));
                                                insertFailedCmd.Parameters.Add(new OracleParameter("userId", userId));
                                                insertFailedCmd.Parameters.Add(new OracleParameter("actionPerformed", "Failed login attempt"));
                                                insertFailedCmd.ExecuteNonQuery();

                                                if (failedLoginAttempt >= 3)
                                                {
                                                    MessageBox.Show("Invalid Login Attempt\nYou have zero attempts left.", "Warning");
                                                    NotifyInvalidLoginAttempt(customerEmailFetched);
                                                }
                                                else
                                                {
                                                    NotifyInvalidLoginAttempt(customerEmailFetched);
                                                    MessageBox.Show("Invalid Login Attempt\nYou have only " + (3 - failedLoginAttempt) + " attempts left.", "Warning");
                                                }
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Failed to record the failed login attempt in system logs. Please contact support if this issue persists.");
                                            GlobalData.LogError("Failed to write failed login attempt to Audit Log", ex);
                                        }

                                        if (failedLoginAttempt == 3)
                                        {
                                            string updateStatusQuery = "UPDATE users SET Status = 'Blocked' WHERE USER_ID = :userId";

                                            try
                                            {
                                                using (OracleCommand updateStatusCmd = new OracleCommand(updateStatusQuery, conn))
                                                {
                                                    updateStatusCmd.Parameters.Add(new OracleParameter("userId", userId));
                                                    updateStatusCmd.ExecuteNonQuery();

                                                    int newAuditId = signInpage.GenerateNewLogID();
                                                    string accountBlocked = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                                            "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";

                                                    try
                                                    {
                                                        using (OracleCommand insertFailedCmd = new OracleCommand(accountBlocked, conn))
                                                        {
                                                            insertFailedCmd.Parameters.Add(new OracleParameter("auditLogId", newAuditId));
                                                            insertFailedCmd.Parameters.Add(new OracleParameter("userId", userId));
                                                            insertFailedCmd.Parameters.Add(new OracleParameter("actionPerformed", "Account Blocked Due to Multiple Invalid Attempts"));
                                                            insertFailedCmd.ExecuteNonQuery();
                                                        }

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                       
                                                        MessageBox.Show("Error while inserting in audit logs  please see  log file  for more information");
                                                        GlobalData.LogError("Error while inserting in audit logs ", ex);
                                                    }
                                                    NotifyAccountBlocked(customerEmailFetched, DateTime.Now);

                                                    DialogResult res = MessageBox.Show("Your account Has Been Blocked. Please Verify Yourself.",
                                                   "Account Blocked",
                                                   MessageBoxButtons.OKCancel,
                                                   MessageBoxIcon.Error);
                                                    if (res == DialogResult.OK)
                                                    {
                                                        this.Hide();
                                                        ForgotPassword forgotPassword = new ForgotPassword();
                                                        forgotPassword.Show();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("You clicked Cancel. No action will be taken.", "No Action");
                                                        return;
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {

                                                MessageBox.Show("Unable to block the account after too many failed login attempts. Please contact support for immediate assistance.");
                                                GlobalData.LogError("Failed to update user status to 'Blocked'", ex);
                                            }
                                        }


                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Unable to verify your account's status. Please try again or contact support.");
                                    GlobalData.LogError("Failed to fetch user status for login process", ex);

                                }

                                if (userId == null)
                                {
                                    MessageBox.Show("Invalid email or password. Please try again.");
                                }
                            
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while verifying your account status. Please contact support.");
                    GlobalData.LogError("Failed to process account blocking verification", ex);
                }
            }

        }

        private void ForgetPassword_BTN_SigninpageForm_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();   
            forgotPassword.Show();
        }

        private void Username_txtBox_signinForm_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {
                Passworde_txtBox_signinForm.UseSystemPasswordChar=false;
            }
            else
            {
                Passworde_txtBox_signinForm.UseSystemPasswordChar = true;
            }
        }

        public static int GenerateNewLogID()
        {
            int newAuditID;
            string getMaxLogIDQuery = "SELECT MAX(audit_log_Id) FROM auditlog";
            try
            {
                using (OracleConnection conn = new OracleConnection(GlobalData.connString))
                {
                    conn.Open();
                    using (OracleCommand ocmd = new OracleCommand(getMaxLogIDQuery, conn))
                    {
                        object resultLOGID = ocmd.ExecuteScalar();
                        int maxAuditLogId = (resultLOGID != DBNull.Value) ? Convert.ToInt32(resultLOGID) : 0;
                        newAuditID = maxAuditLogId + 1;

                    }
                }
            }
            catch (Exception ex)
            {
                GlobalData.LogError("Error while generating new Audit Log ID", ex);
                MessageBox.Show("An error occurred while generating a new log ID. Please check log file or try again later.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return newAuditID;
        }


        private void Passworde_txtBox_signinForm_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            EmployeeLoginPage employeeLoginPage = new EmployeeLoginPage();  
            employeeLoginPage.Show();
            this.Hide();
        }

        private void Username_txtBox_signinForm_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if (e.KeyChar == (char)Keys.Enter)
            {
                
                Passworde_txtBox_signinForm.Focus();
                e.Handled = true;
            }
        }

        private void Passworde_txtBox_signinForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SignIn_btn_SigninForm.PerformClick();
                e.Handled = true;
            }
        }
        public void NotifyInvalidLoginAttempt(string customerEmail)
        {
            this.Cursor=Cursors.WaitCursor;
            string from = "AskariDigitalOTP@gmail.com"; 
            string password = "mitxehwlyexurspx"; 
            string emailUsername = "Askari Digital Bank Ltd."; 
            string subject = "Security Alert: Invalid Login Attempt Detected";
            string messageBody = $"Dear Customer,\n\n" +
                                 $"We noticed an invalid login attempt to your account on {DateTime.Now.ToString("f")}.\n" +
                                 $"If this was you, please ensure your credentials are correct.\n" +
                                 $"If this wasn't you, we recommend changing your password immediately to secure your account.\n\n" +
                                 $"For assistance, contact our support team at  AskariDigitalOTP@gmail.com.\n\n" +
                                 "Thank you,\n" +
                                 "The Askari Digital Bank Team";

            MailMessage message = new MailMessage
            {
                From = new MailAddress(from, emailUsername),
                Subject = subject,
                Body = messageBody,
                IsBodyHtml = false
            };

            message.To.Add(customerEmail);

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(from, password)
            };

            try
            {
                smtpClient.Send(message);
             }
            catch (Exception ex)
            {
                GlobalData.LogError("Error Sending Email Plz check log file for more info", ex);
                
            }
            this.Cursor = Cursors.Default;
        }
      
        public void NotifyAccountBlocked(string customerEmail, DateTime blockTime)
        {
            this.Cursor = Cursors.WaitCursor;

            string from = "AskariDigitalOTP@gmail.com"; 
            string password = "mitxehwlyexurspx"; 
            string emailUsername = "Askari Digital Bank Ltd.";
            string subject = "Important: Your Account Has Been Blocked";

            
            string messageBody = $"Dear Customer,\n\n" +
                                 "We have detected multiple invalid login attempts to your account. As a precaution, your account has been temporarily blocked to safeguard your security.\n\n" +
                                 $"Details:\n" +
                                 $"- Account Blocked At: {blockTime.ToString("f")}\n\n" +
                                 "To regain access to your account, please contact our customer support team or follow the account recovery steps on our online banking portal.\n\n" +
                                 "For assistance, contact us at  AskariDigitalOTP@gmail.com.\n\n" +
                                 "Thank you for your understanding and cooperation.\n\n" +
                                 "Best regards,\n" +
                                 "The Askari Digital Bank Team";

            MailMessage message = new MailMessage
            {
                From = new MailAddress(from, emailUsername),
                Subject = subject,
                Body = messageBody,
                IsBodyHtml = false
            };

            message.To.Add(customerEmail);

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(from, password)
            };

            try
            {
                smtpClient.Send(message);
                Console.WriteLine("Account block notification sent successfully.");
            }
            catch (Exception ex)
            {
               
                GlobalData.LogError("Failed to process account blocking notification", ex);
                Console.WriteLine("An error occurred while sending the email: " + ex.Message);
            }
            this.Cursor = Cursors.Default;

        }
    }

}
