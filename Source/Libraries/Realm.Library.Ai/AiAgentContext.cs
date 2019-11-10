using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Realm.Library.Common;
using Realm.Library.Common.Objects;

namespace Realm.Library.Ai
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AiAgentContext : IAiAgentContext
    {
        private readonly AiAgentRepository _repository;
        private ITimer _aiTimer;

        private int NextBucket { get; set; }

        private int CurrentBucket { get; set; }

        private int NumberBuckets { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timer"></param>
        /// <param name="maxBuckets"></param>
        /// <param name="timerInterval"></param>
        public AiAgentContext(ITimer timer, int maxBuckets, int timerInterval)
        {
            Validation.IsNotNull(timer, "timer");
            Validation.Validate<ArgumentOutOfRangeException>(maxBuckets >= 1);
            Validation.Validate<ArgumentOutOfRangeException>(timerInterval >= 50);

            _repository = new AiAgentRepository();
            NumberBuckets = maxBuckets;

            NextBucket = 1;
            CurrentBucket = 1;

            _aiTimer = timer;
            _aiTimer.Elapsed += AiTimerElapsed;
            _aiTimer.Interval = timerInterval;

            Enumerable.Range(1, NumberBuckets).ToList().ForEach(i => _repository.Add(i, new List<IAiAgent>()));
        }

        /// <summary>
        /// 
        /// </summary>
        ~AiAgentContext()
        {
            if (!_aiTimer.IsNotNull()) return;
            _aiTimer.Stop();
            _aiTimer = null;
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> OnAgentRegistered;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> OnAgentUnregistered;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> OnWake;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> OnSleep;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> OnPause;

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<int> Buckets => _repository.Keys;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bucket"></param>
        /// <returns></returns>
        public IList<IAiAgent> GetAgents(int bucket)
        {
            Validation.Validate<ArgumentOutOfRangeException>(bucket >= 0 && bucket <= NumberBuckets);

            return !_repository.Contains(bucket)
                ? new List<IAiAgent>()
                : _repository.Get(bucket);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Pause
        {
            get { return IsPaused; }
            set
            {
                IsPaused = value;
                if (_aiTimer.IsNotNull())
                {
                    if (IsPaused)
                        _aiTimer.Stop();
                    else
                        _aiTimer.Start(_aiTimer.Interval);
                }
                OnPause?.Invoke(this, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsPaused { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsEnabled => _aiTimer.Enabled;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="agent"></param>
        public void Register(IAiAgent agent)
        {
            Validation.IsNotNull(agent, "agent");

            var entities = _repository.Get(NextBucket);
            entities.Add(agent);

            NextBucket++;
            if (NextBucket > NumberBuckets)
                NextBucket = 1;

            OnAgentRegistered?.Invoke(this, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="agent"></param>
        public void Unregister(IAiAgent agent)
        {
            Validation.IsNotNull(agent, "agent");

            _repository.Keys.Select(key => _repository.Get(key))
                       .Where(entityList => entityList.Contains(agent))
                       .ToList()
                       .ForEach(entityList
                                =>
                           {
                               entityList.Remove(agent);
                               OnAgentUnregistered?.Invoke(this, null);
                           });
        }

        /// <summary>
        /// 
        /// </summary>
        public void WakeMobs()
        {
            Parallel.ForEach(_repository.Keys,
                bucket => Parallel.ForEach(_repository.Get(bucket),
                    agent => agent.Wake()));

            OnWake?.Invoke(this, null);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SleepMobs()
        {
            Parallel.ForEach(_repository.Keys,
                bucket => Parallel.ForEach(_repository.Get(bucket),
                    agent => agent.Sleep()));

            OnSleep?.Invoke(this, null);
        }

        private void AiTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Parallel.ForEach(_repository.Get(CurrentBucket), agent => agent.OnTick());

            CurrentBucket++;
            if (CurrentBucket > NumberBuckets)
                CurrentBucket = 1;
        }
    }
}