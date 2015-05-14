using System;
using System.Timers;
using Ninject;
using Realm.Event;
using Realm.Library.Common;
using Realm.Library.Common.Logging;
using Realm.Server.Properties;

namespace Realm.Server
{
    /// <summary>
    /// 
    /// </summary>
    public class GameLoopProcessor : ILoopProcessor
    {
        public ITimer SegmentTimer { get; private set; }
        private int SegmentCounter { get; set; }
        private int RoundCounter { get; set; }
        private int TurnCounter { get; set; }
        private int RevolutionCounter { get; set; }
        private bool Running { get; set; }

        [Inject]
        public ILogWrapper Log { get; set; }

        [Inject]
        public IEventManager EventManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timer"></param>
        public GameLoopProcessor([Named("GameTimer")] ITimer timer)
        {
            SegmentTimer = timer;
            SegmentTimer.Elapsed += Timer_OnGameSegment;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            Validation.IsNotNull(SegmentTimer, "SegmentTimer");

            try
            {
                Log.InfoFormat(MessageResources.MSG_GAME_START, SegmentTimer.Interval);
                SegmentTimer.Start(null);
                Running = true;
            }
            catch (Exception ex)
            {
                ex.Handle<GeneralException>(ExceptionHandlingOptions.RecordOnly, Log);
                Stop();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            Log.InfoFormat(MessageResources.MSG_GAME_STOP, DateTime.Now);
            SegmentTimer.Stop();
            Running = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsRunning { get { return Running; } }

        private void Timer_OnGameSegment(object sender, ElapsedEventArgs e)
        {
            SegmentCounter++;
            EventManager.ThrowEvent<OnGameSegment>(this, new EventTable { { "segment", SegmentCounter } });

            //// 1 Round is 10 Segments (default is 5 seconds)
            RoundCounter++;
            if (RoundCounter >= 10)
            {
                RoundCounter = 0;
                EventManager.ThrowEvent<OnGameRound>(this, new EventTable { { "round", RoundCounter } });
            }

            //// 1 Turn is 10 Rounds (default is 50 seconds)
            TurnCounter++;
            if (TurnCounter >= 100)
            {
                TurnCounter = 0;
                EventManager.ThrowEvent<OnGameTurn>(this, new EventTable { { "turn", TurnCounter } });
            }

            //// 1 Revolution is 100 Rounds (default is 500 Seconds)
            RevolutionCounter++;
            if (RevolutionCounter >= 1000)
            {
                RevolutionCounter = 0;
                EventManager.ThrowEvent<OnGameRevolution>(this, new EventTable { { "revolution", RevolutionCounter } });
            }
        }
    }
}
