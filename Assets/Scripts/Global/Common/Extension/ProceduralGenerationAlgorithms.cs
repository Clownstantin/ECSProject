using System.Collections.Generic;
using UnityEngine;

namespace RougeLike
{
	public static class ProceduralGenerationAlgorithms
	{
		public static IEnumerable<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
		{
			var path = new HashSet<Vector2Int> { startPosition };
			Vector2Int currentPos = startPosition;

			for(int i = 0; i < walkLength; i++)
			{
				currentPos += Direction2D.GetRandomDirection();
				path.Add(currentPos);
			}
			return path;
		}

		public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPosition, int corridorLength)
		{
			var corridorPositions = new List<Vector2Int> { startPosition };
			Vector2Int randomDir = Direction2D.GetRandomDirection();
			Vector2Int currentPos = startPosition;

			for(int i = 0; i < corridorLength; i++)
			{
				currentPos += randomDir;
				corridorPositions.Add(currentPos);
			}
			return corridorPositions;
		}

		public static List<BoundsInt> BinarySpacePartitioning(BoundsInt spaceToSplit, int minWidth, int minHeight)
		{
			var roomsQueue = new Queue<BoundsInt>();
			var roomsList = new List<BoundsInt>();
			roomsQueue.Enqueue(spaceToSplit);

			while(roomsQueue.Count > 0)
			{
				BoundsInt roomBounds = roomsQueue.Dequeue();
				if(roomBounds.size.x < minWidth || roomBounds.size.y < minHeight) continue;

				if(Random.value < 0.5f)
				{
					if(roomBounds.size.y >= minHeight * 2)
						SplitHorizontally(minHeight, roomsQueue, roomBounds);
					else if(roomBounds.size.x >= minWidth * 2)
						SplitVertically(minWidth, roomsQueue, roomBounds);
					else
						roomsList.Add(roomBounds);
				}
				else
				{
					if(roomBounds.size.x >= minWidth * 2)
						SplitVertically(minWidth, roomsQueue, roomBounds);
					else if(roomBounds.size.y >= minHeight * 2)
						SplitHorizontally(minHeight, roomsQueue, roomBounds);
					else
						roomsList.Add(roomBounds);
				}
			}
			return roomsList;
		}

		private static void SplitVertically(int minWidth, Queue<BoundsInt> roomsQueue, BoundsInt roomBounds)
		{
			Vector3Int roomSize = roomBounds.size;
			Vector3Int room1Pos = roomBounds.min;

			int xSplit = Random.Range(1, roomSize.x);
			var room1Size = new Vector3Int(xSplit, roomSize.y, roomSize.z);
			var room2Pos = new Vector3Int(room1Pos.x + xSplit, room1Pos.y, room1Pos.z);
			var room2Size = new Vector3Int(roomSize.x - xSplit, roomSize.y, roomSize.z);

			var room1 = new BoundsInt(room1Pos, room1Size);
			var room2 = new BoundsInt(room2Pos, room2Size);

			roomsQueue.Enqueue(room1);
			roomsQueue.Enqueue(room2);
		}

		private static void SplitHorizontally(int minHeight, Queue<BoundsInt> roomsQueue, BoundsInt roomBounds)
		{
			Vector3Int roomSize = roomBounds.size;
			Vector3Int room1Pos = roomBounds.min;

			int ySplit = Random.Range(1, roomSize.y);
			var room1Size = new Vector3Int(roomSize.x, ySplit, roomSize.z);
			var room2Pos = new Vector3Int(room1Pos.x, room1Pos.y + ySplit, room1Pos.z);
			var room2Size = new Vector3Int(roomSize.x, roomSize.y - ySplit, roomSize.z);

			var room1 = new BoundsInt(room1Pos, room1Size);
			var room2 = new BoundsInt(room2Pos, room2Size);

			roomsQueue.Enqueue(room1);
			roomsQueue.Enqueue(room2);
		}
	}
}