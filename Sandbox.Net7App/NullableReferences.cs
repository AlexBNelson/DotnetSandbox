using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace Sandbox.Net7App
{
    internal class NullableReferences
    {
        public void AssignNullString()
        {
            string? notNull = default;
            var length = notNull!.Length;
            string? nullable = default;
            notNull = nullable; // null forgiveness
        }
    }
}
