using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

namespace BankingManagementSystem
{
    public class Account
    {
     public Int64 accountId {  get; set; }
     public int customerID { get; set; }
     public Int64 accountBalance { get; set; }
     public string dateOpened { get; set; }
        
     public statusType status { get; set; }  

     public int branchID { get; set; }

     public accountType type { get; set; }
        public enum statusType
        {
            Active, InActive ,Closed
        }

        public enum accountType
        {
            Savings,Current,FixedDeposit,JointAccount,
        }
        public Account() { }

        public Account (int CustomerID)
        {
             LoadAccountByCustomerID (CustomerID);

        }

        public void  LoadAccountByCustomerID(int customerId)
        {
 
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT ACCOUNT_ID, CUSTOMER_ID, ACCOUNT_BALANCE, DATE_OPENED, STATUS, BRANCH_ID, ACCOUNT_TYPE " +
                                   "FROM ACCOUNT WHERE CUSTOMER_ID = :customerId";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("customerId", customerId));

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                           
                                {
                                    this.accountId = Convert.ToInt64(reader["ACCOUNT_ID"]);
                                    this.customerID = Convert.ToInt32(reader["CUSTOMER_ID"]);
                                    this.accountBalance = Convert.ToInt64(reader["ACCOUNT_BALANCE"]);
                                    this.dateOpened = reader["DATE_OPENED"].ToString();
                                    this.status = (Account.statusType)Enum.Parse(typeof(Account.statusType), reader["STATUS"].ToString());
                                    this.branchID = Convert.ToInt32(reader["BRANCH_ID"]);
                                    int adjustedAccountTypeValue = int.Parse(reader["ACCOUNT_TYPE"].ToString()) - 1;
                                    this.type = (Account.accountType)Enum.Parse(typeof(Account.accountType), adjustedAccountTypeValue.ToString());
                                };

                          
                            }
                            else
                            {
                                MessageBox.Show("No accounts found for this customer.");
                            
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
    }
}
