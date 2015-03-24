//using System;
//using System.Collections.Generic;
//using Realm.Library.Ai;
//using Realm.Library.Common;
//using Realm.Library.Common.Exceptions;
//using Realm.Server.Ai;
//using Realm.Server.NPC;
//using Realm.Server.Properties;

//namespace Realm.Server.Factories
//{
//    public class GameAiStateFactory : GameObjectFactory
//    {
//        private readonly Dictionary<string, Type> _stateTable = new Dictionary<string, Type>
//                                                                      {
//                                                                          {"chase", typeof (AiChaseState)},
//                                                                          {"dead", typeof (AiDeadState)},
//                                                                          {"donothing", typeof (AiDoNothingState)},
//                                                                          {"fight", typeof (AiFightState)},
//                                                                          {"flee", typeof (AiFleeState)},
//                                                                          {"moveto", typeof (AiMoveToState)},
//                                                                          {"patrol", typeof (AiPatrolState)},
//                                                                          {"wander", typeof (AiWanderState)}
//                                                                      };

//        public override ICell CreateTemplate(string type, params object[] args)
//        {
//            throw new NotImplementedException();
//        }

//        public override ICell CreateInstance(string type, params object[] args)
//        {
//            Validation.Validate(args.Length >= 1);
//            Validation.IsNotNull(args[0], "args0");
//            Validation.Validate(args[0] is IRegularMob);

//            var obj = _stateTable.ContainsKey(type.ToLower())
//            ? _stateTable[type.ToLower()].Instantiate<AiState>(args[0].CastAs<IRegularMob>().AiBrain)
//            : null;

//            if (obj.IsNull())
//                throw new InstantiationException(ErrorResources.ERR_FAIL_INSTANTIATE_INSTANCE, GetType(), type);

//            return obj;
//        }

//        public override ICell CreateConcrete(string type, params object[] args)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
