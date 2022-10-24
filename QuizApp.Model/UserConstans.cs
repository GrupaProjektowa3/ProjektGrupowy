using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class UserConstans
    {
        public static List<LoggedInUser> LoggedInUsers = new List<LoggedInUser>()
        { new LoggedInUser() { FirstName = "Tomasz", LastName = "Kowalczyk", RegistrationDate = DateTime.Now, UserName="TomaszKowalczyk", EmailAdress="tk@gmail.com", RoleValue = "Admin", Password = "User1234"},
          new LoggedInUser() { FirstName = "Andrzej", LastName = "Kowalczyk", RegistrationDate = DateTime.Now, UserName="AndrzejKowalczyk", EmailAdress="ak@gmail.com", RoleValue = "LoggedInUser", Password = "User12345"},
        };
    }
}
