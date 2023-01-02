using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

//https://www.youtube.com/watch?v=J4JL4zR_l-0
namespace Sandbox
{
    internal class MatchService : BackgroundService
    {
        private readonly PeriodicTimer _timer = new PeriodicTimer(TimeSpan.FromMilliseconds(2000));
        MatchStats matchStats = MatchStatsGenerator.GenerateMatchStats();
        int counter = 0;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested && counter<matchStats.Goals.Count)
            {
                Console.WriteLine(JsonSerializer.Serialize(matchStats.Goals[counter]));
                Console.WriteLine(matchStats?.Assists[counter].Minute == matchStats?.Goals[counter].Minute ?
                    JsonSerializer.Serialize(matchStats?.Assists[counter]) :
                    "no Assist");

                counter++;

                //Less accurate timer method, as opposed to PeriodicTimer thats based on start time
                await Task.Delay(matchStats.Goals[counter].Minute * 1000, stoppingToken);
                await _timer.WaitForNextTickAsync(stoppingToken);
            }
            await Task.Yield();
        }
    }
}
