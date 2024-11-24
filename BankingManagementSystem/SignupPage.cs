using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

namespace BankingManagementSystem
{
    public partial class SignupPage : Form
    {
        String randomCode=null;
        public SignupPage()
        {
            this.Paint += new PaintEventHandler(SignUpPage_Paint);
            InitializeComponent();
        }
        private void SignUpPage_Paint(object sender, PaintEventArgs e)
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
            string username = Username_txtBox_signUpForm.Text;
            string name = Name_txtBox_signUpForm.Text;
            string cnic = Cnic_maskedtextbox_signupform.Text;
            string address = Address_txtbox_SignupForm.Text;
            DateTime dob = dateTimePicker_Signuppage.Value;
            string accountType = AccountTypeComboBox.Text;
            string contactNumber = ContactNumber_MaskedTextBox_sigupform.Text;
            string password = Password_txtBox_signUpForm.Text;
            string confirmPassword = ConfirmPassword_txtBox_SgnupuserPAge.Text;
            string email = Email_txtBox_Sigupfrom.Text;

            int accountTypeID = 0;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(name)  || string.IsNullOrWhiteSpace(cnic) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(accountType) || string.IsNullOrWhiteSpace(contactNumber) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All Fields are Mandatory \n please fill the form completely");
                return;
            }

