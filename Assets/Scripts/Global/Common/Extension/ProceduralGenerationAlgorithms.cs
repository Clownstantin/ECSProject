using System.Collections.Generic;
using UnityEngine;

namespace RougeLike
{
	public static class ProceduralGenerationAlgorithms
	{
		public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
		{
			var path = new HashSet<Vector2Int> { startPosition };
			Vector2Int prevPos = startPosition;

			for(int i = 0; i < walkLength; i++)
			{
				Vector2Int newPos = prevPos + Direction2D.GetRandomDirection();
				path.Add(newPos);
				prevPos = newPos;
			}

			return path;
		}
	}
}