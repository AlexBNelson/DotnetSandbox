using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Net7App
{
    //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/stackalloc
    //https://pvs-studio.com/en/blog/posts/csharp/1011/
    //https://devblogs.microsoft.com/dotnet/performance_improvements_in_net_7/#vectorization
    internal class LowLevel
    {
        public void ManipulateVector()
        {
            Vector128<byte> v = Vector128.Create((byte)123);
            while (true)
            {
                WithIntrinsics(v);
                WithVector(v);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int WithIntrinsics(Vector128<byte> v) => Sse2.MoveMask(v);

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static uint WithVector(Vector128<byte> v) => v.ExtractMostSignificantBits();

        public int UnrolledFibbionacci(ReadOnlySpan<int> source)
        {
            var result = 0;

            var lastBlockIndex = source.Length - (source.Length % 4);

            result += source[0];
            result += source[1] + source[0];

            int i=0;

            while(i< lastBlockIndex && i>2)
            {
                result += 
                result += (source[i+1] + source[i] + source[i - 1]);
                result += (source[i+2] + source[i + 1] + source[i]);
                result += (source[i+3] + source[i+2] + source[i+1]);

                i += 4;
            }

            while (i < source.Length)
            {
                result += (source[i] + source[i - 1] + source[i - 2]);
            }

            return result;
        }
        public string ManipulateStack()
        {
            int length = 3;
            Span<int> numbers = stackalloc int[length];
            for (var i = 0; i < length; i++)
            {
                numbers[i] = i;
            }

            return numbers.ToString();
        }
        public int[] RolledLoop()
        {
            var array = new int[100];

            for(int i=0; i<100; i++)
            {
                array[i] = i;
            }

            return array;
        }

        public int[] unRolledLoop()
        {
            var array = new int[100];

            for (int i = 0; i < 100; i+=5)
            {
                array[i] = i;
                array[i + 1] = i;
                array[i+2] = i;
                array[i + 3] = i;
                array[i + 4] = i;
                
            }

            return array;
        }
    }
}
