using System.Collections.Generic;
using UnityEngine;

namespace RougeLike
{
	public static class WallGenerator
	{
		public static IEnumerable<Vector2Int> GetWallPositions(HashSet<Vector2Int> floorPositions)
		{
			var wallPositions = new HashSet<Vector2Int>();
			foreach(Vector2Int pos in floorPositions)
			{
				foreach(Vector2Int dir in Direction2D.Directions)
				{
					Vector2Int neighbourPos = pos + dir;
					if(!floorPositions.Contains(neighbourPos))
						wallPositions.Add(neighbourPos);
				}
			}
			return wallPositions;
		}
	}
}