using UnityEngine;

namespace RougeLike
{
	public struct EntityLocalTransform
	{
		public Vector3 localPosition;
		public Quaternion localRotation;

		public EntityLocalTransform(Transform transform)
		{
			localPosition = transform.localPosition;
			localRotation = transform.localRotation;
		}
	}
}