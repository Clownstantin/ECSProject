using System;
using Cinemachine;
using UnityEngine;

namespace RougeLike.CameraModule
{
	[Serializable]
	public struct CameraData
	{
		[SerializeField] private Camera _mainCam;
		[SerializeField] private CinemachineVirtualCamera _followCam;

		public Camera MainCam => _mainCam;
		public CinemachineVirtualCamera FollowCam => _followCam;
	}
}