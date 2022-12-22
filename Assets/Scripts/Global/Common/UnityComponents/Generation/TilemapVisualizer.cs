using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace RougeLike
{
	public class TilemapVisualizer : MonoBehaviour
	{
		[SerializeField] private Tilemap _floorTilemap, _wallTilemap;
		[SerializeField] private TileBase _floorTile, _wallTopTile;

		public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
		{
			_floorTilemap.ClearAllTiles();
			foreach(Vector2Int pos in floorPositions)
				PaintSingleTile(_floorTilemap, _floorTile, pos);
		}

		public void PaintWallTiles(IEnumerable<Vector2Int> wallPositions)
		{
			_wallTilemap.ClearAllTiles();
			foreach(Vector2Int pos in wallPositions)
				PaintSingleTile(_wallTilemap, _wallTopTile, pos);
		}

		public void Clear()
		{
			_floorTilemap.ClearAllTiles();
			_wallTilemap.ClearAllTiles();
		}

		private static void PaintSingleTile(Tilemap tilemap, TileBase floorTile, Vector2Int position)
		{
			Vector3Int tilePos = tilemap.WorldToCell((Vector3Int)position);
			tilemap.SetTile(tilePos, floorTile);
		}
	}
}