using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_MS.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        public int UserID { get; set; }
        public string Designation { get; set; }
        public User UserInfo { get; internal set; }
       
    }
}
