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
using static BankingManagementSystem.Account;
using System.ComponentModel.DataAnnotations;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

namespace BankingManagementSystem
{
    public partial class OpenNewAccountTeller : Form
    {
        public OpenNewAccountTeller()
        {
            InitializeComponent();
            
        }
        string username;
        string name;
        DateTime DateoFBirth;
        string contactNumber;
        string address;
        Account.accountType accountTypeID;
        String Branch;
        string email;
        string cnic;
        string password;
        string otp;
        string randomCode=null;
        int newCustomerID;


        private void OpenNewAccountTeller_Load(object sender, EventArgs e)
        { 
           
        }

        static string GeneratePassword()
        {
            int length = 10;
            const string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string specialCharacters = "!@#$%^&*()_+-=[]{}|;:'\",.<>?/";
            const string numbers = "0123456789";
            const string lowerLetters = "abcdefghijklmnopqrstuvwxyz";
            const string allChars = capitalLetters + lowerLetters + numbers + specialCharacters;

            Random rnd = new Random();
            StringBuilder password = new StringBuilder();

            password.Append(capitalLetters[rnd.Next(capitalLetters.Length)]);
            password.Append(specialCharacters[rnd.Next(specialCharacters.Length)]);
            password.Append(numbers[rnd.Next(numbers.Length)]);

            for (int i = 3; i < length; i++)
            {
                password.Append(allChars[rnd.Next(allChars.Length)]);
            }
            char[] passwordArray = password.ToString().ToCharArray();
            Shuffle(passwordArray, rnd);

            return new string(passwordArray);
        }

