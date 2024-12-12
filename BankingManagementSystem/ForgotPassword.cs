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
using System.Security;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using System.Linq.Expressions;

namespace BankingManagementSystem
{
    public partial class ForgotPassword : Form
    {
        String EmailrandomCode=null;
        public ForgotPassword()
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

        private void Exit_btn__ForgotPasswrod_Form_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void Generate_OTP_Email_Btn_ForgotPasswrod_Form_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            String from, pass, messageBody, to, Email_username;
            Random random = new Random();
            Email_username = "Askari Digital Bank Ltd.";
            EmailrandomCode = (random.Next(100000, 999999)).ToString();
            MailMessage message = new MailMessage();
            to = (Email_txtBOx_ForgotPasswrod_Form.Text.ToString());
            from = "AskariDigitalOTP@gmail.com";
            pass = "mitxehwlyexurspx ";
            messageBody = "Your OTP code for Askari Digital Banking is : " + EmailrandomCode + " ";
            try
            {
                message.To.Add(to);
            }
            catch (Exception eee)
            {

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
                MessageBox.Show(ex.Message);
            }
        }

        private void Email_OTP_textBox_ForgotPAssword_Form_TextChanged(object sender, EventArgs e)
        {

            if (Email_OTP_textBox_ForgotPAssword_Form.Text.Length == 6)
            {
                if (Email_OTP_textBox_ForgotPAssword_Form.Text.ToString() == EmailrandomCode)
                {
                    Email_OTP_textBox_ForgotPAssword_Form.ForeColor = Color.Green;
                    Password_txtBox_ForgetUpForm.Enabled = true;    
                    ConfirmPassword_txtbox_FrgotpasswordPage.Enabled = true;
                }
                else
                {
                    Email_OTP_textBox_ForgotPAssword_Form.ForeColor = Color.Red;
                }

            }
            else
            {
                Email_OTP_textBox_ForgotPAssword_Form.ForeColor = Color.Black;
            }

        }

        private void Email_OTP_textBox_ForgotPAssword_Form_Click(object sender, EventArgs e)
        {
            if (Email_OTP_textBox_ForgotPAssword_Form.Text == "Enter OTP")
            {
                Email_OTP_textBox_ForgotPAssword_Form.Text = "";
                Email_OTP_textBox_ForgotPAssword_Form.ForeColor = System.Drawing.Color.Black; 
            }

        }

