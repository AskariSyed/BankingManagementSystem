using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Oracle.ManagedDataAccess.Client;
using static BankingManagementSystem.Customer;
using System.Net.NetworkInformation;
namespace BankingManagementSystem
{
    internal class Employee
    {
      public  int  employeeId { get; set; }
        public string firstName {  get; set; }
        public string lastName {  get; set; }
        public string email {  get; set; }
        public string phoneNumber { get; set; }
       public DateTime hireDate { get; set; }
        public DateTime dateOfBirth { get; set; }

        public string cnic { get; set; }
       public enum Position
        {
            Teller,Manager,Other
        }
       public Position position { get; set; }
        public int salary { get; set; }
        public int branchId { get; set; }
        public string userId   { get; set; }
        public Employee employee { get; set; }
        public string branchName {  get; set; }

        
        public Employee(int employeeId, string firstName, string lastName, string email, string phoneNumber, DateTime hireDate,Position position ,int salary,int branchId,string userId,string cnic,DateTime dateOfBirth)
        {
            this.employeeId = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.hireDate = hireDate;
            this.position = position;
            this.salary = salary;
            this.branchId = branchId;
            this.userId = userId;
            this.cnic = cnic;
            string branchName = GlobalData.cityBranchIDs.FirstOrDefault(x => x.Value == branchId).Key;
            this.dateOfBirth = dateOfBirth;

            // Handle the case when no matching value is found
            if (branchName != null)
            {
                this.branchName = branchName;
            }
            else
            {
                // Handle case when branchId is not found in the dictionary
                this.branchName = "Branch not found";
            }

        }

        public Employee(string UserID, int employeeId)
        {
            this.userId = UserID;
            this.employeeId = employeeId;


            LoadEmployeeByUserID();

            

        }
        public Employee(String userId)
        {
            this.userId = userId;
            LoadEmployeeByUserID ();
          
        }


        private void LoadEmployeeByUserID()
        {
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM bankEmployee WHERE USER_ID = :userId";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("userId", this.userId));
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MapData(reader);
                                GlobalData.customizedPopup("Employee Login successful");
                            }
                            else
                            {
                                MessageBox.Show("No Employee found with the specified USER_ID.");
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
            this.email = reader["EMAIL"].ToString();
            this.firstName = reader["FIRST_NAME"].ToString();
            this.lastName = reader["LAST_NAME"].ToString();
            this.hireDate = (Convert.ToDateTime(reader["HIRE_DATE"]));
            string positionString = reader["POSITION"]?.ToString();
            this.employeeId = Convert.ToInt32(reader["EMPLOYEE_ID"]);
            this.salary = Convert.ToInt32(reader["SALARY"]);
            this.branchId = Convert.ToInt32(reader["BRANCH_ID"]);
            this.phoneNumber = reader["PHONE_NUMBER"].ToString();
            this.cnic = reader["CNIC"].ToString();
            this.dateOfBirth = (Convert.ToDateTime(reader["DATEOFBIRTH"]));

            string branchName = GlobalData.cityBranchIDs.FirstOrDefault(x => x.Value == branchId).Key;

            // Handle the case when no matching value is found
            if (branchName != null)
            {
                this.branchName = branchName;
            }
            else
            {
                // Handle case when branchId is not found in the dictionary
                this.branchName = "Branch not found";
            }


            if (positionString=="Teller")
            {
                this.position = Position.Teller;
            }
            else if (positionString == "Manager")
            {
                this.position = Position.Manager;
            }
            else
            {
                this.position = Position.Other;
            }
        }
        public static int generateNewEmployeeId()
        {
            string getMaxEmployeeIdQuery = "SELECT MAX(employee_ID) FROM bankemployee";
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(getMaxEmployeeIdQuery, conn))
                    {
                        
                        object result = cmd.ExecuteScalar();
                        int maxEmployeeId = (result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                        int newEmployeeID = maxEmployeeId + 1;
                        MessageBox.Show("Generated new Employee ID: " + newEmployeeID);
                        return newEmployeeID;
                    }
                }
                catch (Exception ex)
                {
                    // Catch any exceptions and show the error message
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
    }
}
