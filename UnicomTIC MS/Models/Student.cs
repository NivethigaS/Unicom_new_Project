using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_MS.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public int UserID { get; set; }
        public string StudentNumber { get; set; }

        public string CourseId { get; set; }
        public User UserInfo { get; internal set; }
        public string Course { get; set; }
    }
}
