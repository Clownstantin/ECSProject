using UnityEngine;

namespace RougeLike.PlayerInput
{
	public readonly struct DragEvent
	{
		public readonly Vector3 deltaPosition;

		public DragEvent(Vector3 deltaPosition) => this.deltaPosition = deltaPosition;
	}
}