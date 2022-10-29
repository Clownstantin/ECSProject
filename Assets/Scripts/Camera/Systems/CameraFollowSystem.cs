using Leopotam.Ecs;
using RougeLike.PlayerModule;
using UnityEngine;

namespace RougeLike.CameraModule
{
	internal class CameraFollowSystem : IEcsRunSystem
	{
		private EcsFilter<CameraTag, EntityTransform> _cameraFilter = default;
		private EcsFilter<PlayerTag> _playerFilter = default;
		private CameraData _cameraData = default;

		[EcsIgnoreInject] private Vector3 _camVelocity = default;

		public void Run()
		{
			if(_cameraFilter.IsEmpty() || _playerFilter.IsEmpty()) return;

			float delta = Time.fixedDeltaTime;

			EcsEntity camera = _cameraFilter.GetEntity(0);
			EcsEntity player = _playerFilter.GetEntity(0);
			ref EntityTransform camTransform = ref _cameraFilter.Get2(0);

			if(!player.TryGet(out EntityTransform playerTransform)) return;
			Vector3 targetPos = Vector3.SmoothDamp(camTransform.position, playerTransform.position + _cameraData.OffsetFromPlayer,
			                                       ref _camVelocity, delta * _cameraData.FollowSpeed);
			camTransform.position = targetPos;
			camera.Get<ChangeTransformEvent>();
		}
	}
}