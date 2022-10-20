#if UNITY_EDITOR || UNITY_ANDROID || UNITY_IOS
using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike.PlayerInput.Mobile
{
	internal sealed class MobileInputSystem : InputSystem
	{
		private InputData _inputData = default;

		protected override void OnInit() => Input.multiTouchEnabled = _inputData.Multitouch;

		protected override void OnRun()
		{
			if(Input.touchCount == 0) return;
			Touch touch = Input.GetTouch(0);

			switch(touch.phase)
			{
				case TouchPhase.Began: inputEntity.Get<PointerDownEvent>(); break;
				case TouchPhase.Moved: inputEntity.Replace(new DragEvent(-touch.deltaPosition)); break;
				case TouchPhase.Ended: inputEntity.Get<PointerUpEvent>(); break;
			}
		}
	}
}
#endif