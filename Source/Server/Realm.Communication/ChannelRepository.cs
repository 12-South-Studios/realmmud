using System.Linq;
using Realm.Library.Common;
using Realm.Library.Patterns.Repository;

namespace Realm.Communication
{
    public class ChannelRepository : Repository<long, Channel>
    {
        public Channel Get(string aName)
        {
            return Values.FirstOrDefault(channel => channel.CompareName(aName));
        }

        new public Channel Get(long aId)
        {
            return Values.FirstOrDefault(channel => channel.ID == aId);
        }

        new public void Add(long aId, Channel channel)
        {
            if (Get(aId).IsNull() && channel.IsNotNull())
                base.Add(aId, channel);
        }

        new public void Delete(long aId)
        {
            if (Get(aId).IsNotNull())
                base.Delete(aId);
        }
    }
}