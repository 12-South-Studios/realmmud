using System;
using Realm.Command.Interfaces;
using Realm.Communication;
using Realm.Entity.Entities;
using Realm.Library.Common;

namespace Realm.Command.Parsers
{
    /// <summary>
    ///
    /// </summary>
    public class PlayerChannelParser : Parser
    {
        private readonly ChannelManager _channelManager;

        ///  <summary>
        /// 
        ///  </summary>
        ///  <param name="commandManager"></param>
        /// <param name="channelManager"></param>
        public PlayerChannelParser(ICommandManager commandManager, IChannelManager channelManager)
            : base(commandManager)
        {
            _channelManager = (ChannelManager)channelManager;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="character"></param>
        /// <param name="verb"></param>
        /// <returns></returns>
        public Channel CheckChannelHandle(ICharacter character, string verb)
        {
            var ctx = character.GetContext("PlayerChannelContext").CastAs<PlayerChannelContext>();

            Channel foundChannel = null;
            ctx.GetChannels().ForEach(pc =>
                {
                    var channel = _channelManager.GetChannel(pc.ID);
                    if (pc.Handle.Equals(verb, StringComparison.OrdinalIgnoreCase)
                        || channel.Name.Equals(verb, StringComparison.OrdinalIgnoreCase))
                        foundChannel = channel;
                });
            return foundChannel;
        }
    }
}