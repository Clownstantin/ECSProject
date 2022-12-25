using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RougeLike
{
	public class CorridorFirtGenerator : RandomWalkGenerator
	{
		[SerializeField] private int _corridorLength = 14;
		[SerializeField] private int _corridorCount = 5;
		[SerializeField, Range(0.1f, 1f)] private float _roomPercent = 0.8f;

		protected override void RunProceduralGeneration() => CorridorFirstGeneration();

		private void CorridorFirstGeneration()
		{
			var floorPositions = new HashSet<Vector2Int>();
			var potentialRoomPositions = new HashSet<Vector2Int>();

			CreateCorridors(floorPositions, potentialRoomPositions);
			HashSet<Vector2Int> roomPositions = GetGeneratedRoomPositions(potentialRoomPositions);
			List<Vector2Int> deadEnds = FindAllDeadEnds(floorPositions);
			CreateRoomsAtDeadEnds(deadEnds, roomPositions);

			floorPositions.UnionWith(roomPositions);
			visualizer.PaintFloorTiles(floorPositions);

			IEnumerable<Vector2Int> wallPositions = WallGenerator.GetGeneratedWallPositions(floorPositions);
			visualizer.PaintWallTiles(wallPositions);
		}

		private void CreateCorridors(ISet<Vector2Int> floorPositions, ISet<Vector2Int> potentialRoomPositions)
		{
			Vector2Int currentPos = startPosition;
			potentialRoomPositions.Add(currentPos);

			for(int i = 0; i < _corridorCount; i++)
			{
				List<Vector2Int> corridor = ProceduralGenerationAlgorithms.RandomWalkCorridor(currentPos, _corridorLength);
				currentPos = corridor[^1];
				potentialRoomPositions.Add(currentPos);
				floorPositions.UnionWith(corridor);
			}
		}

		private void CreateRoomsAtDeadEnds(List<Vector2Int> deadEnds, ISet<Vector2Int> roomPositions)
		{
			foreach(Vector2Int deadEndPos in deadEnds)
			{
				if(roomPositions.Contains(deadEndPos)) continue;
				HashSet<Vector2Int> room = RunRandomWalk(deadEndPos);
				roomPositions.UnionWith(room);
			}
		}

		private HashSet<Vector2Int> GetGeneratedRoomPositions(ICollection<Vector2Int> potentialRoomPositions)
		{
			var roomPositions = new HashSet<Vector2Int>();
			int roomToCreateCount = Mathf.RoundToInt(potentialRoomPositions.Count * _roomPercent);
			IEnumerable<Vector2Int> roomsToCreate = potentialRoomPositions.OrderBy(_ => Guid.NewGuid()).Take(roomToCreateCount);

			foreach(Vector2Int roomPos in roomsToCreate)
			{
				HashSet<Vector2Int> roomFloor = RunRandomWalk(roomPos);
				roomPositions.UnionWith(roomFloor);
			}
			return roomPositions;
		}

		private static List<Vector2Int> FindAllDeadEnds(HashSet<Vector2Int> floorPositions)
		{
			var deadEnds = new List<Vector2Int>();

			foreach(Vector2Int floorPos in floorPositions)
			{
				int neighbourCount = 0;
				foreach(Vector2Int dir in Direction2D.Directions)
				{
					if(!floorPositions.Contains(floorPos + dir)) continue;
					neighbourCount++;
				}

				if(neighbourCount == 1) deadEnds.Add(floorPos);
			}
			return deadEnds;
		}
	}
}