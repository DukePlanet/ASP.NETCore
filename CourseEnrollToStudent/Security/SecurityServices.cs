using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseEnrollToStudent.Security
{
    public class SecurityServices
    {
        public static bool Login(string username, string password) {

            //using (EnrollContext context = new EnrollContext()) {
            //    return context.Users.Any(x => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && x.Password == password);
            //}
            return true;

        }
    }
}
