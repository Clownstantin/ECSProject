using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike.PlayerModule
{
	internal sealed class PlayerModule : MonoBehaviourEcsSystemModule
	{
		[SerializeField] private PlayerData _playerData = default;

		public override void InjectData(EcsSystems system) => system.Inject(_playerData);

		public override void AddSystem(EcsSystems system)
		{
			system.Add(new PlayerCreateSystem())
			      .Add(new PlayerInitSystem())
			      .Add(new PlayerMovementSystem())
			      .Add(new PlayerAnimationSystem());
		}
	}
}