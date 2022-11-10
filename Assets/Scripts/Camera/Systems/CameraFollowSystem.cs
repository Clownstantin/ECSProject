using Leopotam.Ecs;
using RougeLike.PlayerModule;
using UnityEngine;

namespace RougeLike.CameraModule
{
	internal class CameraFollowSystem : IEcsRunSystem
	{
		private EcsFilter<CameraTag, EntityTransform> _cameraFilter = default;
		private EcsFilter<PlayerTag> _playerFilter = default;

		[EcsIgnoreInject] private Vector3 _camVelocity = default;

		public void Run()
		{
			if(_cameraFilter.IsEmpty() || _playerFilter.IsEmpty()) return;

			EcsEntity camera = _cameraFilter.GetEntity(0);
			EcsEntity player = _playerFilter.GetEntity(0);
			ref EntityTransform camTransform = ref _cameraFilter.Get2(0);

			if(player.TryGet(out EntityTransform playerTransform) && camera.TryGet(out MoveSpeed moveSpeed, out Offset offset))
			{
				Vector3 targetPos = Vector3.SmoothDamp(camTransform.position, playerTransform.position + offset.value,
				                                       ref _camVelocity, Time.deltaTime * moveSpeed.value);
				camTransform.position = targetPos;
				camera.Get<ChangeTransformEvent>();
			}
		}
	}
}