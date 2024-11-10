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
            InitializeComponent();
        }

        private void Exit_btn_signinForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                    string query = "SELECT CUSTOMER_ID FROM USERS WHERE (EMAIL = :email OR USERNAME = :username) AND PASSWORDHASH = :password";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("username", username));
                        cmd.Parameters.Add(new OracleParameter("email", username));

                        cmd.Parameters.Add(new OracleParameter("password", password));
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            int customerId = Convert.ToInt32(result);
                            Customer customer = new Customer(customerId);
                            GlobalData.CurrentCustomer = customer;
                            HomePageCustomers homePageCustomers = new HomePageCustomers(customer);
                            this.Hide();
                            homePageCustomers.Show();
                            int newAuditID = 0;

                            string userId = "CUS" + customerId;

                            string getMaxLogIDQuery = "SELECT MAX(audit_log_Id) FROM auditlog";
                            try
                            {
                                using (OracleCommand ocmd = new OracleCommand(getMaxLogIDQuery, conn))
                                {
                                    object resultLOGID = ocmd.ExecuteScalar();
                                    int maxAuditLogId = (resultLOGID != DBNull.Value) ? Convert.ToInt32(resultLOGID) : 0;
                                    newAuditID = maxAuditLogId + 1;

                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

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
                        }
                        else
                        {

                            string userCheckQuery = "SELECT USER_ID, CUSTOMER_ID FROM USERS WHERE EMAIL = :email OR USERNAME = :username";
                            string userId = null;
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
                                            userId = reader.GetString(0); // Fetch the USER_ID if it exists
                                        }
                                    }
                                }
                                if (userId != null)
                                {

                                    int newAuditID = 0;
                                    string getMaxLogIDQuery = "SELECT MAX(audit_log_Id) FROM auditlog";
                                    try
                                    {
                                        using (OracleCommand ocmd = new OracleCommand(getMaxLogIDQuery, conn))
                                        {
                                            object resultLOGID = ocmd.ExecuteScalar();
                                            int maxAuditLogId = (resultLOGID != DBNull.Value) ? Convert.ToInt32(resultLOGID) : 0;
                                            newAuditID = maxAuditLogId + 1;

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }


                                    string failedLoginInsertQuery = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                                    "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";

                                    try
                                    {
                                        using (OracleCommand insertFailedCmd = new OracleCommand(failedLoginInsertQuery, conn))
                                        {
                                            insertFailedCmd.Parameters.Add(new OracleParameter("auditLogId", newAuditID));
                                            insertFailedCmd.Parameters.Add(new OracleParameter("userId", userId)); // Use USER_ID if available, otherwise NULL
                                            insertFailedCmd.Parameters.Add(new OracleParameter("actionPerformed", "Failed login attempt"));
                                            insertFailedCmd.ExecuteNonQuery();

                                            MessageBox.Show("Invalid Login Attempt","Warning");
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


                            //Write a query here if username or email is in data auditlog table should be updated with invalid password unsuccessfull
                            if (userId == null)
                            {
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

        private void Passworde_txtBox_signinForm_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
