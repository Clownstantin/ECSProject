using UnityEngine;

namespace RougeLike.PlayerInput
{
	internal readonly struct ButtonsPressedEvent
	{
		public readonly KeyCode[] pressedKeys;

		public ButtonsPressedEvent(KeyCode key) => pressedKeys = new[] { key };

		public void Add(KeyCode key)
		{
			int count = pressedKeys.Length;
			var cache = new KeyCode[count + 1];
			cache[count] = key;

			for(int i = 0; i < count; i++)
				cache[i] = pressedKeys[i];
		}
	}
}