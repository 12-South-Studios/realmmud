using Realm.Entity;
using Realm.Entity.Entities;
using Realm.Library.Ai;
using Realm.Library.Common;

namespace Realm.Ai
{
    public static class Extensions
    {
        public static IAiState GetDeadState(this IEntityManager manager, IRegularMob mob)
        {
            return manager.Create(new AiStateFactoryHelper(), "dead", mob).CastAs<IAiState>();
        }

        public static IAiState GetDoNothingState(this IEntityManager manager, IRegularMob mob)
        {
            return manager.Create(new AiStateFactoryHelper(), "donothing", mob).CastAs<IAiState>();
        }

        public static IAiState GetFightState(this IEntityManager manager, IRegularMob mob)
        {
            return manager.Create(new AiStateFactoryHelper(), "fight", mob).CastAs<IAiState>();
        }

        public static IAiState GetWanderState(this IEntityManager manager, IRegularMob mob)
        {
            return manager.Create(new AiStateFactoryHelper(), "wander", mob).CastAs<IAiState>();
        }

        public static IAiState GetPatrolState(this IEntityManager manager, IRegularMob mob)
        {
            return manager.Create(new AiStateFactoryHelper(), "patrol", mob).CastAs<IAiState>();
        }
    }
}