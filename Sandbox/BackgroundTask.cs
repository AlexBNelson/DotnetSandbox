namespace Sandbox
{
    public class BackgroundTask
    {
        private Task? _timerTask;
        private readonly PeriodicTimer _timer;
        private readonly CancellationTokenSource _cancellationTokenSource = new();
        private MatchStats matchStats = MatchStatsGenerator.GenerateMatchStats();
        private int minuteCount = 0;

        public BackgroundTask(TimeSpan interval)
        {
            _timer = new PeriodicTimer(interval);
        }

        public async Task AnyMatchEvent(int minute)
        {
            try
            {


                while (await _timer.WaitForNextTickAsync(_cancellationTokenSource.Token))
                {
                    if (matchStats.Goals.Any(x => x.Minute == minute))
                    {
                        Console.WriteLine("goal scored!");

                    }
                    else
                    {
                        Console.WriteLine("Nothing to Report");
                    }

                    minuteCount++;
                }
            }
            catch(OperationCanceledException exception)
            {

            }
            
        }

        public void Start()
        {
            _timerTask = AnyMatchEvent(minuteCount);
        }

        public async Task StopAsync()
        {
            if(_timerTask is null)
            {
                return;
            }

            _cancellationTokenSource.Cancel();
            await _timerTask;
            _cancellationTokenSource.Dispose();
            Console.WriteLine("Task Cancelled");
        }
    }
}