        private void Email_OTP_textBox_ForgotPAssword_Form_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Email_OTP_textBox_ForgotPAssword_Form.Text))
            {
                Email_OTP_textBox_ForgotPAssword_Form.Text = "Enter OTP";
                Email_OTP_textBox_ForgotPAssword_Form.ForeColor = System.Drawing.Color.Gray; 
            }

        }

        private void Generate_OTP_Phone_Btn_ForgotPasswrod_Form_Click(object sender, EventArgs e)
        {

        }

        private void Save_Password_BTN__ForgotPasswrod_Form_Click(object sender, EventArgs e)
        {


            string email = Email_txtBOx_ForgotPasswrod_Form.Text;
            string username = Username_txtBox_ForgotPasswordForm.Text;
            string phoneNumber = s.Text;
            string newPassword = Password_txtBox_ForgetUpForm.Text;
            string confirmPassword = ConfirmPassword_txtbox_FrgotpasswordPage.Text;

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                return;
            }
            if (EmailrandomCode == Email_OTP_textBox_ForgotPAssword_Form.Text)
            {
                using (OracleConnection conn = new OracleConnection(GlobalData.connString))
                {
                    try
                    {
                        conn.Open();
                        string query = @"SELECT u.CUSTOMER_ID
                             FROM USERS u
                             JOIN CUSTOMERS c ON u.CUSTOMER_ID = c.CUSTOMER_ID
                             WHERE u.EMAIL = :email AND u.USERNAME = :username AND c.Contact_number = :phoneNumber";

                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.Parameters.Add(new OracleParameter("email", email));
                            cmd.Parameters.Add(new OracleParameter("username", username));
                            cmd.Parameters.Add(new OracleParameter("phoneNumber", phoneNumber));

                            object result = cmd.ExecuteScalar();

                            if (result != null)
                            {
                                int customerId = Convert.ToInt32(result);
                                string passwordHash = newPassword;

                                string updateQuery = "UPDATE USERS SET PASSWORDHASH = :passwordHash WHERE CUSTOMER_ID = :customerId";
                                using (OracleCommand updateCmd = new OracleCommand(updateQuery, conn))
                                {
                                    updateCmd.Parameters.Add(new OracleParameter("passwordHash", passwordHash));
                                    updateCmd.Parameters.Add(new OracleParameter("customerId", customerId));
                                    int rowsUpdated = updateCmd.ExecuteNonQuery();


                                    string userId = "CUS" + customerId;
                                    if (rowsUpdated > 0)
                                    {
                                        signInpage signInpage = new signInpage();

                                        int newAuditID=signInpage.GenerateNewLogID();
                                        string failedLoginInsertQuery = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                               "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";

                                        try
                                        {
                                            using (OracleCommand insertFailedCmd = new OracleCommand(failedLoginInsertQuery, conn))
                                            {
                                                insertFailedCmd.Parameters.Add(new OracleParameter("auditLogId", newAuditID));
                                                insertFailedCmd.Parameters.Add(new OracleParameter("userId", userId));
                                                insertFailedCmd.Parameters.Add(new OracleParameter("actionPerformed", "Password Changed"));
                                                insertFailedCmd.ExecuteNonQuery();
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }


                                        MessageBox.Show("Password reset successful! Please log in with your new password.");





                                        this.Hide();
                                        signInpage.Show();

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


                                        //if (failedLoginAttempt > 0 )
                                        //{
                                        //    string updateStatusQuery = "UPDATE users SET Status = 'Active' WHERE USER_ID = :userId";

                                        //    try
                                        //    {
                                        //        using (OracleCommand updateStatusCmd = new OracleCommand(updateStatusQuery, conn))
                                        //        {
                                        //            updateStatusCmd.Parameters.Add(new OracleParameter("userId", userId));
                                        //            updateStatusCmd.ExecuteNonQuery();
                                        //        }
                                        //    }
                                        //    catch (Exception ex)
                                        //    {
                                        //        MessageBox.Show($"An error occurred: {ex.Message}");
                                        //    }

                                        //}

                                        string incrementSuccessfulLoginQuery = "UPDATE users SET failedLoginAttempt = 0,Status='Active' WHERE USER_ID = :userId";

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
                                        MessageBox.Show("An error occurred while updating the password. Please try again.");
                                    }

                                }
                            }
                            else
                            {
                                MessageBox.Show("No account found with the provided details. Please check your information and try again.");
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }else if (EmailrandomCode== null)
            {
                MessageBox.Show("Please Verify the Email :");
                return;
            }
            else if (EmailrandomCode != Email_OTP_textBox_ForgotPAssword_Form.Text)
            {
                MessageBox.Show("Invalid OTP");
                return;
            }
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Username_Label_ForgOPasswordForm_Click(object sender, EventArgs e)
        {

        }

        private void Username_txtBox_ForgotPasswordForm_TextChanged(object sender, EventArgs e)
        {

        }

        private void PhoneNmber_Label_ForgOPasswordForm_Click(object sender, EventArgs e)
        {

        }

        private void Email_txtBOx_ForgotPasswrod_Form_TextChanged(object sender, EventArgs e)
        {

        }

        private void Email_Label_ForgOPasswordForm_Click(object sender, EventArgs e)
        {

        }

        private void ConfirmPassword_txtbox_FrgotpasswordPage_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Password_txtBox_ForgetUpForm_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_label_signUpForm_Click(object sender, EventArgs e)
        {

        }

        private void s_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
