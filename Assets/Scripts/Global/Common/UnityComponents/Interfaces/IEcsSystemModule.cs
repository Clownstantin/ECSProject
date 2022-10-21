using Leopotam.Ecs;

namespace RougeLike
{
	public interface IEcsSystemModule
	{
		void AddPrioritySystem(EcsSystems system);
		void AddSystem(EcsSystems system);
		void AddFixedUpdateSystem(EcsSystems system);
		void AddOneFrameToSystem(EcsSystems system);
		void InjectData(EcsSystems system);
	}
}