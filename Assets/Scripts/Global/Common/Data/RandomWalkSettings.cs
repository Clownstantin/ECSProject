using UnityEngine;

namespace RougeLike
{
	[CreateAssetMenu(menuName = "Settings/PCG/RandomWalkData", fileName = "RandomWalkParams_", order = 50)]
	public class RandomWalkSettings : ScriptableObject
	{
		[SerializeField] private int _iterations;
		[SerializeField] private int _walkLength;
		[SerializeField] private bool _isRandomEachIteration;

		public int Iterations => _iterations;
		public int WalkLength => _walkLength;
		public bool IsRandomEachIteration => _isRandomEachIteration;
	}
}