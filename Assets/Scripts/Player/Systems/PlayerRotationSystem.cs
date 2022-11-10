using Leopotam.Ecs;
using RougeLike.PlayerInput;

namespace RougeLike.PlayerModule
{
	public class PlayerRotationSystem : IEcsRunSystem
	{
		private EcsFilter<PlayerTag, EntityTransform> _playerFilter = default;
		private EcsFilter<InputTag> _inputFilter = default;

		public void Run()
		{
			if(_playerFilter.IsEmpty() || _inputFilter.IsEmpty()) return;

			EcsEntity player = _playerFilter.GetEntity(0);
			EcsEntity input = _inputFilter.GetEntity(0);
			ref EntityTransform transform = ref _playerFilter.Get2(0);

			if(input.TryGet(out MoveInput moveInput) && player.TryGet(out RotationSpeed rotationSpeed))
			{
				player.Get<ChangeTransformEvent>();
			}
		}
	}
}