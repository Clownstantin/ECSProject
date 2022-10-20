using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike
{
	public sealed class ApplyLocalTransformSystem : IEcsRunSystem
	{
		private EcsFilter<EntityLocalTransform, ComponentLink<Transform>, ChangeLocalTransformEvent> _filter = default;

		public void Run()
		{
			foreach(int index in _filter)
			{
				EntityLocalTransform transformComponent = _filter.Get1(index);
				Transform transform = _filter.Get2(index).value;

				if(transform.localPosition != transformComponent.localPosition)
					transform.position = transformComponent.localPosition;

				if(transform.localRotation != transformComponent.localRotation)
					transform.rotation = transformComponent.localRotation;
			}
		}
	}
}