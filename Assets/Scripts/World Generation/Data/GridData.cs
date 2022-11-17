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
		[SerializeField] private Tile _tile;
		[SerializeField] private Vector2Int _gridSize;
		[SerializeField] private Vector2Int _cellSize;

		public Transform WorldContainer => _worldContainer;
		public Grid Grid => _grid;
		public Tile Tile => _tile;
		public Vector2Int GridSize => _gridSize;
		public Vector2Int CellSize => _cellSize;
	}
}