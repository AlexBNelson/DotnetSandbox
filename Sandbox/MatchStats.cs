using Bogus.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class MatchStats
    {

        public List<Goal> Goals { get; init; }
        public List<Assist> Assists { get; init; }

        public void Deconstruct(out string topScorer, out int topScorerGoals)
        {
            var orderedGoals = Goals.Select(x => x.Scorer);

            topScorer = orderedGoals.GroupBy(i => i)
                .OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Key).First();

            topScorerGoals = orderedGoals.GroupBy(i => i)
                .OrderByDescending(grp => grp.Count()).First().Count();
        }
    }
}
