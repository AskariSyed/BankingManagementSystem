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

namespace BankingManagementSystem
{
    public partial class EnterOTPFromEmployeeForUpdate : Form
    {
        string randomCode = "-1";
        public EnterOTPFromEmployeeForUpdate()
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
            String from, pass, messageBody, to, Email_username;
            Random random = new Random();
            Email_username = "Askari Digital Bank Ltd.";
            randomCode = (random.Next(100000, 999999)).ToString();
            MailMessage message = new MailMessage();
            to = (GlobalData.CurrentCustomer.email);
            from = "AskariDigitalOTP@gmail.com";
            pass = "mitxehwlyexurspx ";
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
            message.Subject = "Important: Askari Digital OTP";
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
                MessageBox.Show(ex.Message);
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

        private void EnterOTP_txtBox_UpdateUserInfoForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (EnterOTP_txtBox_UpdateUserInfoForm.Text == "Enter OTP")
            {
                EnterOTP_txtBox_UpdateUserInfoForm.Text = "";
                EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void EnterOTP_txtBox_UpdateUserInfoForm_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EnterOTP_txtBox_UpdateUserInfoForm.Text))
            {
                EnterOTP_txtBox_UpdateUserInfoForm.Text = "Enter OTP";
                EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void VerifyBtn_Click(object sender, EventArgs e)
        {
            if (randomCode != "-1")
            {
                if (EnterOTP_txtBox_UpdateUserInfoForm.Text != randomCode)
                {
                    MessageBox.Show("Invalid OTP. Please enter the correct OTP.", "OTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    EmployeeUpdateCustomerInfo employeeUpdateCustomerInfo = new EmployeeUpdateCustomerInfo();
                    employeeUpdateCustomerInfo.Show();
                    this.Close();
                }

            }
        }
    }
}
