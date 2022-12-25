using System.Collections.Generic;
using UnityEngine;

namespace RougeLike
{
	public static class ProceduralGenerationAlgorithms
	{
		public static IEnumerable<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
		{
			var path = new HashSet<Vector2Int> { startPosition };
			Vector2Int currentPos = startPosition;

			for(int i = 0; i < walkLength; i++)
			{
				currentPos += Direction2D.GetRandomDirection();
				path.Add(currentPos);
			}
			return path;
		}

		public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPosition, int corridorLength)
		{
			var corridorPositions = new List<Vector2Int> { startPosition };
			Vector2Int randomDir = Direction2D.GetRandomDirection();
			Vector2Int currentPos = startPosition;

			for(int i = 0; i < corridorLength; i++)
			{
				currentPos += randomDir;
				corridorPositions.Add(currentPos);
			}
			return corridorPositions;
		}
	}
}