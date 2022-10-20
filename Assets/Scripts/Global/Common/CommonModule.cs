using Leopotam.Ecs;

namespace RougeLike
{
	public class CommonModule : IEcsSystemModule
	{
		public void AddSystem(EcsSystems updateSystem, EcsSystems fixedUpdateSystem)
		{
			updateSystem.Add(new ApplyTransformSystem())
			            .Add(new CooldownSystem())
			            .Add(new ActionTimerSystem());
		}

		public void AddOneFrameToSystem(EcsSystems updateSystem, EcsSystems fixedUpdateSystem)
		{
			updateSystem.OneFrame<ClickEvent>()
			            .OneFrame<SpawnEvent>()
			            .OneFrame<ChangeTransformEvent>()
			            .OneFrame<ChangeStateEvent>()
			            .OneFrame<EndMoveEvent>()
			            .OneFrame<DamageEvent>()
			            .OneFrame<DestroyedEvent>();
		}

		public void AddPrioritySystem(EcsSystems updateSystem, EcsSystems fixedUpdateSystem)
		{
			updateSystem.Add(new MoveToTargetSystem())
			            .Add(new RotateToTargetSystem())
			            .Add(new TakeDamageSystem());
		}

		public void InjectData(EcsSystems system, EcsSystems fixedUpdateSystem) { }
	}
}