        static void Shuffle(char[] array, Random rnd)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }
        }

        private void Signup_Btn_CreateAccountTellerScreen_Click(object sender, EventArgs e)
        {
            this.username = Username_txtBox_CreateAccountTeller.Text;
            this.name = Name_txtBox_sCreateAccountTEllerForm.Text;
            this.DateoFBirth = dateTimePicker_CreateAccountTellerpage.Value;
            this.contactNumber = ContactNumber_MaskedTextBox_CreateAccountTellerform.Text;
            this.address = Address_txtbox_CreateAccountTellerForm.Text;

            switch (AccountTypeComboBoxCreateAccountTeller.Text)
            {
                case "Savings":
                    {
                        accountTypeID = Account.accountType.Savings;
                        break;
                    }
                case "Current":
                    {
                        accountTypeID = Account.accountType.Current;
                        break;
                    }
                case "Fixed Deposit":
                    {
                        accountTypeID = Account.accountType.FixedDeposit;
                        break;
                    }
                case "Joint Account":
                    {
                        accountTypeID = Account.accountType.JointAccount;
                        break;
                    }
            }


            this.Branch = Branch_ComboBox_CreateAccountTellerPAge.Text;
            this.cnic = Cnic_maskedtextbox_CreateAccountTellerform.Text;
            this.password = GeneratePassword();
            this.otp=EnterOTP_txtBox_CreateAccountTellerForm.Text;

            this.Branch = Branch_ComboBox_CreateAccountTellerPAge.SelectedItem.ToString();
            int selectedBranchID = 0;

            DateTime today = DateTime.Today;
            DateTime eighteenYearsAgo = today.AddYears(-18);

            if (DateoFBirth > eighteenYearsAgo)
            {
                MessageBox.Show("You must be at least 18 years old to sign up.", "Age Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (GlobalData.cityBranchIDs.ContainsKey(this.Branch))
            {
                selectedBranchID = GlobalData.cityBranchIDs[this.Branch];
                MessageBox.Show($"Selected Branch ID: {selectedBranchID}");
            }
            else
            {
                selectedBranchID = 0;
                MessageBox.Show("PLease select a branch");
                return;
            }
            if (selectedBranchID == 0)
            {
                MessageBox.Show("Please Select A Branch ", "Select a Branch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM USERS WHERE USERNAME = :username";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("username", username));

                    int usernameCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (usernameCount > 0)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Username is available.", "Username Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }

            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM customers WHERE National_id = :cnic";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("cnic", cnic));

                    int usernameCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (usernameCount > 0)
                    {
                        MessageBox.Show("Account with The same CNIC Already Exist", "Duplicate CNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("CNIC is available.", "CNIC Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }


            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(cnic)  || string.IsNullOrWhiteSpace(contactNumber) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All Fields are Mandatory \n please fill the form completely");
                return;
            }

            if (username.Contains(" "))
            {
                MessageBox.Show("Username Could Not contain blank Spaces");
                return;
            }

            if (randomCode == null)
            {
                MessageBox.Show("Please Verify The Email First", "Verify Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (randomCode != EnterOTP_txtBox_CreateAccountTellerForm.Text)
            {
                MessageBox.Show("Invalid OTP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (randomCode == EnterOTP_txtBox_CreateAccountTellerForm.Text)
            {
                this.email = Email_txtBox_CreatAccountTellerfrom.Text;
                bool isUnique = false;
                long AccountNumberAssigned = 0;
                Random random = new Random();              
                this.Hide();
                    using (OracleConnection conn = new OracleConnection(GlobalData.connString))
                    {
                        conn.Open();

                        while (!isUnique)
                        {
                            AccountNumberAssigned = (long)(random.Next(100000, 1000000)) * 10000 + random.Next(10000, 100000);
                            string query = "SELECT COUNT(*) FROM Account WHERE account_id = :accountId";

                            using (OracleCommand cmd = new OracleCommand(query, conn))
                            {
                                cmd.Parameters.Add(new OracleParameter("accountId", AccountNumberAssigned));
                                int count = Convert.ToInt32(cmd.ExecuteScalar());
                                if (count == 0)
                                {
                                    isUnique = true;
                                }
                            }
                        }

                        string getMaxCustomerIdQuery = "SELECT MAX(customer_ID) FROM CUSTOMERS";
                        try
                        {
                            using (OracleCommand cmd = new OracleCommand(getMaxCustomerIdQuery, conn))
                            {
                                object result = cmd.ExecuteScalar();
                                int maxCustomerId = (result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                                newCustomerID = maxCustomerId + 1;

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    string dobFormatted = DateoFBirth.ToString("yyyy-MM-dd");
                    SignupPage sg = new SignupPage();   

                    sg.UpdateTable(username, name, cnic, address, dobFormatted, (int)accountTypeID, contactNumber, password, email, selectedBranchID, AccountNumberAssigned, newCustomerID);
                        SendWelcomeEmail(email, name, AccountNumberAssigned.ToString(),accountTypeID.ToString(), username,password);
                        signInpage signInpage = new signInpage();
                        this.Hide();
                        signInpage.Show();

                    }


                

            }




        }

        private void EmailGenerateOTP_btn_CreateAccountTellerForm_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            String from, pass, messageBody, to, Email_username;
            Random random = new Random();
            Email_username = "Askari Digital Bank Ltd.";
            randomCode = (random.Next(100000, 999999)).ToString();
            MailMessage message = new MailMessage();
            to = (Email_txtBox_CreatAccountTellerfrom.Text.ToString());
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

        public void SendWelcomeEmail(string customerEmail, string customerName, string accountNumber, string accountType, string username, string password)
        {
            Cursor = Cursors.WaitCursor;

            string from = "AskariDigitalOTP@gmail.com";
            string pass = "mitxehwlyexurspx";
            string emailUsername = "Askari Digital Bank Ltd.";
            string subject = "Welcome to Askari Digital Banking! Your Account is Now Active";

            string messageBody = $"Dear {customerName},\n\n" +
                                 "Congratulations! Your new account with Askari Digital Bank has been successfully created through our Physical Onboarding process. We’re excited to have you as part of our banking family.\n\n" +
                                 "Here’s your account information:\n" +
                                 $"  - Account Type: {accountType}\n" +
                                 $"  - Account Number: {accountNumber}\n\n" +
                                 "**Login Credentials:**\n" +
                                 $"  - Username: {username}\n" +
                                 $"  - Temporary Password: {password}\n\n" +
                                 "For security reasons, please log in and change your temporary password immediately.\n\n" +
                                 "You can log in to our online banking portal or mobile app using these credentials. Should you need help, our customer support team is always ready to assist you.\n\n" +
                                 "Enjoy a range of services such as fund transfers, bill payments, balance checks, and more—all at your fingertips.\n\n" +
                                 "If you have any questions or need assistance, please feel free to contact our customer service team at 111-111-111 or AskariDigitalOTP@gmail.com.\n\n" +
                                 "Thank you for choosing Askari Digital Bank. We look forward to helping you achieve your financial goals.\n\n" +
                                 "Warm regards,\n" +
                                 "The Askari Digital Bank Team";

            MailMessage message = new MailMessage();
            message.To.Add(customerEmail);
            message.From = new MailAddress(from, emailUsername);
            message.Body = messageBody;
            message.Subject = subject;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(from, pass)
            };

            try
            {
                smtpClient.Send(message);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Welcome Email sent successfully.");
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Error sending email: " + ex.Message);
            }
        }



    }



}