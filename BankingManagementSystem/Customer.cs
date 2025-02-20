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
        public string userStatus { get; set; }
        public string username { get; set; }

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

                    MessageBox.Show("Oracle Error Occured please see auit log for more information");
                    GlobalData.LogError("Error Occured ", ex);
                }
            }

        }
    public Customer(string UserId)
        {
            this.userID= UserId;
            LoadCustomerByUserID();
            loadUserStatus();
        }

       public Customer(int customerID, string username)
        {
            this.customerId = customerID;
            LoadCustomerByCustomerID();
            loadUserStatus();

            this.username = username;
        }
        public Customer (int customerID)
        {
            this.customerId = customerID;
            LoadCustomerByCustomerID();
            loadUserStatus();

        }

        private void loadUserStatus()
        {
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT status,username FROM users WHERE user_id = :userid";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                       
                        cmd.Parameters.Add(new OracleParameter("userid",  this.userID));

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) 
                            {
                                this.username = reader["username"].ToString();
                                this.userStatus = reader["status"].ToString(); 
                            }
                            else
                            {
                                MessageBox.Show("User not found.");
                            }
                        }
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
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

                    MessageBox.Show("Oracle Error Occured please see audit log for more information");
                    GlobalData.LogError("Error Occured ", ex);
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

                    MessageBox.Show("Oracle Error Occured please see auit log for more information");
                    GlobalData.LogError("Error Occured ", ex);
                }
            }
        }
        private void MapData(OracleDataReader reader)
        {
            nationalID = reader["NATIONAL_ID"].ToString();
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
