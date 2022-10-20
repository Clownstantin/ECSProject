using Leopotam.Ecs;

namespace RougeLike
{
	public class TakeDamageSystem : IEcsRunSystem
	{
		private EcsFilter<DamageEvent, Health> _filter = default;

		public void Run()
		{
			foreach(int index in _filter)
			{
				float damage = _filter.Get1(index).value;
				ref Health health = ref _filter.Get2(index);
				health.Damage(damage);

				if(health.IsAlive) continue;
				EcsEntity entity = _filter.GetEntity(index);
				entity.Get<DestroyedEvent>();
			}
		}
	}
}