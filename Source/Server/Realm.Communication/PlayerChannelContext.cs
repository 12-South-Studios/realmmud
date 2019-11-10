using System.Collections.Generic;
using System.Linq;
using Realm.Entity.Interfaces;
using Realm.Library.Common.Entities;

namespace Realm.Communication
{
    /// <summary>
    ///
    /// </summary>
    public class PlayerChannelContext : EntityContext<IGameEntity>
    {
        private readonly PlayerChannelRepository _repository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="parent"></param>
        public PlayerChannelContext(IGameEntity parent)
            : base(parent)
        {
            _repository = new PlayerChannelRepository();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="handle"></param>
        /// <returns></returns>
        public bool AddChannel(long id, string handle)
        {
            return !(_repository.Contains(handle)
                || _repository.Values.Any(x => x.Id == id))
                && _repository.Add(handle, new PlayerChannel(id, true, handle));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoveChannel(long id)
        {
            var channel = GetChannel(id);
            return channel != null && RemoveChannel(channel.Handle);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public bool RemoveChannel(string handle)
        {
            return _repository.Contains(handle) && _repository.Delete(handle);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool HasChannel(long id)
        {
            return _repository.Values.Any(x => x.Id == id);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public PlayerChannel GetChannel(string handle)
        {
            return _repository.Contains(handle)
                ? _repository.Get(handle)
                : null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlayerChannel GetChannel(long id)
        {
            return HasChannel(id)
                ? _repository.Values.First(x => x.Id == id)
                : null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<PlayerChannel> GetChannels()
        {
            return _repository.Values.ToList();
        }
    }
}