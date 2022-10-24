using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class LoggedInUser:User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAdress { get; set; }
        public string RoleValue { get; set; }
        public virtual List<Grade> Grades { get; set; }
    }
}
