using System;
using System.Linq;
using Realm.Command.Interfaces;
using Realm.Command.Properties;
using Realm.Data;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Entity.Entities.Interfaces;
using Realm.Entity.Interfaces;
using Realm.Library.Common.Objects;

namespace Realm.Command.Parsers
{
    public class SocialCommandParser : Parser
    {
        private readonly IStaticDataManager _staticDataManager;

        public SocialCommandParser(ICommandManager commandManager, IStaticDataManager staticDataManager)
            : base(commandManager)
        {
            _staticDataManager = staticDataManager;
        }

        public SocialDef GetSocial(IBiota biote, string verb)
        {
            var socials = _staticDataManager.GetStaticData(Globals.SystemTypes.Social);
            return socials.Select(def => def.CastAs<SocialDef>())
                .FirstOrDefault(socialDef => socialDef.DisplayName.Equals(verb, StringComparison.OrdinalIgnoreCase));
        }

        public void ParseSocial(IBiota biote, SocialDef social, string phrase)
        {
            var executor = CommandManager.CommandExecutor;

            if (string.IsNullOrEmpty(phrase))
            {
                if (biote is ICharacter)
                    executor.Report(Globals.MessageScopeTypes.Character, social.CharNoArg, biote);
                executor.Report(Globals.MessageScopeTypes.SpaceLimited, social.OthersNoArg, biote);
                return;
            }

            IGameEntity ent = null;
            // TODO: Get the entity from the phrase somehow
            if (ent == null)
            {
                if (biote is ICharacter)
                    executor.Report(Globals.MessageScopeTypes.Character, Resources.MSG_NOTHING_HERE, biote);
                return;
            }

            if (ent is ICharacter || ent is IMobile)
            {
                if (biote is ICharacter)
                    executor.Report(Globals.MessageScopeTypes.Character, Resources.MSG_NO_OBJECT, biote);
                return;
            }

            var oTargetBiote = ent as IBiota;
            if (oTargetBiote == null) return;

            if (oTargetBiote == biote)
            {
                if (biote is ICharacter)
                    executor.Report(Globals.MessageScopeTypes.Character, social.CharAuto, biote);
                executor.Report(Globals.MessageScopeTypes.SpaceLimited, social.OthersAuto, biote);
                return;
            }

            if (oTargetBiote.Location != biote.Location)
            {
                if (biote is ICharacter)
                    executor.Report(Globals.MessageScopeTypes.Character, Resources.MSG_NOT_IN_SPACE, biote, null, oTargetBiote);
                return;
            }

            if (biote is ICharacter)
                executor.Report(Globals.MessageScopeTypes.Character, social.CharFound, biote, oTargetBiote);

            if (oTargetBiote is ICharacter)
                executor.Report(Globals.MessageScopeTypes.Victim, social.VictFound, biote, oTargetBiote);

            executor.Report(Globals.MessageScopeTypes.SpaceLimited, social.OthersFound, biote, oTargetBiote);
        }
    }
}