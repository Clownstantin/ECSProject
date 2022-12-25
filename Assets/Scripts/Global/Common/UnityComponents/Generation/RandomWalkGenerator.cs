using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RougeLike
{
	public class RandomWalkGenerator : DungeonGenerator
	{
		[SerializeField] protected RandomWalkSettings generationSettings = default;
		
		protected override void RunProceduralGeneration()
		{
			HashSet<Vector2Int> floorPositions = RunRandomWalk(startPosition);
			IEnumerable<Vector2Int> wallPositions = WallGenerator.GetGeneratedWallPositions(floorPositions);

			visualizer.PaintFloorTiles(floorPositions);
			visualizer.PaintWallTiles(wallPositions);
		}

		protected HashSet<Vector2Int> RunRandomWalk(Vector2Int position)
		{
			Vector2Int currentPos = position;
			var floorPositions = new HashSet<Vector2Int>();

			for(int i = 0; i < generationSettings.Iterations; i++)
			{
				IEnumerable<Vector2Int> path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPos, generationSettings.WalkLength);
				floorPositions.UnionWith(path);

				if(generationSettings.IsRandomEachIteration)
					currentPos = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
			}
			return floorPositions;
		}
	}
}