using Leopotam.Ecs;

namespace RougeLike
{
	public static class EcsExtension
	{
		public static bool TryGet<T>(this EcsEntity entity, out T component) where T : struct
		{
			if(entity.Has<T>())
			{
				component = entity.Get<T>();
				return true;
			}

			component = default;
			return false;
		}

		public static bool TryGet<T1, T2>(this EcsEntity entity, out T1 component1, out T2 component2) where T1 : struct
		                                                                                               where T2 : struct

		{
			bool c1 = entity.TryGet(out component1);
			bool c2 = entity.TryGet(out component2);
			return c1 && c2;
		}

		public static bool TryGet<T1, T2, T3>(this EcsEntity entity, out T1 component1, out T2 component2, out T3 component3) where T1 : struct
		                                                                                                                      where T2 : struct
		                                                                                                                      where T3 : struct

		{
			bool c12 = entity.TryGet(out component1, out component2);
			bool c3 = entity.TryGet(out component3);
			return c12 && c3;
		}

		public static bool TryGet<T1, T2, T3, T4>(this EcsEntity entity, out T1 component1, out T2 component2, out T3 component3, out T4 component4) where T1 : struct
		                                                                                                                                             where T2 : struct
		                                                                                                                                             where T3 : struct
		                                                                                                                                             where T4 : struct

		{
			bool c123 = entity.TryGet(out component1, out component2, out component3);
			bool c4 = entity.TryGet(out component4);
			return c123 && c4;
		}
	}
}