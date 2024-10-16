using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingManagementSystem
{
    public partial class HomePageCustomers : Form
    {
        public HomePageCustomers()
        {
            InitializeComponent();
            
        }

        private void HomePageCustomers_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Logout_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            signInpage signInpage = new signInpage();
            this.Show();
            signInpage.Show();

        }

        private void Exit_btn_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void Account_Statment_btn_HomeFormUser_Click(object sender, EventArgs e)
        {

        }

        private void Update_AccountInfo_HomePageUserForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdatePersonalDetailsForm updatePersonalDetailsForm = new UpdatePersonalDetailsForm();  
           
            updatePersonalDetailsForm.Show();

        }

        private void AccountNumber_Label_HomePageUSer_Click(object sender, EventArgs e)
        {

        }

        private void SideLeft_panel_HomePageForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TermsAndConditions_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            Terms_and_Conditions terms_And_Conditions = new Terms_and_Conditions(); 
            terms_And_Conditions.Show();    
        }
    }
}
