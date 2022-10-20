using Leopotam.Ecs;

namespace RougeLike
{
	internal readonly struct EntityLink<T> where T : struct
	{
		public readonly EcsEntity value;

		public EntityLink(ref EcsEntity entity) => value = entity;
	}
}