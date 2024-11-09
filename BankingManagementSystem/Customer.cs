using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using static BankingManagementSystem.Customer;

namespace BankingManagementSystem
{
    public class Customer
    {
        public int customerId { get; set; }
        public string customerName { get; set; }
        public string dateOfBirth { get; set; }
        public string nationalID { get; set; }
        public string dateJoined { get; set; }
        public string userID { get; set; }

        public string email { get; set; }   
        public string address { get; set; }

        public string contactNumber { get; set; }    

        public customerType type { get; set; }

        

        public enum customerType
        {
            Individual, Business
        };


       public Customer customer { get; set; }

        public Customer() { }


        public Customer(int customerID,String CustomerName,string dateOfBirth, string NationalID,string DateJoined, string UserId)
        {
            this.customerId = customerID;
            this.customerName = CustomerName;
            this.dateOfBirth = dateOfBirth;
            this.nationalID = NationalID;
            this.dateJoined = DateJoined;
            this.userID = UserId;
        }
       public Customer(string UserID,int customerID)
        {
            this.userID = UserID;   
            this.customerId= customerID;


            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();
                    string query = "";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                      
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

        }
    public Customer(string UserId)
        {
            this.userID= UserId;
            LoadCustomerByUserID();
        }

       public Customer(int customerID)
        {
            this.customerId=customerID; 
            LoadCustomerByCustomerID();
        }


        private void LoadCustomerByUserID()
        {
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM CUSTOMERS WHERE USER_ID = :userId";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("userId", this.userID));
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MapData(reader);
                            }
                            else
                            {
                                MessageBox.Show("No customer found with the specified USER_ID.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
        private void LoadCustomerByCustomerID()
        {
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM CUSTOMERS WHERE CUSTOMER_ID = :customerId";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("customerId", this.customerId));
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MapData(reader);
                            }
                            else
                            {
                                MessageBox.Show("No customer found with the specified CUSTOMER_ID.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
        private void MapData(OracleDataReader reader)
        {
            customerId = Convert.ToInt32(reader["CUSTOMER_ID"]);
            customerName = reader["NAME"].ToString();
            dateOfBirth = reader["DATE_OF_BIRTH"].ToString();
            address = reader["ADDRESS"]?.ToString();
            contactNumber = reader["CONTACT_NUMBER"].ToString();
            email = reader["EMAIL"]?.ToString();
            nationalID = reader["NATIONAL_ID"].ToString();
            dateJoined = reader["DATE_JOINED"]?.ToString();
            userID = reader["USER_ID"]?.ToString();
            type = (reader["CUSTOMER_TYPE"].ToString().ToLower() == "business") ? customerType.Business : customerType.Individual;
        }





    }
}
