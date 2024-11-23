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
    public partial class TermsAndCondition_HomePageUser : Form
    {
        public TermsAndCondition_HomePageUser()
        {
            
            InitializeComponent();
        }

        private void Exit_btn_TermsandCondition_HomePageFormUser_Click(object sender, EventArgs e)
        {
            this.Hide();    
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void Exit_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
