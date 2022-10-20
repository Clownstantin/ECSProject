using Leopotam.Ecs;

namespace RougeLike
{
	public class ActionTimerSystem : IEcsRunSystem
	{
		private EcsFilter<ActionTimer> _timerFilter = default;

		public void Run()
		{
			foreach(int index in _timerFilter)
			{
				ref ActionTimer timer = ref _timerFilter.Get1(index);

				if(!timer.Check()) continue;
				EcsEntity entity = _timerFilter.GetEntity(index);
				entity.Del<ActionTimer>();
			}
		}
	}
}