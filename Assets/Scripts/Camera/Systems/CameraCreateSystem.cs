using Cinemachine;
using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike.CameraModule
{
	public class CameraCreateSystem : IEcsInitSystem
	{
		private EcsWorld _world = default;
		private CameraData _cameraData = default;

		public void Init()
		{
			EcsEntity camera = _world.NewEntity();
			CinemachineVirtualCamera followCam = _cameraData.FollowCam;

			camera.Get<CameraTag>();
			camera.Replace(new EntityTransform(followCam.transform))
			      .Replace(new ComponentLink<Transform>(followCam.transform))
			      .Replace(new ComponentLink<Camera>(_cameraData.MainCam))
			      .Replace(new ComponentLink<CinemachineVirtualCamera>(followCam));
			camera.Get<ChangeTransformEvent>();
			camera.Get<SpawnEvent>();
		}
	}
}