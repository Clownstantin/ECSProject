using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike.UI
{
	public class UIModule<T> : MonoBehaviourEcsSystemModule
	{
		[SerializeField] private T _UIData = default;

		public override void InjectData(EcsSystems updateSystem, EcsSystems fixedUpdateSystem)
		{
			updateSystem.Inject(_UIData);
			fixedUpdateSystem.Inject(_UIData);
		}
	}
}