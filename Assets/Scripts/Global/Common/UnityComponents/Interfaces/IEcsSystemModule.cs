using Leopotam.Ecs;

namespace RougeLike
{
	public interface IEcsSystemModule
	{
		void InjectData(EcsSystems system);
		void InjectDataToFixedUpdate(EcsSystems system);
		void AddPrioritySystem(EcsSystems system);
		void AddSystem(EcsSystems system);
		void AddFixedUpdateSystem(EcsSystems system);
		void AddOneFrameToSystem(EcsSystems system);
	}
}