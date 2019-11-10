using System.Collections.Generic;
using System.Linq;
using Realm.Entity;
using Realm.Entity.Entities;
using Realm.Entity.Entities.Interfaces;
using Realm.Entity.Interfaces;
using Realm.Library.Common.Objects;
using Realm.Pathing.Core;
using Realm.Pathing.Interfaces;

namespace Realm.Pathing
{
    public static class Extensions
    {
        public static Graph BuildGraph(this Zone zone, IEntityManager entityManager, IPathManager pathManager)
        {
            var graph = new Graph();
            zone.GetContentsContext().Entities.OfType<Space>().ToList().ForEach(space =>
                {
                    var graphData = new Vertex {Space = space, Edges = new List<Edge>()};
                    space.Portals.ToList().ForEach(portal =>
                        {
                            var targetSpace = GetSpace(entityManager, portal.TargetSpace.ID);
                            if (targetSpace != null)
                            {
                                graphData.Edges.Add(new Edge
                                    {
                                        Cost = CalculateCost(targetSpace, pathManager),
                                        Destination = targetSpace.ID,
                                        Direction = portal.Direction
                                    });
                            }
                        });
                });
            return graph;
        }

        private static Space GetSpace(IEntityManager entityManager, long spaceDefinitionId)
        {
            var targetSpaces = ((EntityManager)entityManager).GetEntityByDefinitionId(spaceDefinitionId).ToList();
            if (targetSpaces.Count > 1)
            {
                // TODO: Log and continue
                return null;
            }
            return targetSpaces.ElementAt(0).CastAs<Space>();
        }

        private static int CalculateCost(Space space, IPathManager pathManager)
        {
            if (space == null) return 0;

            var mobs = space.GetContentsContext().Entities.OfType<IRegularMob>().Count();
            var maxCost = pathManager.MaxMobileMovementCost;

            return space.SpaceDef.Terrain.MovementCost + (mobs > maxCost ? maxCost : mobs);
        }
    }
}