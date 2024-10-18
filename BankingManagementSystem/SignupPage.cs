using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingManagementSystem
{
    public partial class SignupPage : Form
    {
        String randomCode;
        public SignupPage()
        {
            InitializeComponent();
        }

        private void SignupPage_Load(object sender, EventArgs e)
        {

        }

        private void SignIn_btn_signUpForm_Click(object sender, EventArgs e)
        {
            signInpage signInpage = new signInpage();
            this.Hide();
            signInpage.Show();
        }

        private void Exit_btn_signinForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Signup_Btn_SignupScreen_Click(object sender, EventArgs e)
        {
            //if (randomCode == (EnterOTP_txtBox_SignupUserForm.Text.ToString())){
            //    EnterOTP_txtBox_SignupUserForm.ForeColor = Color.Green;
            //    MessageBox.Show("Email Verified Successfully");

            //}
            //else
            //{
            //    EnterOTP_txtBox_SignupUserForm.ForeColor= Color.Red;
            //    MessageBox.Show("OTP does not Match");
            //}
            Terms_and_Conditions_SigupForm terms_And_Conditions = new Terms_and_Conditions_SigupForm();
            this.Hide();
            terms_And_Conditions.Show();
        }

        private void EmailGenerateOTP_btn_SignupUSerForm_Click(object sender, EventArgs e)

        {
            this.Cursor = Cursors.WaitCursor;
            String from, pass, messageBody,to,Email_username;
            Random random = new Random();
            Email_username = "Askari Digital Bank Ltd.";
            randomCode= (random.Next(100000, 999999)).ToString();
            MailMessage message = new MailMessage();
            to = (Email_txtBox_Sigupfrom.Text.ToString());
            from = "AskariDigitalOTP@gmail.com";
            pass = "mitxehwlyexurspx ";
            messageBody = "Your OTP code for Askari Digital Banking is : " + randomCode + " ";
            try{
                message.To.Add(to); }
            catch(Exception eee)
            {
                
            }
            message.From= new MailAddress(from,Email_username);
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

        private void EnterOTP_txtBox_SignupUserForm_TextChanged(object sender, EventArgs e)
        {
            
            if (EnterOTP_txtBox_SignupUserForm.Text.Length == 6)
            {
                if (EnterOTP_txtBox_SignupUserForm.Text.ToString() == randomCode)
                {
                    EnterOTP_txtBox_SignupUserForm.ForeColor = Color.Green;
                }
                else
                {
                    EnterOTP_txtBox_SignupUserForm.ForeColor = Color.Red;
                }

            }
            else
            {
                EnterOTP_txtBox_SignupUserForm.ForeColor= Color.Black;
            }

        }

        private void Email_txtBox_Sigupfrom_Click(object sender, EventArgs e)
        {

        }

        private void EnterOTP_txtBox_SignupUserForm_Click(object sender, EventArgs e)
        {
            if (EnterOTP_txtBox_SignupUserForm.Text == "Enter OTP")
            {
                EnterOTP_txtBox_SignupUserForm.Text = ""; 
                EnterOTP_txtBox_SignupUserForm.ForeColor = System.Drawing.Color.Black; // Change text color to black when editing
            }
          
        }

        private void EnterOTP_txtBox_SignupUserForm_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EnterOTP_txtBox_SignupUserForm.Text))
            {
                EnterOTP_txtBox_SignupUserForm.Text = "Enter OTP"; // Reset the default text if left empty
                EnterOTP_txtBox_SignupUserForm.ForeColor = System.Drawing.Color.Gray; // Set the text color back to gray
            }
        }
    }
}
