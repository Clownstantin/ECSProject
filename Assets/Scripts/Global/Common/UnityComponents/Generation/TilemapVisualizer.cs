using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace RougeLike
{
	public class TilemapVisualizer : MonoBehaviour
	{
		[SerializeField] private Tilemap _floorTilemap = default;
		[SerializeField] private TileBase _floorTile = default;

		public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
		{
			_floorTilemap.ClearAllTiles();
			foreach(Vector2Int pos in floorPositions)
			{
				Vector3Int tilePos = _floorTilemap.WorldToCell((Vector3Int)pos);
				_floorTilemap.SetTile(tilePos, _floorTile);
			}
		}
	}
}