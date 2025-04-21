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
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace BankingManagementSystem
{
  
    public partial class SearchCustomerForUpdate : Form
    {
        private string randomCode;
        public SearchCustomerForUpdate()
        {
            InitializeComponent(); AccountStatus_Detail_CheckCustomer.Visible = false;
            AccountStatus_Detail_CheckCustomer.Visible = false;
            AccountStatus_label_CheckCustomer.Visible = false;
            AC_Title_Detail_CheckCustomerForm.Visible = false;
            AccountTitle_Label_CheckCustomer.Visible = false;
            cnic_detail_label_CheckCustomer.Visible = false;
            CNIC_Label_CheckCustomer.Visible = false;
            AC_NO_Detail_CheckCustomerForm.Visible = false;
            AccountNumber_Label_checkCustomer.Visible = false;
            DateOfBirth_Detail_CheckCustomer.Visible = false;
            DateOfBirth_Label_CheckCustomer.Visible = false;
            DateOpened_Detail_CheckCustomer.Visible = false;
            DateOfBirth_Label_CheckCustomer.Visible = false;
            Available_Balance_Detail_CheckCustomerForm.Visible = false;
            Available_Balance_Label_CheckCustomer.Visible = false;
            Account_type_Detail_labelCheckCustomerForm.Visible = false;
            Account_type_label_CheckCustomerForm.Visible = false;
            Branchaname_Detail_CheckCustomer.Visible = false;
            Branchaname_label_CheckCustomer.Visible = false;
            UpdateCustomerInformation_Button.Visible = false;
            DateOpened_Label_CheckCustomer.Visible = false;
            BlockageDescription_Label_CheckCustomer.Visible = false;
            BlockageDescription_Detail_CheckCustomer.Visible = false;
            onlineUserStatusLabelCheckCustomer.Visible = false;
            OnlineUserStatusDetailCheckCustomer.Visible = false;
            EmailGenerateOTP_btn_UpdateUserInfoForm.Visible = false;
            EnterOTP_txtBox_UpdateUserInfoForm.Visible=false;
            EmailDetailLabel.Visible = false;
            EmailLabel.Visible=false;
            
           
            this.Paint += new PaintEventHandler(CheckCustomer_Paint);

        }
        private void CheckCustomer_Paint(object sender, PaintEventArgs e)
        {
           
            int borderWidth = 5;
            Color borderColor = Color.FromArgb(255, 191, 0);

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void SearchByName_BTN_Click(object sender, EventArgs e)
        {
            populateCustomer("Name", AttributeTxtBox.Text, "customers");
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
            populateCustomer("NATIONAL_ID", formattedValue, "customers");

        }

        private void SearchByAccountNumber_btn_Click(object sender, EventArgs e)
        {
            if (AttributeTxtBox.Text.Length == 10)
            {
                populateCustomer("ACCOUNT_ID", AttributeTxtBox.Text, "ACCOUNT");
            }
            else
            {
                MessageBox.Show("Please Enter a Valid 10 Digit Account Number ");
                return;
            }
        }



        private void populateCustomer(string attribute, string value, string table)
        {
            string query = $"SELECT customer_id FROM {table} WHERE {attribute} = :value";
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
                            MessageBox.Show("customer found with the given " + attribute);
                            AccountStatus_Detail_CheckCustomer.Visible = true;
                            AccountStatus_label_CheckCustomer.Visible = true;
                            AC_Title_Detail_CheckCustomerForm.Visible = true;
                            AccountTitle_Label_CheckCustomer.Visible = true;
                            cnic_detail_label_CheckCustomer.Visible = true;
                            CNIC_Label_CheckCustomer.Visible = true;
                            AC_NO_Detail_CheckCustomerForm.Visible = true;
                            AccountNumber_Label_checkCustomer.Visible = true;
                            DateOfBirth_Detail_CheckCustomer.Visible = true;
                            DateOfBirth_Label_CheckCustomer.Visible = true;
                            DateOpened_Detail_CheckCustomer.Visible = true;
                            DateOfBirth_Label_CheckCustomer.Visible = true;
                            Available_Balance_Detail_CheckCustomerForm.Visible = true;
                            Available_Balance_Label_CheckCustomer.Visible = true;
                            Account_type_Detail_labelCheckCustomerForm.Visible = true;
                            Account_type_label_CheckCustomerForm.Visible = true;
                            Branchaname_Detail_CheckCustomer.Visible = true;
                            Branchaname_label_CheckCustomer.Visible = true;
                            DateOpened_Label_CheckCustomer.Visible = true;                          
                            onlineUserStatusLabelCheckCustomer.Visible = true;
                            OnlineUserStatusDetailCheckCustomer.Visible = true;
                            EmailGenerateOTP_btn_UpdateUserInfoForm.Visible = true;
                            EnterOTP_txtBox_UpdateUserInfoForm.Visible = true;
                            EmailDetailLabel.Visible = true;
                            EmailLabel.Visible = true;
                            pictureBox2.Visible = false;
                            pictureBox2.Enabled = false;



                        }
                        else
                        {
                            MessageBox.Show("Reader does not have any value");
                            return;
                        }

                        while (reader.Read())
                        {
                            Customer customer = new Customer("CUS" + reader["customer_id"].ToString());
                            GlobalData.CurrentCustomer = customer;
                            customer.customerId = Convert.ToInt32(reader["customer_id"]);
                            MessageBox.Show(Convert.ToString(reader["customer_id"]));
                            Account account = new Account(customer.customerId);
                            GlobalData.CustomerAccount = account;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Populating data of custoemrm please check log file");
                    GlobalData.LogError("Error populating data of customer", ex);
                    return;
                }

            }
            AccountStatus_Detail_CheckCustomer.Text = GlobalData.CustomerAccount.status.ToString();
            AC_Title_Detail_CheckCustomerForm.Text = GlobalData.CurrentCustomer.customerName;
            MessageBox.Show(GlobalData.CurrentCustomer.nationalID);
            cnic_detail_label_CheckCustomer.Text = GlobalData.CurrentCustomer.nationalID;
            AC_NO_Detail_CheckCustomerForm.Text = GlobalData.CustomerAccount.accountId.ToString();
            DateOfBirth_Detail_CheckCustomer.Text = DateTime.Parse(GlobalData.CurrentCustomer.dateOfBirth).ToString("yyyy-MM-dd");
            DateOpened_Detail_CheckCustomer.Text = DateTime.Parse(GlobalData.CustomerAccount.dateOpened).ToString("yyyy-MM-dd");
            Available_Balance_Detail_CheckCustomerForm.Text = GlobalData.CustomerAccount.accountBalance.ToString();
            Account_type_Detail_labelCheckCustomerForm.Text = GlobalData.CustomerAccount.type.ToString();
            Branchaname_Detail_CheckCustomer.Text = GlobalData.CustomerAccount.branchName.ToString();
            OnlineUserStatusDetailCheckCustomer.Text = GlobalData.CurrentCustomer.userStatus;
            EmailDetailLabel.Text = GlobalData.CurrentCustomer.email;
        }

        private void SearchCustomerForUpdate_Load(object sender, EventArgs e)
        {

        }

        private void EmailGenerateOTP_btn_UpdateUserInfoForm_Click(object sender, EventArgs e)
        {

            string fromEmail = "AskariDigitalOTP@gmail.com"; 
            string appPassword = GlobalData.password;
            Random random = new Random();
            randomCode = (random.Next(100000, 999999)).ToString();
            string subject = "Important: Your One-Time Password (OTP)";
            string toEmail = GlobalData.CurrentCustomer.email; 
            string emailUsername = "Askari Digital Bank Ltd."; 
            string body = $@"
        Dear {GlobalData.CurrentCustomer.customerName},
        We hope this email finds you well. As part of our security measures, your One-Time Password (OTP) is required to complete the update of your records.
        Your OTP is: **{randomCode}**
        Please note:
        - This OTP is valid for the next 10 minutes.
        - Do not share this OTP with anyone.
        - If you did not request this, please report it immediately to support@askaridigital.com or call +92 335-5552845.

        Thank you for choosing Askari Digital Bank Ltd. We value your security and strive to keep your account safe.

        Warm regards,
        Askari Digital Bank Ltd.
        Customer Support Team
    ";

            try
            {
               
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail, emailUsername),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };
                mailMessage.To.Add(toEmail);
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(fromEmail, appPassword),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                smtpClient.Send(mailMessage);

                MessageBox.Show("Email with OTP sent successfully to the customer.");
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Failed to send email. PLease check log file for more information");
                GlobalData.LogError("Failed to Send Email ", ex);
            }
        }

        private void UpdateCustomerInformation_Button_Click(object sender, EventArgs e)
        {
            if (randomCode != null)
            {
                if (randomCode == EnterOTP_txtBox_UpdateUserInfoForm.Text)
                {
                    EmployeeUpdateCustomerInfo updateCustomerInfo = new EmployeeUpdateCustomerInfo();
                    updateCustomerInfo.Show();
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Invalid OTP");
                }
            }
            else
            {
                GlobalData.customizedPopup("Please get verification from customer first");
            }
        }

        private void EnterOTP_txtBox_UpdateUserInfoForm_TextChanged(object sender, EventArgs e)
        {
            if (EnterOTP_txtBox_UpdateUserInfoForm.Text.Length == 6)
            {
                if (EnterOTP_txtBox_UpdateUserInfoForm.Text.ToString() == randomCode)
                {
                    EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = Color.Green;
                    UpdateCustomerInformation_Button.Visible = true;
                }
                else
                {
                    EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = Color.Red;
                    UpdateCustomerInformation_Button.Visible = false;

                }
            }
            else
            {
                UpdateCustomerInformation_Button.Visible = false;
                EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = Color.Black;
            }

        }

        private void EnterOTP_txtBox_UpdateUserInfoForm_MouseEnter(object sender, EventArgs e)
        {

        }

        private void EnterOTP_txtBox_UpdateUserInfoForm_MouseLeave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(EnterOTP_txtBox_UpdateUserInfoForm.Text))
            {
                EnterOTP_txtBox_UpdateUserInfoForm.Text = "Enter OTP"; 
                EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = System.Drawing.Color.Gray;
                UpdateCustomerInformation_Button.Visible = false;

            }
        }

        private void EnterOTP_txtBox_UpdateUserInfoForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (EnterOTP_txtBox_UpdateUserInfoForm.Text == "Enter OTP")
            {
                EnterOTP_txtBox_UpdateUserInfoForm.Text = "";
                EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = System.Drawing.Color.Black; 
            }
        }

        private void EmailDetailLabel_Click(object sender, EventArgs e)
        {

        }

        private void Exit_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
