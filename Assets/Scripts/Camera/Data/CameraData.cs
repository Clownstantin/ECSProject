using System;
using UnityEngine;

namespace RougeLike.CameraModule
{
	[Serializable]
	public struct CameraData
	{
		[SerializeField] private Camera _mainCamera;
		[SerializeField] private float _followSpeed;
		[SerializeField] private Vector3 _offsetFromPlayer;

		public Camera MainCam => _mainCamera;
		public float FollowSpeed => _followSpeed;
		public Vector3 OffsetFromPlayer => _offsetFromPlayer;
	}
}