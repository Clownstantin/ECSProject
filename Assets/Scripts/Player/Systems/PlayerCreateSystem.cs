using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike.PlayerModule
{
	internal class PlayerCreateSystem : IEcsInitSystem
	{
		private EcsWorld _world = default;
		private PlayerData _playerData = default;

		public void Init()
		{
			EcsEntity player = _world.NewEntity();
			GameObject playerObj = Object.Instantiate(_playerData.PlayerPrefab, _playerData.Container);

			player.Get<PlayerTag>();
			player.Replace(new EntityTransform(playerObj.transform));
			player.Replace(new ComponentLink<Transform>(playerObj.transform));
			player.Get<ChangeTransformEvent>();
			player.Get<SpawnEvent>();
		}
	}
}