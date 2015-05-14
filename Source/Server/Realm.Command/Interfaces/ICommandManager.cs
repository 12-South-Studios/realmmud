using System;
using Realm.Command.Parsers;
using Realm.Entity;
using Realm.Library.Common;

namespace Realm.Command.Interfaces
{
    public interface ICommandManager
    {
        IVariableHelper VariableHelper { get; }
        IHelper<Action> CommandHelper { get; }
        CommandExecutor CommandExecutor { get; }
        CommandRepository CommandRepository { get; }

        Parser GetParser(string name);

        #region Command Executor

        bool Execute(IGameEntity entity, string command);

        bool Execute(IGameEntity entity, string verb, string phrase);

        void Report(Globals.Globals.MessageScopeTypes scope, string message, IEntity oActor,
                    IEntity oVictim = null, object oDirectObject = null, object oIndirectObject = null,
                    IGameEntity oSpace = null, object oExtra = null);

        void Report(Globals.Globals.MessageScopeTypes scope, string message, ReportData data);

        #endregion Command Executor

        /*GameCommandFactory Factory { get; }
        CommandRepository Commands { get; }
        bool Execute(IGameUser user, string command);
        bool Execute(IGameUser oUser, string verb, string keyword);

        T GetCommand<T>(string aCommand) where T : IGameCommand;
        IGameCommand GetCommand(string aCommand);

        IDictionary<string, object> PopulateCommandArgs(IBiota oActor, GameEntityTemplate obj1,
                                                        GameEntityTemplate obj2, string aKeyword, bool aMessage = false);

        void Report(Globals.Globals.MessageScopeTypes scope, string message, ReportData data);

        void Report(Globals.Globals.MessageScopeTypes scope, string message, IEntity oActor, IEntity oVictim = null,
                    object oDirectObject = null, object oIndirectObject = null, IGameEntity oSpace = null,
                    object oExtra = null);

        StringBuilder ParseString(StringBuilder sb, ReportData data = null);

        ReportData ToReportData(IEntity oActor = null, IEntity oVictim = null,
                                object oDirectObject = null, object oIndirectObject = null, object oSpace = null,
                                object oExtra = null);*/
    }
}