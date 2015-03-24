using Realm.Entity;
using Realm.Library.Common.Data;
using Realm.Pathing.Core;

namespace Realm.Pathing
{
	/// <summary>
	///
	/// </summary>
	public class PathBuilder
	{
		private DictionaryAtom InitializationAtom { get; set; }
		private EntityManager EntityManager { get; set; }

		///  <summary>
		/// 
		///  </summary>
		///  <param name="initAtom"></param>
		/// <param name="entityManager"></param>
		public PathBuilder(DictionaryAtom initAtom, IEntityManager entityManager)
		{
			InitializationAtom = initAtom;
			EntityManager = (EntityManager) entityManager;
		}

		private static DijkstraTable CreateTable()
		{
			return new DijkstraTable { Graph = null, Source = -1, Results = null };
		}

		/// <summary>
		/// Returns a list of steps to take that are the shortest calculated path
		/// between the source and destination Spaces
		/// </summary>
		public Path GeneratePath(long sourceId, long targetId)
		{
			// TODO: Pass in an allowed list of movement modes

			if (sourceId == targetId)
				throw new InvalidPathException("Source and Destination cannot be the same!");

			// TODO: Get the Source and Target Space Instances
			// TODO: If the Source and Target are in different zones, throw an exception

			DijkstraTable table = CreateTable();
			

		/*// TODO: Get the Zone's Graph
			//table.Graph = GetGraph(source.MyZone.ID);

			//var currentSpace = destination.ID;
			//var firstSpace = CalculateZoneFirstSpace(source.MyZone);

			table.Results = DijkstraSimple(source);
			var stepList = new List<string>();

			while (source.ID != currentSpace)
			{
				// TODO: ShortestPath - look for doors and/or access problems

				// reverse the exit direction and assign add it to the stepList.
				stepList.Add(GetPathStep(currentSpace, table.Results[(int)(currentSpace - firstSpace)].Previous));

				// update the current Space number
				currentSpace = table.Results[(int)(currentSpace - firstSpace)].Previous + firstSpace;
			};

			return stepList;*/
			return null;
		}

		/// <summary>
		/// Builds a lsit of Dijkstra Rows for the given Space
		/// </summary>
		/// <exception cref="IndexOutOfRangeException">IndexOutOfRangeException is thrown if the ID of the first space in the zone is less than or equal to 0</exception>
		/*private IList<DijkstraRow> DijkstraSimple(ISpace Space)
		{
			var graph = GetGraph(Space.MyZone.ID);
			if (graph.IsNull()) throw new GeneralException("Unable to locate AdjacencyGraph for Zone " + Space.MyZone.ID);

			var zoneFirstSpace = CalculateZoneFirstSpace(Space.MyZone);
			if (zoneFirstSpace <= 0) throw new GeneralException("Zone First Space was less than or equal to 0");

			var results = InitDijkstraResults(graph.NumVertices);

			int source = (int)(Space.ID - zoneFirstSpace);
			results[source].Total = 0;
			results[source].Previous = -1;
			int vertex = source;

			do
			{
				results[vertex].Visited = true;

				foreach (var edge in graph.Vertices[vertex].Edges)
				{
					var destination = (int)(edge.Destination - zoneFirstSpace);
					if (results[destination].Visited) continue;
					if (edge.Cost < 0) return results;

					// Recalculate the cost based upon the number of mobs in that Space
					int newCost = CalculateCost((ISpace)EntityManager.Instance.LuaGetConcrete(edge.Destination));

					// TODO: Dijkstra - Check for barriers

					// TODO: Check movement modes

					if ((results[vertex].Total + newCost) < results[destination].Total)
					{
						results[destination].Total = results[vertex].Total + newCost;
						results[destination].Previous = vertex;
					}
				}

				vertex = -1;

				int c = Int32.MaxValue;
				for (var i = 1; i <= graph.NumVertices; i++)
				{
					if (!results[i].Visited && results[i].Total < c)
					{
						vertex = i;
						c = results[i].Total;
					}
				}
			} while (vertex != -1);

			return results;
		}

		private static long CalculateZoneFirstSpace(Zone zone)
		{
			//return zone.Contents.Entities.OfType<Space>().ToList().Select(Space => Space.ID).Concat(new long[] {Int32.MaxValue}).Min();
			return 0;
		}

		/// <summary>
		/// Gets the direction name that leads from each Space
		/// </summary>
		private static string GetPathStep(long currentSpace, long previousSpace)
		{
			var Space = EntityManager.Instance.LuaGetConcrete(currentSpace) as ISpace;
			if (Space.IsNull()) return string.Empty;

			foreach (var exit in Space.GetPortals().Values.Where(exit => exit.Destination.ID == previousSpace))
				return exit.Direction.GetOpposite();
			return string.Empty;
		}

		private static IList<DijkstraRow> InitDijkstraResults(int numRows)
		{
			var results = new List<DijkstraRow>();
			for (int i = 0; i < numRows; i++)
				results.Add(new DijkstraRow {Total = Int32.MaxValue, Previous = -1, Visited = false});
			return results;
		}*/
	}
}