using System.Linq;
using Realm.Library.Common.Objects;
using Realm.Standard.Patterns.Repository;

namespace Realm.Communication
{
    public class ChannelRepository : Repository<long, Channel>
    {
        public Channel Get(string aName)
        {
            return Values.FirstOrDefault(channel => channel.CompareName(aName));
        }

        public new Channel Get(long aId)
        {
            return Values.FirstOrDefault(channel => channel.ID == aId);
        }

        public new void Add(long aId, Channel channel)
        {
            if (Get(aId) == null && channel != null)
                base.Add(aId, channel);
        }

        public new void Delete(long aId)
        {
            if (Get(aId) != null)
                base.Delete(aId);
        }
    }
}