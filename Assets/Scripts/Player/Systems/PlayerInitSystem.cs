using Leopotam.Ecs;

namespace RougeLike.PlayerModule
{
	internal class PlayerInitSystem : IEcsRunSystem
	{
		private EcsFilter<PlayerTag, SpawnEvent> _playerFilter = default;
		private ConfigurationSettings _config = default;

		public void Run()
		{
			if(_playerFilter.IsEmpty()) return;
			PlayerSettings settings = _config.PlayerSettings;

			EcsEntity player = _playerFilter.GetEntity(0);
			player.Replace(new MoveSpeed(settings.MoveSpeed));
			player.Replace(new RotationSpeed(settings.RotationSpeed));
		}
	}
}