using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public static partial class ThingClass
    {
        private static partial string DoSomething();
    }

    public static partial class ThingClass
    {
        private static partial string DoSomething()
        {
            return DateTime.Now.ToString();
        }
    }
}
