using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Serialization
{
    public interface IUserSerializer
    {
        public string ReturnUsersListJson();
    }
}
