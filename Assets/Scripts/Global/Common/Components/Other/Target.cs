using UnityEngine;

namespace RougeLike
{
	internal readonly struct Target
	{
		public readonly Vector3 position;

		public Target(Vector3 value) => position = value;
	}
}