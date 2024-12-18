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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
namespace BankingManagementSystem
{
    public partial class UpdatePersonalDetailsForm : Form
    {
        private string randomCode;
        public UpdatePersonalDetailsForm()
        {
            InitializeComponent();

        }

        private void UpdatePersonalDetailsForm_Load(object sender, EventArgs e)
        {
            Usernaem_txtbox_UpdatePersonalINfor_Form.Text = GlobalData.CurrentCustomer.username;
            Email_txtBox_UpdatePersonalINfor_Form.Text = GlobalData.CurrentCustomer.email;
            Address_txtbox_UpdatePersonalINfor_Form.Text = GlobalData.CurrentCustomer.address;
            DOBPicker_UpdatePersonalINfor_Form.Value = DateTime.Parse(GlobalData.CurrentCustomer.dateOfBirth);
            Cnic_maskedtextbox_UpdatePersonalINfor_Form.Text = GlobalData.CurrentCustomer.nationalID;
            ContactNumber_MaskedTextBox_UpdatePersonalINfor_Form.Text = GlobalData.CurrentCustomer.contactNumber;
            Usernaem_txtbox_UpdatePersonalINfor_Form.ReadOnly = true;
            Usernaem_txtbox_UpdatePersonalINfor_Form.ForeColor = Color.Black;
            Cnic_maskedtextbox_UpdatePersonalINfor_Form.ReadOnly = true;
            Cnic_maskedtextbox_UpdatePersonalINfor_Form.ForeColor = Color.Black;
            DOBPicker_UpdatePersonalINfor_Form.Enabled = false;
            Name_txtbox_UpdatePersonalINfor_Form.Text = GlobalData.CurrentCustomer.customerName;
            Name_txtbox_UpdatePersonalINfor_Form.ReadOnly = true;
            Name_txtbox_UpdatePersonalINfor_Form.ForeColor = Color.Black;
            Email_txtBox_UpdatePersonalINfor_Form.ReadOnly = true;
            Email_txtBox_UpdatePersonalINfor_Form.ForeColor = Color.Black;
        }

