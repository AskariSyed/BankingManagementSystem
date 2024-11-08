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

        }

        private void Logout_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
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
                EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = System.Drawing.Color.Black; // Change text color to black when editing
            }
        }

        private void EnterOTP_txtBox_UpdateUserInfoForm_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EnterOTP_txtBox_UpdateUserInfoForm.Text))
            {
                EnterOTP_txtBox_UpdateUserInfoForm.Text = "Enter OTP"; // Reset the default text if left empty
                EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = System.Drawing.Color.Gray; // Set the text color back to gray
            }
        }

        private void Account_Statment_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {

        }
    }
}
