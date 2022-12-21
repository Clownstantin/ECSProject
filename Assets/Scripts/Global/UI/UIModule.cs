using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike.UI
{
	public class UIModule : MonoBehaviourEcsSystemModule
	{
		[SerializeField] private UIData _UIData = default;

		public override void InjectData(EcsSystems system) => system.Inject(_UIData);

		public override void AddSystem(EcsSystems system) => system.Add(new CreateUISystem());
	}
}