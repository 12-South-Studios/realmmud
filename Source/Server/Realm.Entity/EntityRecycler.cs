using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ninject;
using Realm.Entity.Events;
using Realm.Entity.Interfaces;
using Realm.Entity.Properties;
using Realm.Event;
using Realm.Library.Common;
using Realm.Library.Common.Events;
using Realm.Library.Common.Exceptions;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Logging;
using Realm.Library.Common.Objects;

namespace Realm.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class EntityRecycler : Library.Common.Objects.Entity, IEntityRecycler
    {
        private readonly ConcurrentDictionary<long, IGameEntity> _recycledEntities;
        private readonly ILogWrapper _log;
        private readonly IEventManager _eventManager;

        public ITimer Timer { get; private set; }

        ///  <summary>
        /// 
        ///  </summary>
        ///  <param name="eventManager"> </param>
        ///  <param name="log"> </param>
        /// <param name="timer"></param>
        public EntityRecycler(IEventManager eventManager, ILogWrapper log, [Named("RecycleTimer")] ITimer timer)
            : base(1, "EntityRecycler")
        {
            _log = log;
            _recycledEntities = new ConcurrentDictionary<long, IGameEntity>();
            _eventManager = eventManager;

            Timer = timer;
            Timer.Elapsed += _timer_Elapsed;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_recycledEntities.IsEmpty) return;

            var entityList = _recycledEntities.Values.ToList();
            _recycledEntities.Clear();

            while (entityList.Count > 0)
            {
                IGameEntity entity = entityList[0];
                entityList.RemoveAt(0);

                if (entity.IsNull() || !(entity is Library.Common.Objects.Entity)) continue;

                entity.CastAs<Library.Common.Objects.Entity>().Dispose();
            }
            entityList.Clear();

            if (_recycledEntities.Count <= 0)
                Timer.Stop();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool RecycleEntity(IGameEntity entity)
        {
            if (_recycledEntities.ContainsKey(entity.ID)) return false;

            entity.Location = null;
            var returnVal = _recycledEntities.TryAdd(entity.ID, entity);
            if (_recycledEntities.Count > 0)
                Timer.Start();
            return returnVal;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool SaveRecycledEntity(IGameEntity entity, IGameEntity location)
        {
            if (!_recycledEntities.ContainsKey(entity.ID)) return false;

            var entityId = entity.ID;
            Task<bool> task = null;
            CancellationTokenSource tokenSource = null;

            try
            {
                tokenSource = new CancellationTokenSource();
                task = Task.Factory.StartNew(() => SaveEntityFromRecycling(tokenSource.Token, entity), tokenSource.Token);
                if (task.IsNull())
                    throw new ObjectDisposedException("task");

                task.Wait();

                _log.InfoFormat(Resources.MSG_ENTITY_SAVED, entity.ID, task.Status);
            }
            catch (AggregateException ex)
            {
                _log.InfoFormat(Resources.MSG_TASK_CANCELLED, entity.ID);
                ex.InnerException.Handle(ExceptionHandlingOptions.RecordAndThrow, _log);
            }
            catch (Exception ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow, _log);
            }
            finally
            {
                task.Cancel(tokenSource);
            }

            if (_recycledEntities.Count <= 0)
                Timer.Stop();

            _eventManager.ThrowEvent<OnEntityDisposed>(this, new EventTable { { "EntityID", entityId } });
            entity.Location = location;
            return true;
        }

        private bool SaveEntityFromRecycling(CancellationToken token, IGameEntity entity)
        {
            Validation.IsNotNull(token, "token");
            Validation.IsNotNull(entity, "entity");

            return _recycledEntities.TryRemove(entity.ID, out entity);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Timer.IsNotNull())
                    Timer.Dispose();
                if (_recycledEntities.Count > 0)
                    _recycledEntities.Values.ToList().ForEach(x => x.CastAs<GameEntity>().Dispose());
            }
            base.Dispose(disposing);
        }
    }
}