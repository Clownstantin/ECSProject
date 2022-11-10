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
			CinemachineVirtualCamera mainCam = _cameraData.FollowCam;

			camera.Get<CameraTag>();
			camera.Replace(new EntityTransform(mainCam.transform))
			      .Replace(new ComponentLink<Transform>(mainCam.transform))
			      .Replace(new ComponentLink<CinemachineVirtualCamera>(mainCam));
			camera.Get<ChangeTransformEvent>();
			camera.Get<SpawnEvent>();
		}
	}
}