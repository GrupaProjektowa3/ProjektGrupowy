using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class LoggedInUser : User
    {
        public virtual List<Grade> Grades { get; set; }
    }
}
