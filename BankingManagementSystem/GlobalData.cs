using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingManagementSystem
{
    internal class GlobalData
    {
        public static Customer CurrentCustomer { get; set; }
        public static Account CustomerAccount { get; set; }

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
    }



}
