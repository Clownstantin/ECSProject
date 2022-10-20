using Leopotam.Ecs;
using UnityEngine.EventSystems;

namespace RougeLike.PlayerInput
{
	public abstract class InputSystem : IEcsInitSystem, IEcsRunSystem
	{
		protected readonly EcsWorld world = default;
		protected EcsEntity inputEntity;

		public void Init()
		{
			inputEntity = world.NewEntity();
			inputEntity.Get<InputTag>();
			OnInit();
		}

		public void Run()
		{
			if(EventSystem.current.IsPointerOverGameObject())
				inputEntity.Get<OverUIEvent>();
			OnRun();
		}

		protected virtual void OnInit() { }

		protected virtual void OnRun() { }
	}
}