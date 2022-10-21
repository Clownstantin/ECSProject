using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike
{
	public abstract class MonoBehaviourEcsSystemModule : MonoBehaviour, IEcsSystemModule
	{
		public virtual void AddSystem(EcsSystems system) { }
		public virtual void AddFixedUpdateSystem(EcsSystems system) { }

		public virtual void AddOneFrameToSystem(EcsSystems system) { }

		public virtual void AddPrioritySystem(EcsSystems system) { }

		public virtual void InjectData(EcsSystems system) { }
	}
}