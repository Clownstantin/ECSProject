using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike.UI
{
	public class UIModule<T> : MonoBehaviourEcsSystemModule
	{
		[SerializeField] private T _UIData = default;

		public override void InjectData(EcsSystems system) => system.Inject(_UIData);
	}
}