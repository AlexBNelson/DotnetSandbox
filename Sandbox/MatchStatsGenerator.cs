using Bogus;
using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public delegate Team Del();
    public class MatchStatsGenerator
    {
        public static MatchStats GenerateMatchStats()
        {
            Del teamsGenerator = GenerateTeam;

            teamsGenerator.Invoke();
            teamsGenerator += GenerateTeam;
            var teams = teamsGenerator.GetInvocationList().Select(x => (Team)x.DynamicInvoke()).ToList();

            var goals = GenerateScores((teams[0], teams[1]));



            return new MatchStats()
            {
                Goals = goals,
                Assists = GenerateAssists((teams[0], teams[1]), goals)
            };
        }

        public static double GetAverageGoalMinute(List<Goal> goals)
        {
            return goals.Select(g => g.Minute).Min();
        }

        public static IEnumerable<int> GetGoalMinutes(List<Goal> goals)
        {
            //foreach(Goal g in goals)
            //{
            //    yield return g.Minute;
            //}
            yield return 1;

            yield return 2;
        }

        public static (string,int) GetTopScorer()
        {
            var stats = GenerateMatchStats();

            var(topScorer,topScorerGoals) = stats;

            return (topScorer,topScorerGoals);
        }


        private static List<Goal> GenerateScores((Team?, Team?) teams)
        {
            Func<Team, List<Goal>> GenerateGoals = (team) =>
            {
                List<Goal> result = new List<Goal>();

                var goalQuantity = ConcurrentMatchMinuteRandom.GenerateWeightedValues(6);

                for (int i = 0; i < goalQuantity; i++)
                {
                    result.Add(new Goal()
                    {
                        Team = team.Name,
                        Scorer = team.Players[ConcurrentMatchMinuteRandom.Instance.Next(11)],
                        Minute = ConcurrentMatchMinuteRandom.Instance.Next(90)
                    });
                }

                return result;
            };

            return GenerateGoals(teams.Item1).Concat(GenerateGoals(teams.Item2)).OrderBy(x => x.Minute).ToList();
        }

        private static List<Assist> GenerateAssists((Team?, Team?) teams, List<Goal> goals)
        {
            Func<bool> IsAssistedGoal = () => ConcurrentMatchMinuteRandom.Instance.Next(2) == 0;

            List<Assist> result = new List<Assist>();


            for (int i = 0; i < goals.Count; i++)
            {

                if (IsAssistedGoal.Invoke())
                {
                    var team = goals[i].Team == teams.Item1.Name ?
                            teams.Item1 :
                            teams.Item2;

                    team.Players.Remove(goals[i].Scorer);

                    result.Add(new Assist()
                    {
                        Team = goals[i].Team,
                        Assister = team.Players[ConcurrentMatchMinuteRandom.Instance.Next(team.Players.Count)],
                        Minute = goals[i].Minute
                    });
                }

            }

            return result;

        }

        private static Team GenerateTeam()
        {
            var playersFaker = new Faker();


            var players = Enumerable.Range(0, 11).Select(_ => playersFaker.Name.FullName()).ToList();

            var teamNameFaker = new Faker();

            var teamName = teamNameFaker.Vehicle.Manufacturer();

            return new Team(teamName, players);
        }
    }
}
