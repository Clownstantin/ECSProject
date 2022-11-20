using UnityEngine;

namespace RougeLike
{
	public static class Direction2D
	{
		private static Vector2Int[] s_Directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right, };

		public static Vector2Int GetRandomDirection() => s_Directions[Random.Range(0, s_Directions.Length)];
	}
}