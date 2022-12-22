using UnityEngine;

namespace RougeLike
{
	public static class Direction2D
	{
		public static readonly Vector2Int[] Directions;

		static Direction2D() => Directions = new[] { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right, };

		public static Vector2Int GetRandomDirection() => Directions[Random.Range(0, Directions.Length)];
	}
}