using UnityEngine;

namespace RougeLike.PlayerInput
{
	public readonly struct Coordinate
	{
		public readonly Vector3 value;

		public Coordinate(Vector3 value) => this.value = value;
	}
}