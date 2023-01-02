using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sandbox.Serialization
{
    public class UserSerializer : IUserSerializer
    {
        public string ReturnUsersListJson()
        {
            var users = UserGenerator.GenerateUsers();

            return JsonSerializer.Serialize(users.First(), SerializerContext.Default.User);
        }

        public string SerializeUsersListReturnFirst(List<User> users)
        {
            return JsonSerializer.Serialize(users.First(), SerializerContext.Default.User);
        }
    }
}