        private void Logout_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            GlobalData.CurrentCustomer = null;
            signInpage signInpage = new signInpage();
            this.Hide();
            signInpage.Show();
        }
        private void HomePage_Update_personalInfo_btn_Form_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePageCustomers homePageCustomers = new HomePageCustomers(GlobalData.CurrentCustomer);
            homePageCustomers.Show();
        }

        private void Exit_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            GlobalData.customerLogout();
            Application.Exit();
        }

        private void openImageDialogue_UpdatePersonalInfoForm_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void uplaod_photo_updateUSerInfoForm_Click(object sender, EventArgs e)
        {

        }

        private void EmailGenerateOTP_btn_UpdateUserInfoForm_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            String from, pass, messageBody, to, Email_username;
            Random random = new Random();
            Email_username = "Askari Digital Bank Ltd.";
            randomCode = (random.Next(100000, 999999)).ToString();
            MailMessage message = new MailMessage();
            to = (Email_txtBox_UpdatePersonalINfor_Form.Text.ToString());
            from = "AskariDigitalOTP@gmail.com";
            pass = "mitxehwlyexurspx ";
            messageBody = "Your OTP code for Askari Digital Banking is : " + randomCode + " ";
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

        private void Email_txtBox_UpdatePersonalINfor_Form_TextChanged(object sender, EventArgs e)
        {

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

        private void EnterOTP_txtBox_UpdateUserInfoForm_Click(object sender, EventArgs e)
        {
            if (EnterOTP_txtBox_UpdateUserInfoForm.Text == "Enter OTP")
            {
                EnterOTP_txtBox_UpdateUserInfoForm.Text = "";
                EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = System.Drawing.Color.Black; 
            }
        }

        private void EnterOTP_txtBox_UpdateUserInfoForm_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EnterOTP_txtBox_UpdateUserInfoForm.Text))
            {
                EnterOTP_txtBox_UpdateUserInfoForm.Text = "Enter OTP"; 
                EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void Account_Statment_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            this.Cursor=Cursors.WaitCursor;
            BankStatementGenerator.GenerateStatementPDFFull();
        }

        private void Usernaem_txtbox_UpdatePersonalINfor_Form_TextChanged(object sender, EventArgs e)
        {

        }

        private void Update_Btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            string actionPerformed = null; 
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
                        List<string> userUpdateFields = new List<string>();
                        List<OracleParameter> userParams = new List<OracleParameter>();

                        if (!string.IsNullOrWhiteSpace(newPassword))
                        {
                            if (newPassword != confirmPassword)
                            {
                                actionPerformed += "Password ";
                                MessageBox.Show("New password and confirmation do not match.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else if (!IsValidPassword(newPassword))
                            {
                                MessageBox.Show("Password must contain at least one uppercase letter, one digit, one special character, and no spaces.",
                            "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            userUpdateFields.Add("passwordhash = :newPassword");
                            userParams.Add(new OracleParameter("newPassword", newPassword)); 
                        }

                        if (GlobalData.CurrentCustomer.email != Email_txtBox_UpdatePersonalINfor_Form.Text)
                        {
                            userUpdateFields.Add("email = :email");
                            userParams.Add(new OracleParameter("email", Email_txtBox_UpdatePersonalINfor_Form.Text));
                            actionPerformed += "Email ";
                        }
                        List<string> customerUpdateFields = new List<string>();
                        List<OracleParameter> customerParams = new List<OracleParameter>();

                        if (GlobalData.CurrentCustomer.address != Address_txtbox_UpdatePersonalINfor_Form.Text)
                        {
                            customerUpdateFields.Add("address = :address");
                            customerParams.Add(new OracleParameter("address", Address_txtbox_UpdatePersonalINfor_Form.Text));
                            actionPerformed += "Address ";
                        }

                        if (GlobalData.CurrentCustomer.contactNumber != ContactNumber_MaskedTextBox_UpdatePersonalINfor_Form.Text)
                        {
                            customerUpdateFields.Add("contact_number = :contactNumber");
                            customerParams.Add(new OracleParameter("contactNumber", ContactNumber_MaskedTextBox_UpdatePersonalINfor_Form.Text));
                            actionPerformed += "Contact Number";
                        }
                        if (userUpdateFields.Count > 0)
                        {
                            string updateUserQuery = $"UPDATE users SET {string.Join(", ", userUpdateFields)} WHERE user_id = :userID";
                            using (OracleCommand userCmd = new OracleCommand(updateUserQuery, conn))
                            {
                                userParams.Add(new OracleParameter("userID", GlobalData.CurrentCustomer.userID));
                                userCmd.Parameters.AddRange(userParams.ToArray());
                                userCmd.ExecuteNonQuery();
                            }
                        }
                        if (customerUpdateFields.Count > 0)
                        {
                            string updateCustomerQuery = $"UPDATE customers SET {string.Join(", ", customerUpdateFields)} WHERE user_id = :userID";
                            using (OracleCommand customerCmd = new OracleCommand(updateCustomerQuery, conn))
                            {
                                customerParams.Add(new OracleParameter("userID", GlobalData.CurrentCustomer.userID));
                                customerCmd.Parameters.AddRange(customerParams.ToArray());
                                customerCmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        string insertAuditLogQuery = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                                           "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";
                        try
                        {

                            using (OracleCommand insertCmd = new OracleCommand(insertAuditLogQuery, conn))
                            {
                                signInpage signInpage=new signInpage();
                                
                                int newAuditID = signInpage.GenerateNewLogID();
                                insertCmd.Parameters.Add(new OracleParameter("auditLogId", newAuditID));
                                insertCmd.Parameters.Add(new OracleParameter("userId", GlobalData.CurrentCustomer.userID)); // USER_ID as "CUS" + customer_id
                                insertCmd.Parameters.Add(new OracleParameter("actionPerformed", "Updated Personal Information: "+actionPerformed));
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        MessageBox.Show("Your details have been successfully updated.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error updating details: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void TermsAndConditions_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            TermsAndCondition_HomePageUser termsAndCondition_HomePageUser = new TermsAndCondition_HomePageUser();
            termsAndCondition_HomePageUser.Show();
        }

        private void TransactionHistory_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            AllTransactionsTable allTransactionsTable = new AllTransactionsTable();
            allTransactionsTable.Show();
        }

        private void Privacy_And_Security_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            PrivacyAndSecurity privacyAndSecurity = new PrivacyAndSecurity();
            privacyAndSecurity.Show();
            this.Close();
        }

        private void SideLeft_panel_HomePageForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ContactNumber_MaskedTextBox_UpdatePersonalINfor_Form_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void ContactNumber_label_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {

        }

        private void Address_labe_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {

        }

        private void Email_label_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {

        }

        private void DOBPicker_UpdatePersonalINfor_Form_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DateOfBirth_label_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {

        }

        private void Cnic_maskedtextbox_UpdatePersonalINfor_Form_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Cnic_Label_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {

        }

        private void Name_Label_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {

        }

        private void ConfirmPasswod_txtBox__UpdatePersonalINfor_Form_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConfirmPassword_label_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {

        }

        private void NewPassword_txtBox_UpdatePersonalINfor_Form_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewPassword_label_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {

        }

        private void Username_label_UpdatePersonalInfor_Form_Click(object sender, EventArgs e)
        {

        }

        private void CurrentPassword_txtbox_UpdatePersonalINfor_Form_TextChanged(object sender, EventArgs e)
        {

        }

        private void CurrentPassword_Label_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void Email_txtBox_UpdatePersonalINfor_Form_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Address_txtbox_UpdatePersonalINfor_Form_TextChanged(object sender, EventArgs e)
        {

        }

        private void Name_txtbox_UpdatePersonalINfor_Form_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void ProfilePic_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {

        }
    }


}
    

