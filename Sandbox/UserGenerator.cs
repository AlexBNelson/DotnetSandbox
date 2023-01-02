using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace Sandbox
{
    public static class UserGenerator
    {
        public static List<User> GenerateUsers()
        {
            

            var faker = new Faker<User>()
               .RuleFor(u => u.Name, f => f.Name.FullName())
               .RuleFor(u => u.Role, f => f.Commerce.Department());


            var res = faker.Generate(500);

            return res;

        }

        public static List<User> GenerateDynamicUsers()
        {
            dynamic users = GenerateUsers();
            return users;
        }
    }
}
