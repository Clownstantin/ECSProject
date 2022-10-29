using Leopotam.Ecs;

namespace RougeLike
{
	public struct CommonModule : IEcsSystemModule
	{
		public void InjectData(EcsSystems system) { }

		public void InjectDataToFixedUpdate(EcsSystems system) { }

		public void AddPrioritySystem(EcsSystems system)
		{
			system.Add(new MoveToTargetSystem())
			      .Add(new RotateToTargetSystem())
			      .Add(new TakeDamageSystem());
		}

		public void AddSystem(EcsSystems system)
		{
			system.Add(new ApplyTransformSystem())
			      .Add(new ApplyLocalTransformSystem())
			      .Add(new CooldownSystem())
			      .Add(new ActionTimerSystem());
		}

		public void AddFixedUpdateSystem(EcsSystems system) { }

		public void AddOneFrameToSystem(EcsSystems system)
		{
			system.OneFrame<ClickEvent>()
			      .OneFrame<SpawnEvent>()
			      .OneFrame<ChangeTransformEvent>()
			      .OneFrame<ChangeLocalTransformEvent>()
			      .OneFrame<ChangeStateEvent>()
			      .OneFrame<EndMoveEvent>()
			      .OneFrame<DamageEvent>()
			      .OneFrame<DestroyedEvent>();
		}
	}
}