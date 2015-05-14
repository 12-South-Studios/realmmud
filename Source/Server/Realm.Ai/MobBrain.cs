using Realm.Ai.Properties;
using Realm.Entity;
using Realm.Entity.Entities;
using Realm.Library.Ai;
using Realm.Library.Common;
using Realm.Library.Common.Logging;

namespace Realm.Ai
{
    /// <summary>
    ///
    /// </summary>
    public class MobBrain : AiAgent
    {
        private int _loggingDumpCounter;
        private readonly ILogWrapper _log;
        private readonly IEntityManager _entityManager;

        ///  <summary>
        /// 
        ///  </summary>
        ///  <param name="owner"></param>
        /// <param name="entityManager"></param>
        /// <param name="messageHandler"></param>
        ///  <param name="behavior"></param>
        /// <param name="log"> </param>
        public MobBrain(IEntity owner, IMessageContext messageHandler, IBehavior behavior, ILogWrapper log, 
            IEntityManager entityManager)
            : base(owner, messageHandler, behavior)
        {
            _entityManager = entityManager;
            _log = log;
        }

        /// <summary>
        /// Handle the game tick
        /// </summary>
        public override void OnTick()
        {
            if (IsAsleep)
                return;

            _loggingDumpCounter++;

            if (CurrentState.IsNull())
                PushState(NeedState());
            else
                CurrentState.Execute();

            if (_loggingDumpCounter > 60)
            {
                Messages.Dump(_log.Log);
                _loggingDumpCounter = 0;
            }
        }

        /// <summary>
        /// Determine what AiState to push onto the stack
        /// </summary>
        public override IAiState NeedState()
        {
            var mob = CheckMobAndReturn();
            if (mob.IsNull()) return null;

            if (mob.IsDead)
            {
                Messages.Add(string.Format(Resources.MSG_AI_NEEDSTATE_ISDEAD, Owner.ID, Owner.Name));
                return _entityManager.GetDeadState(mob);
            }

            // Let the behavior determine what state is needed
            // then go below and let the rest of the code execute
            if (Behavior.IsNotNull())
            {
                var newState = Behavior.NeedState();
                if (newState.IsNotNull())
                {
                    Messages.Add(string.Format(Resources.MSG_AI_NEEDSTATE_STATE,
                        Owner.ID, Owner.Name, newState.ID, newState.Name));
                    return newState;
                }
            }

            Messages.Add(string.Format(Resources.MSG_AI_NEEDSTATE_NOTHING, Owner.ID, Owner.Name));
            return _entityManager.GetDoNothingState(mob);
        }

        /// <summary>
        /// If the owner is not a mobinstance then there is an error, log it and return
        /// </summary>
        private IRegularMob CheckMobAndReturn()
        {
            var mob = Owner as IRegularMob;
            if (mob.IsNull())
            {
                _log.ErrorFormat(Resources.ERR_AI_OWNER_NOT_MOBILE, Owner.ID, Owner.Name);
                return null;
            }
            return mob;
        }
    }
}