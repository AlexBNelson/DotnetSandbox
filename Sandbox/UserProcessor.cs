using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    static internal class UserProcessor
    {
        
        public static string GetUserNameWithRole(List<User> users)
        {
            StringBuilder sb = new StringBuilder();

            users.ForEach(user => sb.Append(user.Name).Append(" ").Append(user.Role));

            return sb.ToString();
        }

        public static string GetUserNameWithRoleStringArithmetic(List<User> users)
        {
            string userString = "";

            users.ForEach(user => userString += (user.Name + " " + user.Role));

            return userString;
        }
    }
}
