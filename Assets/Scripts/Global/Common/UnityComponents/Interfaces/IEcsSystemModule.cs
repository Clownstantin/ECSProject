using Leopotam.Ecs;

namespace RougeLike
{
	public interface IEcsSystemModule
	{
		void AddSystem(EcsSystems updateSystem, EcsSystems fixedUpdateSystem);
		void AddOneFrameToSystem(EcsSystems updateSystem, EcsSystems fixedUpdateSystem);
		void AddPrioritySystem(EcsSystems updateSystem, EcsSystems fixedUpdateSystem);
		void InjectData(EcsSystems updateSystem, EcsSystems fixedUpdateSystem);
	}
}