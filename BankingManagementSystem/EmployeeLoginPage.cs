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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace BankingManagementSystem
{
    public partial class EmployeeLoginPage : Form
    {
        public EmployeeLoginPage()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(EmployeeLogin_Paint);
        }

        private void EmployeeLogin_Paint(object sender, PaintEventArgs e)
        {

            int borderWidth = 7;
            Color borderColor = Color.FromArgb(255, 191, 0);
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
        private void SignIn_btn_EmployeeSigninForm_Click(object sender, EventArgs e)
        {
            string username = Username_txtBox_EmployeesigninForm.Text;
            string password = Passworde_txtBox_EmployeesigninForm.Text;


            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT user_id FROM users WHERE (EMAIL = :email OR USERNAME = :username) AND PASSWORDHASH = :password AND Status ='Active' AND ROLE='Employee'";
                  using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("username", username));
                        cmd.Parameters.Add(new OracleParameter("email", username));

                        cmd.Parameters.Add(new OracleParameter("password", password));
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            string user_Id = Convert.ToString(result);

                            Employee employee = new Employee(user_Id);
                            GlobalData.CurrentEmployee = employee;
                            if (employee.position == Employee.Position.Teller||employee.position==Employee.Position.Other)
                            {
                                tellerHomePage tellerHome = new tellerHomePage();
                                tellerHome.Show();
                            }
                            else if(employee.position == Employee.Position.Manager)
                            {
                                ManagerHomePage managerHomePage = new ManagerHomePage();
                                managerHomePage.Show();

                            }
        
                               this.Hide();
           
                               GlobalData.customizedPopup("Signin Successfull");

           



                          int newAuditID = signInpage.GenerateNewLogID();

                           string insertAuditLogQuery = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                                         "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";
                            try
                            {
                                using (OracleCommand insertCmd = new OracleCommand(insertAuditLogQuery, conn))
                                {
                                    insertCmd.Parameters.Add(new OracleParameter("auditLogId", newAuditID));
                                    insertCmd.Parameters.Add(new OracleParameter("userId", GlobalData.CurrentEmployee.userId)); 
                                    insertCmd.Parameters.Add(new OracleParameter("actionPerformed", "Logged In successfully"));
                                    insertCmd.ExecuteNonQuery();
                                }
                           }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            string lastloginQuery = "update users set last_login =:lastlogin where user_ID =:userid";
                            try
                            {

                                using (OracleCommand lastLogincmd = new OracleCommand(lastloginQuery, conn))
                                {
                                    lastLogincmd.Parameters.Add(new OracleParameter("lastlogin", DateTime.Now));
                                    lastLogincmd.Parameters.Add(new OracleParameter("userid", GlobalData.CurrentEmployee.userId));
                                    lastLogincmd.ExecuteNonQuery();
                                }
                            }catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            string incrementSuccessfulLoginQuery = "UPDATE users SET failedLoginAttempt = 0 WHERE USER_ID = :userId";

                            try
                            {
                                using (OracleCommand incrementFailedCmd = new OracleCommand(incrementSuccessfulLoginQuery, conn))
                                {
                                    incrementFailedCmd.Parameters.Add(new OracleParameter("userId", GlobalData.CurrentEmployee.userId));
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
                            int employeeId = 0;
                            string userId = null;
                            string CheckingIfBlocked = "SELECT employee_id FROM USERS WHERE (EMAIL = :email OR USERNAME = :username) AND PASSWORDHASH = :password AND Status ='Blocked' AND ROLE='Employee'";
                            try
                            {
                                using (OracleCommand cmdd = new OracleCommand(CheckingIfBlocked, conn))
                                {
                                    cmdd.Parameters.Add(new OracleParameter("username", username));
                                    cmdd.Parameters.Add(new OracleParameter("email", username));
                                    cmdd.Parameters.Add(new OracleParameter("password", password));
                                   result2 = cmdd.ExecuteScalar();
                                }
                                employeeId = Convert.ToInt32(result2);
                                userId = "EMP" + employeeId;
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

                                int newAuditID = signInpage.GenerateNewLogID();

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
                                    MessageBox.Show(ex.Message);
                                }

                                if (res == DialogResult.OK)
                                {
                                    this.Hide();
                                    ForgotPassword forgotPassword = new ForgotPassword();
                                    MessageBox.Show("You clicked OK. Proceeding with verification.", "Proceeding");
                                    EmployeeForgotPassword emp = new EmployeeForgotPassword();
                                    emp.Show();
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("You clicked Cancel. No action will be taken.", "No Action");
                                    return;
                                }
                            }
                            else
                            {
                                string userCheckQuery = "SELECT USER_ID, CUSTOMER_ID FROM USERS WHERE (EMAIL = :email OR USERNAME = :username) AND ROLE='Employee'";
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



                                        string incrementFailedLoginQuery = "UPDATE users SET failedLoginAttempt = failedLoginAttempt + 1 WHERE USER_ID = :userId AND ROLE='Employee'";

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
                                        string fetchFailedLoginAttemptQuery = "SELECT failedLoginAttempt FROM users WHERE USER_ID = :userId AND ROLE='Employee'";
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

                                        int newAuditID = signInpage.GenerateNewLogID();
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
                                                        EmployeeForgotPassword forgotPassword = new EmployeeForgotPassword();
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
                                                MessageBox.Show(ex.Message);
                                            }
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

        private void CustomerLoginButton_Employeloginpage_Click(object sender, EventArgs e)
        {
            this.Close();
            signInpage sign = new signInpage();
            sign.Show();
        }

        private void EmployeeLoginPage_Load(object sender, EventArgs e)
        {

        }

        private void EmployeeShowPasswrodButton_CheckedChanged(object sender, EventArgs e)
        {

            if (EmployeeShowPasswrodButton.Checked)
            {
                Passworde_txtBox_EmployeesigninForm.UseSystemPasswordChar = false;
            }
            else
            {
                Passworde_txtBox_EmployeesigninForm.UseSystemPasswordChar = true;
            }
        }

        private void Exit_btn_signinForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Passworde_txtBox_EmployeesigninForm_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                SignIn_btn_EmployeeSigninForm.PerformClick();
                e.Handled = true;
            }
        }

        private void Username_txtBox_EmployeesigninForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                Passworde_txtBox_EmployeesigninForm.Focus();
                e.Handled = true;
            }

        }

        private void ForgetPassword_BTN_EmployeeSigninpageForm_Click(object sender, EventArgs e)
        {
            EmployeeForgotPassword employeeForgotPassword = new EmployeeForgotPassword();
            employeeForgotPassword.Show(); 
        }
    }
}
