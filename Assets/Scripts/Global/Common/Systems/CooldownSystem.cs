using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike
{
	public class CooldownSystem : IEcsRunSystem
	{
		private EcsFilter<Cooldown> _filter = default;

		public void Run()
		{
			foreach(int index in _filter)
			{
				EcsEntity entity = _filter.GetEntity(index);
				ref Cooldown cooldown = ref _filter.Get1(index);
				cooldown.value -= Time.deltaTime;

				if(cooldown.value <= 0) entity.Del<Cooldown>();
			}
		}
	}
}