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
			var animator = playerObj.GetComponent<Animator>();

			player.Get<PlayerTag>();
			player.Replace(new EntityTransform(playerObj.transform))
			      .Replace(new ComponentLink<Transform>(playerObj.transform));
			if(animator) player.Replace(new ComponentLink<Animator>(animator));
			
			player.Get<ChangeTransformEvent>();
			player.Get<SpawnEvent>();
		}
	}
}