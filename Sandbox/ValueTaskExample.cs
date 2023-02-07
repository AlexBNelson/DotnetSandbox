using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    static internal class ValueTaskExample
    {
        static public ValueTask<string> ReadAsync(Stream stream)
        {
            try
            {
                var reader = new StreamReader(stream);
                string bytesRead = reader.ReadToEnd();
                return new ValueTask<string>(bytesRead);
            }
            catch (Exception e)
            {
                return new ValueTask<string>(Task.FromException<string>(e));
            }
        }
    }
}
