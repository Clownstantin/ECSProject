using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike
{
	public class MoveToTargetSystem : IEcsRunSystem
	{
		private EcsFilter<EntityTransform, Target, MoveState> _filter = default;

		public void Run()
		{
			if(_filter.IsEmpty()) return;

			float delta = Time.deltaTime;

			foreach(int index in _filter)
			{
				EcsEntity entity = _filter.GetEntity(index);
				ref EntityTransform transform = ref _filter.Get1(index);
				Vector3 targetPos = _filter.Get2(index).position;

				if(!entity.TryGet(out MoveSpeed moveSpeedComponent)) return;

				float speed = moveSpeedComponent.value;
				transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * delta);

				entity.Get<ChangeTransformEvent>();

				if(transform.position == targetPos) entity.Get<EndMoveEvent>();
			}
		}
	}
}