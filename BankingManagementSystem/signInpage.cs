using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BankingManagementSystem
{
    public partial class signInpage : Form
    {
        public signInpage()
        {
            InitializeComponent();
        }

        private void Exit_btn_signinForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Signup_btn_signinForm_Click(object sender, EventArgs e)
        {
            SignupPage signupPage = new SignupPage();
            this.Hide();
            signupPage.Show();
        }

        private void signInpage_Load(object sender, EventArgs e)
        {

        }

        private void AKBL_logoimage_picturebox_signin_page_Click(object sender, EventArgs e)
        {

        }

        private void SignIn_btn_SigninForm_Click(object sender, EventArgs e)
        {
            string username = Username_txtBox_signinForm.Text;
            string password = Passworde_txtBox_signinForm.Text;

            string connString = "User Id=System;Password=syed;Data Source=Askari:1521/XE";
            using (OracleConnection conn = new OracleConnection(connString))
            {
                try
                {
                    conn.Open();

                    // First, validate the user and get their CUSTOMER_ID from USERS table
                    string query = "SELECT CUSTOMER_ID FROM USERS WHERE EMAIL = :username AND PASSWORDHASH = :password";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("username", username));
                        cmd.Parameters.Add(new OracleParameter("password", password));
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            int customerId = Convert.ToInt32(result);
                            Customer customer = new Customer(customerId);
                            GlobalData.CurrentCustomer = customer;
                            HomePageCustomers homePageCustomers = new HomePageCustomers(customer);
                            this.Hide();
                            homePageCustomers.Show();
                            MessageBox.Show("Login successful!");
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

        }

        private void ForgetPassword_BTN_SigninpageForm_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();   
            forgotPassword.Show();
        }

        private void Username_txtBox_signinForm_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {
                Passworde_txtBox_signinForm.UseSystemPasswordChar=false;
            }
            else
            {
                Passworde_txtBox_signinForm.UseSystemPasswordChar = true;
            }
        }

        private void Passworde_txtBox_signinForm_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
