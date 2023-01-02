using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    static public class ObjectBoxer
    {
        public static char[] boxObject(User user)
        {

            Func<char[]> slicer = () =>
            {
                var nameArray = user.Name.ToCharArray();
                var roleArray = user.Role.ToCharArray();

                var combinedArray = new char[nameArray.Length + roleArray.Length];

                nameArray.CopyTo(combinedArray, 0);
                roleArray.CopyTo(combinedArray, nameArray.Length);

                combinedArray.Reverse();

                return combinedArray;
            };

            return slicer.Invoke();
        }

        public static char[] noBoxObject(User user)
        {
            var nameArray = user.Name.ToCharArray();
            var roleArray = user.Role.ToCharArray();

            var combinedArray = new char[nameArray.Length + roleArray.Length];

            nameArray.CopyTo(combinedArray, 0);
            roleArray.CopyTo(combinedArray, nameArray.Length);

            combinedArray.Reverse();

            return combinedArray;
        }

    }
}
