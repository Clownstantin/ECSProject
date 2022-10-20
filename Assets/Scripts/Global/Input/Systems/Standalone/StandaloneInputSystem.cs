#if UNITY_EDITOR || UNITY_STANDALONE
using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike.PlayerInput.Standalone
{
	internal sealed class StandaloneInputSystem : InputSystem
	{
		protected override void OnRun()
		{
			if(Input.GetMouseButtonDown(0)) inputEntity.Get<PointerDownEvent>();
			else if(Input.GetMouseButtonUp(0)) inputEntity.Get<PointerUpEvent>();
			else if(Input.mouseScrollDelta != Vector2.zero) inputEntity.Get<ScrollEvent>();
		}
	}
}
#endif