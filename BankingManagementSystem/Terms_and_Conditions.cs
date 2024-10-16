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
    public partial class Terms_and_Conditions : Form
    {
        public Terms_and_Conditions()
        {
            InitializeComponent();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void Terms_and_Conditions_Load(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Accept_Terms_and_Condition_btn_Page_Form_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have successfully SIgned up");
            this.Close();   
            HomePageCustomers homePageCustomers = new HomePageCustomers();  
            homePageCustomers.Show();   
        }
    }
}
