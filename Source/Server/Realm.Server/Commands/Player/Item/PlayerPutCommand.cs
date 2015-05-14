//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Server.Events;
//using Realm.Server.Item;
//using Realm.Server.NPC;
//using Realm.Server.Players;
//using Realm.Server.Properties;
//using Realm.Server.Zones;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Bind command
//    /// </summary>
//    public class PlayerPutCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerPutCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerPutCommand(int id, string name, Definition definition)
//            : base(id, name, definition)
//        {
//            //// do nothing
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        public override void Execute()
//        {
//            var oUser = Game.CurrentUser();
//            var keyword = oUser.GetLastCommand();
//            if (CommandManager.KeywordCheckAndNotify(oUser, keyword))
//                return;

//            Execute(oUser.GetCurrentCharacter(), null, null, keyword, true);
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        /// <param name="oActor"><see cref="Biota"/> object doing the action</param>
//        /// <param name="obj1">first object being acted upon</param>
//        /// <param name="obj2">second object being acted upon</param>
//        /// <param name="aKeyword">Phrase or keyword string</param>
//        /// <param name="aMessage">Flag indicating whether or not to send the message to the client</param>
//        public void Execute(IBiota oActor, IGameEntity obj1, IGameEntity obj2, string aKeyword, bool aMessage = false)
//        {
//            var source = aKeyword.FirstWord();
//            var destination = aKeyword.SecondWord();

//            // Find the source somewhere
//            var validLocs = Globals.Globals.EntityLocationTypes.Inventory.GetValue()
//                | Globals.Globals.EntityLocationTypes.Equipment.GetValue()
//                | Globals.Globals.EntityLocationTypes.Space.GetValue();
//            var result = TargetLocation.FindTargetEntity(oActor, source, validLocs);
//            if (null == result.FoundEntity)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter(MessageResources.MSG_NO_ITEM, oActor);
//                return;
//            }
//            var oSource = result.FoundEntity as ItemInstance;
//            if (oSource.IsNull()) return;

//            // Find the target
//            validLocs = Globals.Globals.EntityLocationTypes.Inventory.GetValue()
//                | Globals.Globals.EntityLocationTypes.Equipment.GetValue()
//                | Globals.Globals.EntityLocationTypes.Space.GetValue();
//            result = TargetLocation.FindTargetEntity(oActor, destination, validLocs);
//            if (null == result.FoundEntity)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter(MessageResources.MSG_NO_ITEM, oActor);
//                return;
//            }
//            var oTarget = result.FoundEntity as ItemInstance;
//            if (oTarget.IsNull()) return;

//            // is the target a container?
//            if (!oTarget.IsType("container"))
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#not_container#", oActor, null, oTarget);
//                return;
//            }

//            // are the source and target the same?
//            if (oTarget == oSource)
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#cant_do_that#", oActor);
//                return;
//            }

//            // is the target open?
//            var container = oTarget as ContainerItemInstance;
//            if (container.IsNull()) return;

//            if (container.IsClosed)
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#item_closed#", oActor, null, oTarget);
//                return;
//            }

//            // can the source fit through the mouth of the target?
//            if (oSource.Size > container.MouthSize)
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#item_too_big#", oActor, null, oSource, oTarget);
//                return;
//            }

//            // can the target hold the source's volume?
//            var totalVolume = container.CalculateVolume();
//            if ((oSource.Volume + totalVolume) > container.VolumeLimit)
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#container_full#", oActor, null, oTarget);
//                return;
//            }

//            // can the target hold the source's weight?
//            var totalWeight = container.CalculateWeight();
//            if ((oSource.Weight + totalWeight) > container.WeightLimit)
//            {
//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#container_full#", oActor, null, oTarget);
//                return;
//            }

//            // move the item
//            oSource.Location.RemoveEntity(oSource);
//            oTarget.AddEntity(oSource);

//            if ((aMessage) && (oActor is Character))
//                CommandManager.ReportToCharacter("#put_item_self#", oActor, null, oSource, oTarget);
//            CommandManager.ReportToSpaceLimited("#put_item_other#", oActor, null, oSource, oTarget);

//            Game.SetProperty("last put", oSource);
//            var Space = oActor.Location as Space;
//            if (Space.IsNull()) return;

//            EventManager.ThrowEvent<OnPutItem>(oActor, new EventTable
//                                                           {
//                                                               {"Space", Space},
//                                                               {"source_ite", oSource}, 
//                                                               {"target_item", oTarget}
//                                                           });
//        }
//    }
//}
