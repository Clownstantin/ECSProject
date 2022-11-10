using UnityEngine;

namespace RougeLike
{
	internal readonly struct Offset
	{
		public readonly Vector3 value;

		public Offset(Vector3 offset) => value = offset;
	}
}