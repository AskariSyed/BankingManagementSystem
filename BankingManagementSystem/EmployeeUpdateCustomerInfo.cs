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

   
    public partial class EmployeeUpdateCustomerInfo : Form
    {
        private string randomCode=null;
        public EmployeeUpdateCustomerInfo()
        {
            InitializeComponent();
            Name_txtbox_UpdatePersonalINfor_Form.Text = GlobalData.CurrentCustomer.customerName;
            Usernaem_txtbox_UpdatePersonalINfor_Form.Text = GlobalData.CurrentCustomer.username;
            Cnic_maskedtextbox_UpdatePersonalINfor_Form.Text = GlobalData.CurrentCustomer.nationalID;
            ContactNumber_MaskedTextBox_UpdatePersonalINfor_Form.Text = GlobalData.CurrentCustomer.contactNumber;
            Email_txtBox_UpdatePersonalINfor_Form.Text=GlobalData.CurrentCustomer.email;
            DateTime dob = DateTime.Parse(GlobalData.CurrentCustomer.dateOfBirth);
            DOBPicker_UpdatePersonalINfor_Form.Value = dob;
            Address_txtbox_UpdatePersonalINfor_Form.Text=GlobalData.CurrentCustomer.address;
            Usernaem_txtbox_UpdatePersonalINfor_Form.Text = GlobalData.CurrentCustomer.username;
            MessageBox.Show(GlobalData.CurrentCustomer.username);
            if (GlobalData.CurrentCustomer.userStatus == "Active")
            {
                UserStatusRadioBtn.Checked = true;       

            }
            else
            {
                UserStatusRadioBtn.Checked = true;
                MessageBox.Show("Inside InActive");

            }

            if (GlobalData.CustomerAccount.status == Account.statusType.Active)
            {
                accountStatusActiveRadiobutton.Checked = true;
            }
            else
            {
                accountStatusActiveRadiobutton.Checked = false;
            }
        }

        private void EmployeeUpdateCustomerInfo_Load(object sender, EventArgs e)
        {

        }

        private void Update_Btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            string actionPerformed = null;


            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();  
                    OracleTransaction transaction = conn.BeginTransaction();
                    try
                    {
                       
                        List<string> userUpdateFields = new List<string>();
                        List<OracleParameter> userParams = new List<OracleParameter>();
                        if (GlobalData.CurrentCustomer.username != Usernaem_txtbox_UpdatePersonalINfor_Form.Text)
                        {
                            userUpdateFields.Add("username = :username");
                            userParams.Add(new OracleParameter("username", Usernaem_txtbox_UpdatePersonalINfor_Form.Text));
                            actionPerformed += "Username ";
                        }
                        List<string> customerUpdateFields = new List<string>();
                        List<OracleParameter> customerParams = new List<OracleParameter>();

                        if (GlobalData.CurrentCustomer.address != Address_txtbox_UpdatePersonalINfor_Form.Text)
                        {
                            customerUpdateFields.Add("address = :address");
                            customerParams.Add(new OracleParameter("address", Address_txtbox_UpdatePersonalINfor_Form.Text));
                            actionPerformed += "Address ";
                        }

                        if (GlobalData.CurrentCustomer.email != Email_txtBox_UpdatePersonalINfor_Form.Text)
                        {
                            if (randomCode != null)
                            {
                                if (randomCode == EnterOTP_txtBox_UpdateUserInfoForm.Text)
                                {
                                    customerUpdateFields.Add("email = :email");
                                    customerParams.Add(new OracleParameter("email", Email_txtBox_UpdatePersonalINfor_Form.Text));
                                    userUpdateFields.Add("email = :email");
                                    userParams.Add(new OracleParameter("email", Email_txtBox_UpdatePersonalINfor_Form.Text));
                                    actionPerformed += "Email ";
                                }
                                else
                                {
                                    MessageBox.Show("Invalid OTP");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please Verify Email using Otp");
                                return;
                            }
                        }
                        DateTime dob = DOBPicker_UpdatePersonalINfor_Form.Value;
                        string dobFormatted = dob.ToString("yyyy-MM-dd");
                        if (GlobalData.CurrentCustomer.dateOfBirth != DOBPicker_UpdatePersonalINfor_Form.Value.ToString())
                        {
                            customerUpdateFields.Add("Date_OF_BIRTH = :dateOfBirth");
                            customerParams.Add(new OracleParameter("dateOfBirth",dobFormatted));
                            actionPerformed += "Date OF Birth ";
                        }
                        if (GlobalData.CurrentCustomer.customerName != Name_txtbox_UpdatePersonalINfor_Form.Text)
                        {
                            customerUpdateFields.Add("NAME = :name");
                            customerParams.Add(new OracleParameter("name", Name_txtbox_UpdatePersonalINfor_Form.Text));
                            actionPerformed += "Name ";
                        }
                        if (GlobalData.CurrentCustomer.nationalID != Cnic_maskedtextbox_UpdatePersonalINfor_Form.Text)
                        {
                            customerUpdateFields.Add("NATIONAL_ID = :cnic ");
                            customerParams.Add(new OracleParameter("cnic", Cnic_maskedtextbox_UpdatePersonalINfor_Form.Text));
                            actionPerformed += "National ID ";
                        }
                        if (GlobalData.CurrentCustomer.contactNumber != ContactNumber_MaskedTextBox_UpdatePersonalINfor_Form.Text)
                        {
                            customerUpdateFields.Add("contact_number = :contactNumber");
                            customerParams.Add(new OracleParameter("contactNumber", ContactNumber_MaskedTextBox_UpdatePersonalINfor_Form.Text));
                            actionPerformed += "Contact Number ";
                        }
                        if ((UserStatusRadioBtn.Checked && GlobalData.CurrentCustomer.userStatus != "Active") ||
                            (!UserStatusRadioBtn.Checked && GlobalData.CurrentCustomer.userStatus != "Blocked"))
                        {
                            userUpdateFields.Add("status = :userStatus");
                            userParams.Add(new OracleParameter("userStatus", UserStatusRadioBtn.Checked ? "Active" : "Blocked"));
                            actionPerformed += "User Status ";
                        }

                        List<string> customerAccountUpdateFields = new List<string>();
                        List<OracleParameter> customerAccountParams = new List<OracleParameter>();

                        if ((accountStatusActiveRadiobutton.Checked && GlobalData.CustomerAccount.status != Account.statusType.Active) ||
                            (!accountStatusActiveRadiobutton.Checked && GlobalData.CustomerAccount.status != Account.statusType.Blocked))
                        {
                            customerAccountUpdateFields.Add("status = :accountStatus");
                            customerAccountParams.Add(new OracleParameter("accountStatus", accountStatusActiveRadiobutton.Checked ? "Active" : "Blocked"));
                            actionPerformed += "Account Status ";
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
                        if (customerAccountParams.Count > 0)
                        {
                            string updateCustomerQuery = $"UPDATE account SET {string.Join(", ", customerAccountUpdateFields)} WHERE account_id = :accountid";
                            using (OracleCommand customerCmd = new OracleCommand(updateCustomerQuery, conn))
                            {
                                customerParams.Add(new OracleParameter("accountid", GlobalData.CustomerAccount.accountId));
                                customerCmd.Parameters.AddRange(customerAccountParams.ToArray());
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
                                signInpage signInpage = new signInpage();

                                int newAuditID = signInpage.GenerateNewLogID();
                                insertCmd.Parameters.Add(new OracleParameter("auditLogId", newAuditID));
                                insertCmd.Parameters.Add(new OracleParameter("userId", GlobalData.CurrentCustomer.userID));
                                insertCmd.Parameters.Add(new OracleParameter("actionPerformed", "Updated Personal Information: " + actionPerformed));
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        MessageBox.Show("Your details have been successfully updated.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
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

        private void accountStatusActiveRadiobutton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void NewEmailGenerateOTP_btn_UpdateUserInfoForm_Click(object sender, EventArgs e)
        {
            if (GlobalData.CurrentCustomer.email == Email_txtBox_UpdatePersonalINfor_Form.Text)
            {
                MessageBox.Show("No need to verify email");
                return;
            }
            else
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
                    GlobalData.customizedPopup("Code Sent Successfully");
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Unable to Send Email OTP please check Log file for more information");
                    GlobalData.LogError("Email sending OTP failed", ex);
                }
            }
        }

        private void Usernaem_txtbox_UpdatePersonalINfor_Form_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserStatusRadioBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Update_AccountInfo_HomePageUserForm_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "ManagerHomePage") 
                {
                    form.BringToFront();  
                    form.Focus();  
                }
            }
            this.Close();
        }
    }
}
