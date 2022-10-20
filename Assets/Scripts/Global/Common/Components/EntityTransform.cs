using UnityEngine;

namespace RougeLike
{
	public struct EntityTransform
	{
		public Vector3 position;
		public Quaternion rotation;

		public EntityTransform(Transform transform)
		{
			position = transform.position;
			rotation = transform.rotation;
		}

		public EntityTransform(Vector3 position, Quaternion rotation)
		{
			this.position = position;
			this.rotation = rotation;
		}
	}
}