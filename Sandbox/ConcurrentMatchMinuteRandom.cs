using Bogus.Bson;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public static class ConcurrentMatchMinuteRandom
    {
        [ThreadStatic]
        private static Random? _local;

        public static Random Instance => _local ??= new Random();

        public static int GenerateWeightedValues(int count)
        {
            var provisionalValue = Instance.Next(count);

            while (Instance.Next(provisionalValue) > 1)
            {
                provisionalValue = Instance.Next(count);
            }

            return provisionalValue;
        }

        public static double GetWeightedValuesAverage(int count)
        {
            Func<List<int>> weightedRandomValueGenerate = () =>
            {
                var weightedRandomValues = new List<int>();
                for (int i = 1; i < 100; i++)
                {
                    weightedRandomValues.Add(GenerateWeightedValues(count));

                }
                return weightedRandomValues;
            };

            var weightedRandomValues = weightedRandomValueGenerate.Invoke();

            return weightedRandomValues.Average();
        }
    }



}
