using System.Collections.Generic;
using UnityEngine;

namespace RougeLike
{
	public class RoomFirstGenerator : RandomWalkGenerator
	{
		[SerializeField] private int _minRoomWidth, _minRoomHeight;
		[SerializeField] private int _dungeonWidth, _dungeonHeight;
		[SerializeField, Range(0, 10)] private int _offset = 1;
		[SerializeField] private bool _isRandomWalkRooms = false;

		protected override void RunProceduralGeneration() => CreateRooms();

		private void CreateRooms()
		{
			var totalSize = new Vector3Int(_dungeonWidth, _dungeonHeight);
			var totalBounds = new BoundsInt((Vector3Int)startPosition, totalSize);
			List<BoundsInt> rooms = ProceduralGenerationAlgorithms.BinarySpacePartitioning(totalBounds, _minRoomWidth, _minRoomHeight);
			HashSet<Vector2Int> floor = CreateSimpleRooms(rooms);

			visualizer.PaintFloorTiles(floor);
			visualizer.PaintWallTiles(WallGenerator.GetGeneratedWallPositions(floor));
		}

		private HashSet<Vector2Int> CreateSimpleRooms(List<BoundsInt> rooms)
		{
			var floor = new HashSet<Vector2Int>();
			foreach(BoundsInt room in rooms)
			{
				for(int col = 0; col < room.size.x - _offset; col++)
				{
					for(int row = _offset; row < room.size.y - _offset; row++)
					{
						Vector2Int pos = (Vector2Int)room.min + new Vector2Int(col, row);
						floor.Add(pos);
					}
				}
			}
			return floor;
		}
	}
}