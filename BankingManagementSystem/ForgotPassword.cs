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

namespace BankingManagementSystem
{
    public partial class ForgotPassword : Form
    {
        String EmailrandomCode;
        public ForgotPassword()
        {
            InitializeComponent();
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
                Email_OTP_textBox_ForgotPAssword_Form.ForeColor = System.Drawing.Color.Black; // Change text color to black when editing
            }

        }

        private void Email_OTP_textBox_ForgotPAssword_Form_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Email_OTP_textBox_ForgotPAssword_Form.Text))
            {
                Email_OTP_textBox_ForgotPAssword_Form.Text = "Enter OTP"; // Reset the default text if left empty
                Email_OTP_textBox_ForgotPAssword_Form.ForeColor = System.Drawing.Color.Gray; // Set the text color back to gray
            }

        }

        private void Generate_OTP_Phone_Btn_ForgotPasswrod_Form_Click(object sender, EventArgs e)
        {

        }

        private void Save_Password_BTN__ForgotPasswrod_Form_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Password Changed Successfully");
            this.Close();
        }
    }
}
