// See https://aka.ms/new-console-template for more informatio

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Sandbox;
using Sandbox.Serialization;
using System.Text.Json;

RunPeriodicTimedOperation();

//var average = ConcurrentMatchMinuteRandom.GetWeightedValuesAverage(4);

//Console.WriteLine(average.ToString());

//var matchStats = MatchStatsGenerator.GenerateMatchStats();

//Console.WriteLine(JsonSerializer.Serialize(matchStats));

//Console.ReadLine();

//var userStrings = new List<string>();

//var userList = UserGenerator.GenerateUsers();

//userList.ForEach(user => userStrings.Add(ObjectBoxer.boxObject(user).Length.ToString()));

//var summary = BenchmarkRunner.Run<Benchmarks>();

//var goalMinutes = MatchStatsGenerator.GetGoalMinutes(matchStats.Goals).ToList();

//UserSerializer userSerializer = new UserSerializer();


//Func<List<int>> weightedRandomValueGenerate = () =>
//{
//    var weightedRandomValues = new List<int>();
//    for (int i = 1; i < 10; i++)
//    {
//        weightedRandomValues.Add(ConcurrentMatchMinuteRandom.GenerateWeightedValues(10));

//    }
//    return weightedRandomValues;
//};

//var weightedRandomValues = weightedRandomValueGenerate.Invoke();

//var average = weightedRandomValues.Average();
Console.ReadLine();
 static async void RunPeriodicTimedOperation()
{
    Console.WriteLine("Press any key to start op");
    Console.ReadKey();

    var task = new BackgroundTask(TimeSpan.FromMilliseconds(1000));
    task.Start();

    Console.WriteLine("Press any key to stop op");
    Console.ReadKey();

    await task.StopAsync();


}