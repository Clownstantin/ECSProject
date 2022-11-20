using System.Collections.Generic;
using System.Linq;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace RougeLike.WorldModule
{
	public class GenerateGridSystem : IEcsRunSystem
	{
		private EcsFilter<GridTag, SpawnEvent> _gridFilter = default;
		private GridData _gridData = default;
		private ProceduralData _proceduralData = default;

		public void Run()
		{
			if(_gridFilter.IsEmpty()) return;

			EcsEntity grid = _gridFilter.GetEntity(0);

			if(grid.TryGet(out ComponentLink<Tilemap> tilemapLink, out ComponentLink<Grid> gridLink))
			{
				// Vector2Int gridSize = _gridData.GridSize;
				// Vector2Int cellSize = _gridData.CellSize;
				// Grid gridObj = gridLink.value;
				Tilemap tilemapObj = tilemapLink.value;
				//
				// gridObj.cellSize = new Vector3(cellSize.x, cellSize.y);
				// Vector3Int startPos = GetGridStartPosition(gridSize, cellSize);
				//
				// for(int x = 0; x < gridSize.x; x++)
				// for(int y = 0; y < gridSize.y; y++)
				// 	tilemapObj.SetTile(new Vector3Int(startPos.x + x, startPos.y + y), _gridData.FloorTile);
				RunProceduralGeneration(tilemapObj, _gridData.FloorTile);
			}

		}

		private Vector3Int GetGridStartPosition(Vector2Int gridSize, Vector2Int cellSize)
		{
			Vector3 startPos = _gridData.WorldContainer.position;

			float xOffset = gridSize.x * cellSize.x * 0.5f;
			float yOffset = gridSize.y * cellSize.y * 0.5f;
			startPos.x -= xOffset;
			startPos.y -= yOffset;

			return new Vector3Int((int)startPos.x, (int)startPos.y);
		}

		private void RunProceduralGeneration(Tilemap tilemap, TileBase tile)
		{
			IEnumerable<Vector2Int> floorPositions = RunRandomWalk();
			PaintFloorTiles(floorPositions, tilemap, tile);
		}

		private IEnumerable<Vector2Int> RunRandomWalk()
		{
			Vector2Int currentPos = _proceduralData.StartPosition;
			var floorPositions = new HashSet<Vector2Int>();

			for(int i = 0; i < _proceduralData.Iterations; i++)
			{
				HashSet<Vector2Int> path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPos, _proceduralData.WalkLength);
				floorPositions.UnionWith(path);

				if(_proceduralData.RandomlyEachIteration)
					currentPos = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
			}
			return floorPositions;
		}

		private void PaintFloorTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
		{
			tilemap.ClearAllTiles();

			foreach(Vector2Int position in positions)
			{
				Vector3Int tilePos = tilemap.WorldToCell((Vector3Int)position);
				tilemap.SetTile(tilePos, _gridData.FloorTile);
			}
		}
	}
}