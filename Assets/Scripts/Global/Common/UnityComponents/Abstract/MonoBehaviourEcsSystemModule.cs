using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike
{
	public abstract class MonoBehaviourEcsSystemModule : MonoBehaviour, IEcsSystemModule
	{
		public virtual void AddSystem(EcsSystems updateSystem, EcsSystems fixedUpdateSystem) { }

		public virtual void AddOneFrameToSystem(EcsSystems updateSystem, EcsSystems fixedUpdateSystem) { }

		public virtual void AddPrioritySystem(EcsSystems updateSystem, EcsSystems fixedUpdateSystem) { }

		public virtual void InjectData(EcsSystems updateSystem, EcsSystems fixedUpdateSystem) { }
	}
}