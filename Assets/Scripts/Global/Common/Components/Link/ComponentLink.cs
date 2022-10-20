using UnityEngine;

namespace RougeLike
{
	internal readonly struct ComponentLink<T> where T : Component
	{
		public readonly T value;

		public ComponentLink(T obj) => value = obj;
	}
}