using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Net7App
{
    internal class Enumeration
    {
        public IEnumerable<int> YieldExample()
        {
            foreach(int value in Enumerable.Range(0, 9))
            {
                yield return value;
            }
        }
    }
}
