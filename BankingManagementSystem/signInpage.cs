using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BankingManagementSystem
{
    public partial class signInpage : Form
    {
        public signInpage()
        {
            CheckCustomerDetail checkCustomerDetail = new CheckCustomerDetail();
            checkCustomerDetail.Show();
            InitializeComponent();
            this.Paint += new PaintEventHandler(SiginPage_Paint);

        }

        private void Exit_btn_signinForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void SiginPage_Paint(object sender, PaintEventArgs e)
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

            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT CUSTOMER_ID FROM USERS WHERE (EMAIL = :email OR USERNAME = :username) AND PASSWORDHASH = :password AND Status ='Active'";
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
                            this.Hide();
                            homePageCustomers.Show();
                            

                            string userId = "CUS" + customerId;

                          

                            int newAuditID = GenerateNewLogID();

                            string insertAuditLogQuery = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                                            "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";
                            try
                            {
                                using (OracleCommand insertCmd = new OracleCommand(insertAuditLogQuery, conn))
                                {
                                    insertCmd.Parameters.Add(new OracleParameter("auditLogId", newAuditID));
                                    insertCmd.Parameters.Add(new OracleParameter("userId", userId)); // USER_ID as "CUS" + customer_id
                                    insertCmd.Parameters.Add(new OracleParameter("actionPerformed", "Logged In successfully"));
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            string incrementSuccessfulLoginQuery = "UPDATE users SET failedLoginAttempt = 0 WHERE USER_ID = :userId";

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
                                MessageBox.Show(ex.Message);
                            }


                        }


                        else
                        {
                            object result2 = null;
                            int customerId = 0;
                            string userId = null; 
                            string CheckingIfBlocked = "SELECT CUSTOMER_ID FROM USERS WHERE (EMAIL = :email OR USERNAME = :username) AND PASSWORDHASH = :password AND Status ='Blocked'";
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
                                MessageBox.Show("userid = " + userId);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);    

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
                                        insertCmd.Parameters.Add(new OracleParameter("userId", userId)); // USER_ID as "CUS" + customer_id
                                        insertCmd.Parameters.Add(new OracleParameter("actionPerformed", "Login Restricted Due to Blocked Status"));
                                        insertCmd.ExecuteNonQuery();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
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
                                string userCheckQuery = "SELECT USER_ID, CUSTOMER_ID FROM USERS WHERE EMAIL = :email OR USERNAME = :username";
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
                                            MessageBox.Show(ex.Message);
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
                                                MessageBox.Show(ex.Message);
                                            }
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
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Invalid Login Attempt\nYou have only " + (3 - failedLoginAttempt) + " attempts left.", "Warning");
                                                }
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
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
                    MessageBox.Show($"An error occurred: {ex.Message}");
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
                MessageBox.Show(ex.Message);
                return 0;
            }
            return newAuditID;
        }


        private void Passworde_txtBox_signinForm_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
