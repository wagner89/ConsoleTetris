using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Tetris.GameClock
{
    public static class GameCycle
    {
        private const double GameCyclePeriodMilliseconds = 0.1d;

        private static readonly IScheduler GameClockScheduler = Scheduler.Default;

        public static readonly IObservable<long> GameCycleObservable = Observable.Timer(DateTimeOffset.Now,
                                                                                        TimeSpan.FromMilliseconds(GameCyclePeriodMilliseconds),
                                                                                        GameClockScheduler);
    }
}