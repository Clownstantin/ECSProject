using Leopotam.Ecs;
using RougeLike.PlayerInput;
using UnityEngine;

namespace RougeLike.PlayerModule
{
	internal class PlayerMovementSystem : IEcsRunSystem
	{
		private EcsFilter<InputTag> _inputFilter = default;
		private EcsFilter<PlayerTag, EntityTransform> _playerFilter = default;

		private ConfigurationSettings _config = default;

		public void Run()
		{
			if(_inputFilter.IsEmpty() || _playerFilter.IsEmpty()) return;

			PlayerSettings settings = _config.PlayerSettings;

			EcsEntity input = _inputFilter.GetEntity(0);
			EcsEntity player = _playerFilter.GetEntity(0);
			ref EntityTransform transform = ref _playerFilter.Get2(0);

			if(!input.TryGet(out MoveInput moveInput)) return;
			transform.position += settings.MoveSpeed * Time.deltaTime * moveInput.value;
			player.Get<ChangeTransformEvent>();
		}
	}
}