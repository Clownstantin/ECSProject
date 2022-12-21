using System;
using UnityEngine;

namespace RougeLike
{
	[Serializable]
	public struct ProceduralData
	{
		[Header("RandomWalk Generation")]
		[SerializeField] private Vector2Int _startPosition;
		[SerializeField] private int _iterations;
		[SerializeField] private int _walkLength;
		[SerializeField] private bool _isRandomEachIteration;

		public Vector2Int StartPosition => _startPosition;
		public int Iterations => _iterations;
		public int WalkLength => _walkLength;
		public bool IsRandomEachIteration => _isRandomEachIteration;
	}
}