using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike.CameraModule
{
	public class CameraInitSystem : IEcsInitSystem
	{
		private EcsWorld _world = default;
		private CameraData _cameraData = default;

		public void Init()
		{
			EcsEntity camera = _world.NewEntity();
			Camera mainCam = _cameraData.MainCam;

			camera.Get<CameraTag>();
			camera.Replace(new EntityTransform(mainCam.transform));
			camera.Replace(new EntityLocalTransform(mainCam.transform));
			camera.Replace(new ComponentLink<Transform>(mainCam.transform));
			camera.Replace(new ComponentLink<Camera>(mainCam));
			camera.Get<ChangeTransformEvent>();
			camera.Get<ChangeLocalTransformEvent>();
		}
	}
}