using Leopotam.Ecs;
using RougeLike.PlayerInput;
using UnityEngine;

namespace RougeLike.PlayerModule
{
	internal class PlayerMovementSystem : IEcsRunSystem
	{
		private EcsFilter<InputTag> _inputFilter = default;
		private EcsFilter<PlayerTag, EntityTransform> _playerFilter = default;

		public void Run()
		{
			if(_inputFilter.IsEmpty() || _playerFilter.IsEmpty()) return;

			float delta = Time.deltaTime;
			EcsEntity input = _inputFilter.GetEntity(0);
			EcsEntity player = _playerFilter.GetEntity(0);
			ref EntityTransform transform = ref _playerFilter.Get2(0);

			if(input.TryGet(out MoveInput moveInput) && player.TryGet(out MoveSpeed moveSpeed, out RotationSpeed rotationSpeed))
			{
				Vector3 moveDirection = moveInput.value;
				moveDirection.Normalize();
				Quaternion lookRot = Quaternion.LookRotation(Vector3.forward, moveDirection);
				transform.position += moveSpeed.value * delta * moveInput.value;
				transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, rotationSpeed.value * delta);

				player.Get<ChangeTransformEvent>();
			}
		}
	}
}