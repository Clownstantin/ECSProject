using System;
using Cinemachine;
using UnityEngine;

namespace RougeLike.CameraModule
{
	[Serializable]
	public struct CameraData
	{
		[SerializeField] private CinemachineVirtualCamera _followCam;

		public CinemachineVirtualCamera FollowCam => _followCam;
	}
}