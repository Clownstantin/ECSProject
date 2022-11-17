using Cinemachine;
using Leopotam.Ecs;
using RougeLike.PlayerModule;
using UnityEngine;

namespace RougeLike.CameraModule
{
	public class CameraInitSystem : IEcsRunSystem
	{
		private EcsFilter<CameraTag, SpawnEvent> _camFilter = default;
		private EcsFilter<PlayerTag> _playerFilter = default;

		public void Run()
		{
			if(_camFilter.IsEmpty() || _playerFilter.IsEmpty()) return;

			EcsEntity camera = _camFilter.GetEntity(0);
			EcsEntity player = _playerFilter.GetEntity(0);

			if(camera.TryGet(out ComponentLink<CinemachineVirtualCamera> virtualCam) && player.TryGet(out ComponentLink<Transform> playerTransform))
				virtualCam.value.Follow = playerTransform.value;
		}
	}
}