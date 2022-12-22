using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RougeLike
{
	public class RandomWalkGenerator : DungeonGenerator
	{
		[SerializeField] private RandomWalkSettings _settings = default;
		
		protected override void RunProceduralGeneration()
		{
			HashSet<Vector2Int> floorPositions = RunRandomWalk();
			IEnumerable<Vector2Int> wallPositions = WallGenerator.GetWallPositions(floorPositions);

			visualizer.PaintFloorTiles(floorPositions);
			visualizer.PaintWallTiles(wallPositions);
		}

		private HashSet<Vector2Int> RunRandomWalk()
		{
			Vector2Int currentPos = startPosition;
			var floorPositions = new HashSet<Vector2Int>();

			for(int i = 0; i < _settings.Iterations; i++)
			{
				IEnumerable<Vector2Int> path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPos, _settings.WalkLength);
				floorPositions.UnionWith(path);

				if(_settings.IsRandomEachIteration)
					currentPos = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
			}
			return floorPositions;
		}
	}
}