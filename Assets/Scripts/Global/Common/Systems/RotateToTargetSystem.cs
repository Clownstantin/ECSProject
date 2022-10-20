using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike
{
	public class RotateToTargetSystem : IEcsRunSystem
	{
		private EcsFilter<EntityTransform, RotationSpeed, Target, MoveState> _filter = default;

		public void Run()
		{
			if(_filter.IsEmpty()) return;
			float delta = Time.deltaTime;

			foreach(int index in _filter)
			{
				EcsEntity entity = _filter.GetEntity(index);

				if(entity.Has<EndMoveEvent>()) return;

				ref EntityTransform transform = ref _filter.Get1(index);
				Vector3 position = transform.position;
				Vector3 targetPos = _filter.Get3(index).position;
				float turnSpeed = _filter.Get2(index).value;

				Vector3 direction = (targetPos - position).normalized;
				Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.forward);
				transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * delta);

				entity.Get<ChangeTransformEvent>();
			}
		}
	}
}