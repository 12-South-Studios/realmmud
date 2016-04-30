using System.Linq;
using Realm.Communication.Properties;
using Realm.Data;
using Realm.Data.Definitions;
using Realm.Entity;
using Realm.Entity.Entities.Interfaces;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Objects;

namespace Realm.Communication
{
    /// <summary>
    ///
    /// </summary>
    public class Channel : GameEntity
    {
        private long OwnerId { get; set; }

        private Globals.ChannelTypes ChannelType { get; set; }

        private int Bits { get; set; }

        private DictionaryAtom Data { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <param name="def"></param>
        public Channel(long id, string name, DictionaryAtom data, Definition def)
            : base(id, name, def)
        {
            MemberRepository = new ChannelMemberRepository();

            Data = data;
            OwnerId = data.GetInt("OwnerID");
            ChannelType = EnumerationExtensions.GetEnum<Globals.ChannelTypes>(data.GetInt("ChannelTypeID"));
            Bits = data.GetInt("Bits");
        }

        private ChannelMemberRepository MemberRepository { get; set; }

        /// <summary>
        ///
        /// </summary>
        private ChannelDef ChannelDef => Definition.CastAs<ChannelDef>();

        /// <summary>
        /// Changes the ownership of the channel from one owner to another
        /// </summary>
        public void ChangeOwnership(ICharacter newOwner)
        {
            Validation.IsNotNull(newOwner, "newOwner");
            Validation.Validate(MemberRepository.Contains(newOwner.ID));
            Validation.Validate(newOwner.ID != OwnerId);

            OwnerId = newOwner.ID;
        }

        /// <summary>
        /// Adds a new member to the channel
        /// </summary>
        public bool AddMember(ICharacter character)
        {
            Validation.IsNotNull(character, "character");
            Validation.Validate(!MemberRepository.Contains(character.ID));

            return MemberRepository.Add(character.ID, character);
        }

        /// <summary>
        /// Removes a member from the channel
        /// </summary>
        public bool RemoveMember(ICharacter character)
        {
            Validation.IsNotNull(character, "character");
            Validation.Validate(MemberRepository.Contains(character.ID));

            return MemberRepository.Delete(character.ID);
        }

        /// <summary>
        /// Verifies if the user is a member of the channel
        /// </summary>
        public bool IsMember(ICharacter character)
        {
            Validation.IsNotNull(character, "character");

            return MemberRepository.Contains(character.ID);
        }

        /// <summary>
        /// Verifies if the user can join the channel
        /// </summary>
        public bool IsAllowed(ICharacter character)
        {
            Validation.IsNotNull(character, "character");

            return ChannelDef.Admin && character.GetFlagContext().IsAdmin();
        }

        /// <summary>
        /// Sends the specified message to the channel from the given user
        /// </summary>
        public void SendText(ICharacter sender, string message, params object[] parameters)
        {
            Validation.IsNotNull(sender, "sender");
            Validation.IsNotNullOrEmpty(message, "message");
            Validation.Validate(MemberRepository.Count > 0);

            if (ChannelDef.ReadOnly)
            {
                string messageFormat = Resources.MSG_CHANNEL_NOINPUT;
                // TODO: Send text to the user
                return;
            }

            string messageText = string.Format(message, parameters);
            if (IsEmote(messageText))
                messageText = messageText.Remove(0, 1);

            MemberRepository.Values.ToList().ForEach(member =>
                {
                    var ctx = member.GetContext("PlayerChannelContext").CastAs<PlayerChannelContext>();
                    var pc = ctx.GetChannel(ID);
                    if (!pc.IsOn) return;

                    string messageFormat = GetMessageFormat(IsEmote(messageText), member == sender);

                    //member.User..ReportToCharacter(messageFormat, member, null, this, message);
                    // TODO: How to send text to the user that runs through CommandManager?  (CmdMgr references this library) 
                });
        }

        private static bool IsEmote(string message)
        {
            return message[0].ToString() == ":";
        }

        private static string GetMessageFormat(bool isEmote, bool isSelf)
        {
            if (isEmote && isSelf)
                return Resources.MSG_CHANNEL_EMOTE_SELF;
            if (isEmote)
                return Resources.MSG_CHANNEL_EMOTE_OTHER;
            if (isSelf)
                return Resources.MSG_CHANNEL_SAY_SELF;
            return Resources.MSG_CHANEL_SAY_OTHER;
        }
    }
}