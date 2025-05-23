﻿using System;
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
    public partial class PrivacyAndSecurity : Form
    {
        public PrivacyAndSecurity()
        {
            InitializeComponent();




            Email_txtBox_Privacy_Form.Text = GlobalData.CurrentCustomer.email;
            Email_txtBox_Privacy_Form.Enabled = false;



            if (CanViewAuditLog())
            {
                loadRecentActivity();
                if (RecentActivitiesGridView.Rows.Count > 0)
                {
                    NoAccessImage.Visible = false;
                    RecentActivitiesGridView.Visible = true;
                }
                else
                {
                    RecentActivitiesGridView.Visible = false;
                }


            }
            else
            {
                NoAccessImage.Visible = true;
                    RecentActivitiesGridView.Visible = false;

            }

          
        }


        private Boolean CanViewAuditLog()
        {
            string checkAccess = "SELECT COUNT(*) FROM DBA_TAB_PRIVS WHERE GRANTEE = 'C##CUSTOMER1' AND TABLE_NAME = 'AUDITLOG' AND PRIVILEGE = 'SELECT'";
            try
            {
                using (OracleConnection conn = new OracleConnection(GlobalData.connString))
                {
                    conn.Open();
                    using (OracleCommand ocmd = new OracleCommand(checkAccess, conn))
                    {
                        
                        object result = ocmd.ExecuteScalar();
                        if (result != DBNull.Value && Convert.ToInt32(result) > 0)
                        {
                            return true; 
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalData.LogError("Error while checking access to AuditLog", ex);
                MessageBox.Show("An error occurred while checking access. Please check the log file or try again later.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }
        }

        private void paint(object sender, PaintEventArgs e)
        {
         
            int borderWidth = 5;
            Color borderColor = Color.FromArgb(255, 191, 0);
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
        string randomCode = "-1";

        private void RecentActivitiesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ChangePassword_PrivacyAndSecurityBTN_Form_Click(object sender, EventArgs e)
        {
            if (randomCode == "-1")
            {
                MessageBox.Show("Please Verify Your Email First", "Verification Needed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EnterOTP_txtBox_UpdateUserInfoForm.Text != randomCode)
            {
                MessageBox.Show("Invalid OTP. Please enter the correct OTP.", "OTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string currentPassword = CurrentPassword_txtbox_UpdatePersonalINfor_Form.Text;
            string newPassword = NewPassword_txtBox_UpdatePersonalINfor_Form.Text;
            string confirmPassword = ConfirmPasswod_txtBox__UpdatePersonalINfor_Form.Text;
            if (string.IsNullOrWhiteSpace(currentPassword))
            {
                MessageBox.Show("Please enter your current password.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string storedPasswordHash = null;
            string selectQuery = "SELECT passwordhash FROM users WHERE user_id = :userID";

            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(selectQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("userID", GlobalData.CurrentCustomer.userID));
                        storedPasswordHash = Convert.ToString(cmd.ExecuteScalar());
                    }

                    if (storedPasswordHash != currentPassword)
                    {
                        MessageBox.Show("Current password is incorrect.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    OracleTransaction transaction = conn.BeginTransaction();
                    try
                    { 
                        if (!string.IsNullOrWhiteSpace(newPassword))
                        {
                            if (newPassword != confirmPassword)
                            {
                                MessageBox.Show("New password and confirmation do not match.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else if (!IsValidPassword(newPassword))
                            {
                                MessageBox.Show("Password must contain at least one uppercase letter, one digit, one special character, and no spaces.",
                            "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        {
                            string updateUserQuery = $"UPDATE users SET passwordhash =:password WHERE user_id = :userID";
                            using (OracleCommand userCmd = new OracleCommand(updateUserQuery, conn))
                            {

                                userCmd.Parameters.Add(new OracleParameter("password", newPassword));
                                userCmd.Parameters.Add(new OracleParameter("userID", GlobalData.CurrentCustomer.userID));
                                userCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        string insertAuditLogQuery = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                                           "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";
                        signInpage signInpage = new signInpage();
                        try
                        {

                            using (OracleCommand insertCmd = new OracleCommand(insertAuditLogQuery, conn))
                            {
                            

                                int newAuditID = signInpage.GenerateNewLogID();
                                insertCmd.Parameters.Add(new OracleParameter("auditLogId", newAuditID));
                                insertCmd.Parameters.Add(new OracleParameter("userId", GlobalData.CurrentCustomer.userID));
                                insertCmd.Parameters.Add(new OracleParameter("actionPerformed", "Password Changed Successfully "));
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while inserting in audit logs please see log file for more information");
                            GlobalData.LogError("Error while inserting in audit logs ", ex);
                        }
                        MessageBox.Show("Your Password have been successfully changed ", "Update Password Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalData.customizedPopup("Please Login Again");
                        GlobalData.customerLogout();
                        this.Hide();
                        signInpage.Show();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error updating details please see  log file  for more information");
                        GlobalData.LogError("Error updating details ", ex);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Database connection error please see  log file  for more information");
                    GlobalData.LogError("Database connection error ", ex);
                }
            }
        }
        public bool IsValidPassword(string input)
        {
            bool hasCapital = input.Any(char.IsUpper);
            bool hasDigit = input.Any(char.IsDigit);
            bool hasSpecial = input.Any(c => !char.IsLetterOrDigit(c));
            bool hasNoSpace = !input.Contains(" ");

            return hasCapital && hasDigit && hasSpecial && hasNoSpace;
        }

        private void EmailGenerateOTP_btn_PrivacyForm_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            String from, pass, messageBody, to, Email_username;
            Random random = new Random();
            Email_username = "Askari Digital Bank Ltd.";
            randomCode = (random.Next(100000, 999999)).ToString();
            MailMessage message = new MailMessage();
            to = (Email_txtBox_Privacy_Form.Text.ToString());
            from = "AskariDigitalOTP@gmail.com";
            pass = GlobalData.password;
            messageBody = "Your OTP code for Askari Digital Banking is : " + randomCode + " ";
            try
            {
                message.To.Add(to);
            }
            catch (Exception eee)
            {
                GlobalData.LogError("Error while sending email:", eee);

            }
            message.From = new MailAddress(from, Email_username);
            message.Body = messageBody;
            message.Subject = "Digital On Boarding Askari Digital OTP";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.Port = 587;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtpClient.Send(message);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Code Sent Successfully");
            }
            catch (Exception ex)
            {

                this.Cursor = Cursors.Default;
            
                MessageBox.Show("Error sending email please see  log file  for more information");
                GlobalData.LogError("Error sending email ", ex);
            }
        }

        private void Email_txtBox_Privacy_Form_TextChanged(object sender, EventArgs e)
        {

        }
        private void loadRecentActivity()
        {
            string query = @"SELECT * FROM auditlog
                     WHERE user_id = :userID 
                     ORDER BY Action_date DESC 
                     FETCH FIRST 3 ROWS ONLY";
            using (OracleConnection conn = new OracleConnection(GlobalData.CustomerconnString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("user_id", GlobalData.CurrentCustomer.userID));
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            RecentActivitiesGridView.Rows.Clear();

                            if (!reader.HasRows)
                            {
                                RecentActivitiesGridView.Hide();
                            }

                            while (reader.Read())
                            {
                                DataGridViewRow row = new DataGridViewRow();
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["Audit_log_id"] });
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["Action_performed"] });
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["action_date"] });
                                RecentActivitiesGridView.Rows.Add(row);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    
                    MessageBox.Show("Error while fetching audit logs for custoemr pelase check log file for more information");
                    GlobalData.LogError("Error while fetching audit logs ",ex);
                }
            }
        }

        private void Exit_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            GlobalData.customerLogout();
                Application.Exit();

            
        }

        private void TransactionHistory_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            AllTransactionsTable allTransactionsTable = new AllTransactionsTable();
            this.Hide();
            allTransactionsTable.Show();
        }

        private void Privacy_And_Security_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {

        }

        private void Account_Statment_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            BankStatementGenerator.GenerateStatementPDFFull();
        }

        private void TermsAndConditions_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
         
            TermsAndCondition_HomePageUser termsAndCondition_HomePageUser = new TermsAndCondition_HomePageUser();
            termsAndCondition_HomePageUser.Show();
        }

        private void Logout_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            GlobalData.customerLogout();
            signInpage signInpage=new signInpage();
            signInpage.Show();
            this.Close();
        }

        private void EnterOTP_txtBox_UpdateUserInfoForm_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EnterOTP_txtBox_UpdateUserInfoForm.Text))
            {
                EnterOTP_txtBox_UpdateUserInfoForm.Text = "Enter OTP";
                EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void EnterOTP_txtBox_UpdateUserInfoForm_MouseEnter(object sender, EventArgs e)
        {
            if (EnterOTP_txtBox_UpdateUserInfoForm.Text == "Enter OTP")
            {
                EnterOTP_txtBox_UpdateUserInfoForm.Text = "";
                EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void EnterOTP_txtBox_UpdateUserInfoForm_TextChanged(object sender, EventArgs e)
        {
            if (EnterOTP_txtBox_UpdateUserInfoForm.Text.Length == 6)
            {
                if (EnterOTP_txtBox_UpdateUserInfoForm.Text.ToString() == randomCode)
                {
                    EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = Color.Green;
                }
                else
                {
                    EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = Color.Red;
                }
            }
            else
            {
                EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = Color.Black;
            }
        }

        private void HomePage_Update_personalInfo_btn_Form_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "HomePageCustomers")
                {
                    form.BringToFront();
                    form.Focus();
                    this.Close();
                    return;
                }
            }
            HomePageCustomers homePageCustomers = new HomePageCustomers();
            homePageCustomers.Show();
            this.Close();
        }

        private void sendMoneyBtn_Click(object sender, EventArgs e)
        {
            SendMoney sendMoney = new SendMoney();  
            sendMoney.Show();
            this.Close();
        }

        private void PrivacyAndSecurity_Load(object sender, EventArgs e)
        {

        }

        private void EnterOTP_txtBox_UpdateUserInfoForm_Click(object sender, EventArgs e)
        {

        }

        private void NoAccessImage_Click(object sender, EventArgs e)
        {

        }
    }
}