            if(username.Contains(" "))
            {
                MessageBox.Show("Username Could Not contain blank Spaces");
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


            switch (accountType)
            {
                case "Savings":
                    {
                        accountTypeID = 1;
                        break;
                    }
                case "Current":
                    {
                        accountTypeID = 2;
                        break;
                    }
                case "Fixed Deposit":
                    {
                        accountTypeID = 3;
                        break;
                    }
                case "Joint Account":
                    {
                        accountTypeID = 4;
                        break;
                    }
            }
            int newCustomerID = 0;

            string dobFormatted = dob.ToString("yyyy-MM-dd");


            string selectedCity = Branch_ComboBox_SigupPAge.SelectedItem.ToString();
            int selectedBranchID = 0;

            if (GlobalData.cityBranchIDs.ContainsKey(selectedCity))
            {
                selectedBranchID = GlobalData.cityBranchIDs[selectedCity];
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

            DateTime today = DateTime.Today;
            DateTime eighteenYearsAgo = today.AddYears(-18);

            if (dob > eighteenYearsAgo)
            {
                MessageBox.Show("You must be at least 18 years old to sign up.", "Age Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Both Passwords doesn't Match", "Re-Enter Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPassword(password))
            {
                MessageBox.Show("Password is Invalid \n It Should Contain \n One Upper Case\n One Special Character \n and no Space", "Invalid Password ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (randomCode == null)
            {
                MessageBox.Show("Please Verify The Email First", "Verify Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (randomCode != EnterOTP_txtBox_SignupUserForm.Text)
            {
                MessageBox.Show("Invalid OTP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (randomCode == EnterOTP_txtBox_SignupUserForm.Text)
            {
                bool isUnique = false;
                long AccountNumberAssigned = 0;
                Random random = new Random();

                Terms_and_Conditions_SigupForm terms_And_Conditions = new Terms_and_Conditions_SigupForm();
                this.Hide();

                DialogResult resultt = terms_And_Conditions.ShowDialog(); //in this page there are two buttons accept and reject how to do move ahead if user accepts and stops if reject
                
                if(resultt==DialogResult.Yes){
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

                        UpdateTable(username, name, cnic, address, dobFormatted, accountTypeID, contactNumber, password, email, selectedBranchID, AccountNumberAssigned, newCustomerID);
                        SendWelcomeEmail(email, name, Convert.ToString(AccountNumberAssigned), accountType);
                        signInpage signInpage= new signInpage();
                        this.Hide();
                        signInpage.Show();

                    }


                }
                else
                {
                    MessageBox.Show("You have rejected the terms and conditions please accept it to continue");
                    return;
                }
          
            }
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
                EnterOTP_txtBox_SignupUserForm.ForeColor = System.Drawing.Color.Black; 
            }
          
        }

        private void EnterOTP_txtBox_SignupUserForm_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EnterOTP_txtBox_SignupUserForm.Text))
            {
                EnterOTP_txtBox_SignupUserForm.Text = "Enter OTP"; 
                EnterOTP_txtBox_SignupUserForm.ForeColor = System.Drawing.Color.Gray; 
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


        private void UpdateTable(string username, string name, string cnic, string address, string dobFormatted, int accountTypeiD,
                              string contactNumber, string password, string email, int selectedBranchID, long accountNumberAssigned,int newcustomerID)
        {
           
            string userID = "CUS" + newcustomerID.ToString();

            string userInsertQuery = @"
        INSERT INTO users (USER_ID, USERNAME, PASSWORDHASH, ROLE, LAST_LOGIN, EMAIL, CUSTOMER_ID)
        VALUES (:USER_ID, :USERNAME, :PASSWORDHASH, 'Customer', CURRENT_TIMESTAMP, :EMAIL, :CUSTOMER_ID)";

            string customerInsertQuery = @"
        INSERT INTO customers (CUSTOMER_ID, NAME, DATE_OF_BIRTH, ADDRESS, CONTACT_NUMBER, EMAIL, NATIONAL_ID, DATE_JOINED, CUSTOMER_TYPE, USER_ID)
        VALUES (:CUSTOMER_ID, :NAME, TO_DATE(:DATE_OF_BIRTH, 'YYYY-MM-DD'), :ADDRESS, :CONTACT_NUMBER, :EMAIL, :CNIC, CURRENT_DATE, 'Standard', :USER_ID)";

            string accountInsertQuery = @"
        INSERT INTO account (ACCOUNT_ID, CUSTOMER_ID, ACCOUNT_BALANCE, DATE_OPENED, STATUS, BRANCH_ID, ACCOUNT_TYPE)
        VALUES (:ACCOUNT_ID, :CUSTOMER_ID, 0.00, CURRENT_DATE, 'Active', :BRANCH_ID, :ACCOUNT_TYPE)";

            try
            {
                using (OracleConnection conn = new OracleConnection(GlobalData.connString))
                {
                    conn.Open();
                    using (OracleTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {

                         

                            // Insert into Customers table
                            using (OracleCommand customerCmd = new OracleCommand(customerInsertQuery, conn))
                            {
                                customerCmd.Parameters.Add(":CUSTOMER_ID", OracleDbType.Int32).Value = newcustomerID;
                                customerCmd.Parameters.Add(":NAME", OracleDbType.Varchar2).Value = name;
                                customerCmd.Parameters.Add(":DATE_OF_BIRTH", OracleDbType.Varchar2).Value = dobFormatted;
                                customerCmd.Parameters.Add(":ADDRESS", OracleDbType.Varchar2).Value = address;
                                customerCmd.Parameters.Add(":CONTACT_NUMBER", OracleDbType.Varchar2).Value = contactNumber;
                                customerCmd.Parameters.Add(":EMAIL", OracleDbType.Varchar2).Value = email;
                                customerCmd.Parameters.Add(":CNIC", OracleDbType.Varchar2).Value = cnic;
                                customerCmd.Parameters.Add(":USER_ID", OracleDbType.Varchar2).Value = userID;

                                customerCmd.ExecuteNonQuery();
                            }

                            using (OracleCommand userCmd = new OracleCommand(userInsertQuery, conn))
                            {
                                userCmd.Parameters.Add(":USER_ID", OracleDbType.Varchar2).Value = userID;
                                userCmd.Parameters.Add(":USERNAME", OracleDbType.Varchar2).Value = username;
                                userCmd.Parameters.Add(":PASSWORDHASH", OracleDbType.Varchar2).Value = password;
                                userCmd.Parameters.Add(":EMAIL", OracleDbType.Varchar2).Value = email;
                                userCmd.Parameters.Add(":CUSTOMER_ID", OracleDbType.Int32).Value = newcustomerID;

                                userCmd.ExecuteNonQuery();
                            }

                            // Insert into Account table
                            using (OracleCommand accountCmd = new OracleCommand(accountInsertQuery, conn))
                            {
                                accountCmd.Parameters.Add(":ACCOUNT_ID", OracleDbType.Int64).Value = accountNumberAssigned;
                                accountCmd.Parameters.Add(":CUSTOMER_ID", OracleDbType.Int32).Value = newcustomerID;
                                accountCmd.Parameters.Add(":BRANCH_ID", OracleDbType.Int32).Value = selectedBranchID;
                                accountCmd.Parameters.Add(":ACCOUNT_TYPE", OracleDbType.Int32).Value = Convert.ToInt32(accountTypeiD);

                                accountCmd.ExecuteNonQuery();
                            }

                            // Commit transaction
                            transaction.Commit();
                            MessageBox.Show("Customer and Account data inserted successfully!");
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction on error
                            transaction.Rollback();
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting data: " + ex.Message);
            }
        }


public void SendWelcomeEmail(string customerEmail, string customerName, string accountNumber, string accountType)
    {
        this.Cursor = Cursors.WaitCursor;

        
        string from = "AskariDigitalOTP@gmail.com";
        string pass = "mitxehwlyexurspx"; 
        string emailUsername = "Askari Digital Bank Ltd."; 
        string subject = "Welcome to Askari Digital Banking! Your Account is Now Active";

   
        string messageBody = $"Dear {customerName},\n\n" +
                             "Congratulations! Your new account with Askari Digital Bank has been successfully created through our Digital Onboarding process. We’re excited to have you as part of our banking family.\n\n" +
                             $"Here’s what you can expect next:\n" +
                             $"- Your Account Details:\n" +
                             $"  - Account Type: {accountType}\n" +
                             $"  - Account Number: {accountNumber}\n\n" +
                             "- Access Your Account:\n" +
                             "You can now log in to our online banking portal or mobile app using the credentials you created during the onboarding process. Should you need help, our customer support team is always ready to assist you.\n\n" +
                             "- Start Managing Your Finances:\n" +
                             "You can now enjoy a range of services such as fund transfers, bill payments, balance checks, and more—all at your fingertips.\n\n" +
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
                MessageBox.Show("Welcome Mail send successful");
        }
        catch (Exception ex)
        {
            this.Cursor = Cursors.Default;
            MessageBox.Show("Error sending email: " + ex.Message);
        }
    }
}
}
