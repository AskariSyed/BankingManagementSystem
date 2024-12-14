using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace BankingManagementSystem
{
    internal class GlobalData
    {
        public static Customer CurrentCustomer { get; set; }
        public static Account CustomerAccount { get; set; }
        public static Employee CurrentEmployee { get; set; }

        public static string connString = "User Id=System;Password=syed;Data Source=Askari:1521/XE";

        public static Dictionary<string, int> cityBranchIDs = new Dictionary<string, int>
        {
            { "Islamabad", 1954 },
            { "Karachi", 8658 },
            { "Lahore", 8163 },
            { "Peshawar", 3594 },
            { "Quetta", 4267 },
            { "Rawalpindi", 8687 },
            { "Multan", 5423 },
            { "Faisalabad", 2934 },
            { "Sialkot", 2343 },
            { "Gujranwala", 4157 },
            { "Sukkur", 3154 },
            { "Abbottabad", 9755 },
            { "Bahawalpur", 2700 },
            { "Sargodha", 8153 },
            { "Mardan", 7936 },
            { "Dera Ghazi Khan", 4706 },
            { "Larkana", 3998 },
            { "Jhelum", 4531 },
            { "Mirpur", 1612 },
            { "Muzaffarabad", 6585 },
            { "Rahim Yar Khan", 6247 }
        };

        public static void customizedPopup(String message)
        {
            Form popup = new Form
            {
                Size = new Size(250, 60),
                StartPosition = FormStartPosition.CenterScreen,
                Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 260, Screen.PrimaryScreen.WorkingArea.Height - 70),
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.Black,
                Opacity = 0.8,
                ShowInTaskbar = false,
                TopMost = true
            };

            Label messageLabel = new Label
            {
                Text = message,
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            popup.Controls.Add(messageLabel);
            popup.Show();

            Timer timer = new Timer { Interval = 2000 };
            timer.Tick += (s, args) => { popup.Close(); timer.Dispose(); };
            timer.Start();


        }
        public static void customerLogout()
        {
            string insertAuditLogQuery = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                         "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {

                try
                {
                    conn.Open();
                    int newAuditID = signInpage.GenerateNewLogID();
                    using (OracleCommand insertCmd = new OracleCommand(insertAuditLogQuery, conn))
                    {
                        insertCmd.Parameters.Add(new OracleParameter("auditLogId", newAuditID));
                        insertCmd.Parameters.Add(new OracleParameter("userId", GlobalData.CurrentCustomer.userID));
                        insertCmd.Parameters.Add(new OracleParameter("actionPerformed", "Logged Out successfully"));
                        insertCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                GlobalData.CurrentCustomer = null;
            }


        }
        public static void EmployeeLogout()
        {
            string insertAuditLogQuery = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                         "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {

                try
                {
                    conn.Open();
                    int newAuditID = signInpage.GenerateNewLogID();
                    using (OracleCommand insertCmd = new OracleCommand(insertAuditLogQuery, conn))
                    {
                        insertCmd.Parameters.Add(new OracleParameter("auditLogId", newAuditID));
                        insertCmd.Parameters.Add(new OracleParameter("userId", GlobalData.CurrentEmployee.userId));
                        insertCmd.Parameters.Add(new OracleParameter("actionPerformed", "Logged Out successfully"));
                        insertCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                GlobalData.CurrentCustomer = null;
                GlobalData.CurrentEmployee = null;
            }


        }
        public  static string GeneratePassword()
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
        public static void LogError(string message, Exception ex)
        {
            string logFilePath = "C:\\Users\\Dell\\source\\repos\\BankingManagementSystem\\BankingManagementSystem\\Error Logs\\Error Logs.txt";
            string separator = new string('-', 80); // Line of 80 hyphens for separation
            string errorDetails = $"{separator}\n{DateTime.Now}: {message}\nException: {ex.Message}\nStack Trace: {ex.StackTrace}\n";

            try
            {
                System.IO.File.AppendAllText(logFilePath, errorDetails); // Append error details to the log file
            }
            catch
            {
                MessageBox.Show("Error accessing log file.");
            }
        }

    }
}
