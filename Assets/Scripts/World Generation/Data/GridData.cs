using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace RougeLike.WorldModule
{
	[Serializable]
	public struct GridData
	{
		[SerializeField] private Transform _worldContainer;
		[SerializeField] private Grid _grid;
		[SerializeField] private TileBase _floorTile;
		[SerializeField] private Vector2Int _gridSize;
		[SerializeField] private Vector2Int _cellSize;

		public Transform WorldContainer => _worldContainer;
		public Grid Grid => _grid;
		public TileBase FloorTile => _floorTile;
		public Vector2Int GridSize => _gridSize;
		public Vector2Int CellSize => _cellSize;
	}
}