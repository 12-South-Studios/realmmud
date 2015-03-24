using System;
using System.Linq;
using Realm.Command.Interfaces;
using Realm.Command.Properties;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Entity;
using Realm.Entity.Entities;
using Realm.Library.Common;

namespace Realm.Command.Parsers
{
    /// <summary>
    ///
    /// </summary>
    public class SocialCommandParser : Parser
    {
        private readonly IStaticDataManager _staticDataManager;

        ///  <summary>
        /// 
        ///  </summary>
        ///  <param name="commandManager"></param>
        /// <param name="staticDataManager"></param>
        public SocialCommandParser(ICommandManager commandManager, IStaticDataManager staticDataManager)
            : base(commandManager)
        {
            _staticDataManager = staticDataManager;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="biote"></param>
        /// <param name="verb"></param>
        /// <returns></returns>
        public SocialDef GetSocial(IBiota biote, string verb)
        {
            var socials = _staticDataManager.GetStaticData(Globals.Globals.SystemTypes.Social);
            return socials.Select(def => def.CastAs<SocialDef>())
                .FirstOrDefault(socialDef => socialDef.DisplayName.Equals(verb, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="biote"></param>
        /// <param name="social"></param>
        /// <param name="phrase"></param>
        public void ParseSocial(IBiota biote, SocialDef social, string phrase)
        {
            var executor = CommandManager.CommandExecutor;

            if (string.IsNullOrEmpty(phrase))
            {
                if (biote is ICharacter)
                    executor.Report(Globals.Globals.MessageScopeTypes.Character, social.CharNoArg, biote);
                executor.Report(Globals.Globals.MessageScopeTypes.SpaceLimited, social.OthersNoArg, biote);
                return;
            }

            IGameEntity ent = null;
            // TODO: Get the entity from the phrase somehow
            if (ent.IsNull())
            {
                if (biote is ICharacter)
                    executor.Report(Globals.Globals.MessageScopeTypes.Character, Resources.MSG_NOTHING_HERE, biote);
                return;
            }

            if (ent is ICharacter || ent is IMobile)
            {
                if (biote is ICharacter)
                    executor.Report(Globals.Globals.MessageScopeTypes.Character, Resources.MSG_NO_OBJECT, biote);
                return;
            }

            var oTargetBiote = ent as IBiota;
            if (oTargetBiote.IsNull()) return;

            if (oTargetBiote == biote)
            {
                if (biote is ICharacter)
                    executor.Report(Globals.Globals.MessageScopeTypes.Character, social.CharAuto, biote);
                executor.Report(Globals.Globals.MessageScopeTypes.SpaceLimited, social.OthersAuto, biote);
                return;
            }

            if (oTargetBiote.Location != biote.Location)
            {
                if (biote is ICharacter)
                    executor.Report(Globals.Globals.MessageScopeTypes.Character, Resources.MSG_NOT_IN_SPACE, biote, null, oTargetBiote);
                return;
            }

            if (biote is ICharacter)
                executor.Report(Globals.Globals.MessageScopeTypes.Character, social.CharFound, biote, oTargetBiote);

            if (oTargetBiote is ICharacter)
                executor.Report(Globals.Globals.MessageScopeTypes.Victim, social.VictFound, biote, oTargetBiote);

            executor.Report(Globals.Globals.MessageScopeTypes.SpaceLimited, social.OthersFound, biote, oTargetBiote);
        }
    }
}