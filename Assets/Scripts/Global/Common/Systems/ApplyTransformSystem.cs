using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike
{
	public sealed class ApplyTransformSystem : IEcsRunSystem
	{
		private EcsFilter<EntityTransform, ComponentLink<Transform>, ChangeTransformEvent> _filter = default;

		public void Run()
		{
			foreach(int index in _filter)
			{
				EntityTransform transformComponent = _filter.Get1(index);
				Transform transform = _filter.Get2(index).value;

				if(transform.position != transformComponent.position)
					transform.position = transformComponent.position;

				if(transform.rotation != transformComponent.rotation)
					transform.rotation = transformComponent.rotation;
			}
		}
	}
}