using UnityEngine;

namespace RougeLike.PlayerInput
{
	public readonly struct MoveInput
	{
		public readonly Vector3 value;

		public MoveInput(Vector3 value) => this.value = value;
	}
}