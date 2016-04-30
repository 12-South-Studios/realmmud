using System;
using System.Collections.Generic;
using System.Linq;
using Realm.Ai.States;
using Realm.Data;
using Realm.Data.Definitions;
using Realm.Entity;
using Realm.Entity.Entities.Interfaces;
using Realm.Entity.Interfaces;
using Realm.Library.Ai;
using Realm.Library.Common.Contexts;
using Realm.Library.Common.Data;
using Realm.Library.Common.Objects;

namespace Realm.Ai
{
    public class Behavior : Library.Common.Objects.Entity, IBehavior
    {
        private List<IContext> Contexts { get; set; }

        private EntityManager EntityManager { get; set; }

        public Behavior(long id, string name, Definition def, IEntityManager entityManager)
            : base(id, name)
        {
            BehaviorDef = def.CastAs<BehaviorDef>();
            Contexts = new List<IContext>();
            EntityManager = (EntityManager) entityManager;
        }

        public void OnInit(DictionaryAtom initAtom)
        {
            Contexts.Add(new BitContext(this));
            Contexts.Add(new PropertyContext(this));
        }

        public BehaviorDef BehaviorDef { get; private set; }

        public IRegularMob Owner { get; set; }

        public IBitContext Bits
        {
            get
            {
                return (IBitContext)Contexts.FirstOrDefault(context => context.GetType().Name
                                                                            .Equals("BitContext",
                                                                                    StringComparison.OrdinalIgnoreCase));
            }
        }

        public IPropertyContext Properties
        {
            get
            {
                return (IPropertyContext)Contexts.FirstOrDefault(context => context.GetType().Name
                                                                                 .Equals("PropertyContext",
                                                                                         StringComparison.
                                                                                             OrdinalIgnoreCase));
            }
        }

        public IAiState NeedState()
        {
            var state = CheckFightCondition();
            if (state.IsNotNull()) return state;

            state = CheckGuardCondition();
            if (state.IsNotNull()) return state;

            state = CheckWanderCondition();
            if (state.IsNotNull()) return state;

            return EntityManager.GetDoNothingState(Owner);
        }

        private IAiState CheckFightCondition()
        {
            //// If I am willing to fight and I don't already have a fight state
            if (!Bits.HasBit(Globals.BehaviorBits.NonCombatant)
                && Owner.AiBrain.CurrentState.IsNotNull()
                && !Owner.AiBrain.HasState("fight"))
            {
                var newState = EntityManager.GetFightState(Owner);
                var fightState = newState.CastAs<AiFightState>();
                if (fightState.IsNotNull())
                {
                    fightState.Target = Owner.Fighting;
                    return fightState;
                }
            }
            return null;
        }

        private IAiState CheckGuardCondition()
        {
            return Bits.HasBit(Globals.BehaviorBits.Guard) && !Bits.HasBit(Globals.BehaviorBits.Sentinel)
                       ? EntityManager.GetPatrolState(Owner)
                       : null;
        }

        private IAiState CheckWanderCondition()
        {
            return !Bits.HasBit(Globals.BehaviorBits.Sentinel) ? EntityManager.GetWanderState(Owner) : null;
        }
    }
}