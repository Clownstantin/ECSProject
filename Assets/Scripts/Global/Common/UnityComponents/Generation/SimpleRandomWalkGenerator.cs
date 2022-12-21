using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RougeLike
{
	public class SimpleRandomWalkGenerator : DungeonGenerator
	{
		protected override void RunProceduralGeneration()
		{
			HashSet<Vector2Int> floorPositions = RunRandomWalk();
			visualizer.PaintFloorTiles(floorPositions);
		}

		private HashSet<Vector2Int> RunRandomWalk()
		{
			Vector2Int currentPos = proceduralData.StartPosition;
			var floorPositions = new HashSet<Vector2Int>();

			for(int i = 0; i < proceduralData.Iterations; i++)
			{
				HashSet<Vector2Int> path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPos, proceduralData.WalkLength);
				floorPositions.UnionWith(path);

				if(proceduralData.IsRandomEachIteration)
					currentPos = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
			}
			return floorPositions;
		}
	}
}