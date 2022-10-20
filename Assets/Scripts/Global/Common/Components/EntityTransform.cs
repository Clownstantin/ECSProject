using UnityEngine;

namespace RougeLike
{
	public struct EntityTransform
	{
		public Quaternion rotation;
		public Vector3 position;

		public EntityTransform(Transform transform)
		{
			rotation = transform.rotation;
			position = transform.position;
		}

		public EntityTransform(Quaternion rotation, Vector3 position)
		{
			this.rotation = rotation;
			this.position = position;
		}
	}
}