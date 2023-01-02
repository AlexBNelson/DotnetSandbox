using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public record User
    {
        public User()
        {
                
        }
        public User(string name, string role)=> (Name,Role) = (name,role);
        public string Name { get; init; }
        public string Role { get; set; }
    }
}
