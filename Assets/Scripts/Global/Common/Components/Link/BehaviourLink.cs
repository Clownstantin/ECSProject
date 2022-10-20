using Leopotam.Ecs;

namespace RougeLike
{
	internal readonly struct BehaviourLink<T> where T : EntityLinkedMonoBehaviour
	{
		public readonly T gameObject;

		public BehaviourLink(T obj, EcsEntity entity)
		{
			gameObject = obj;
			gameObject.Init(entity);
		}
	}
}