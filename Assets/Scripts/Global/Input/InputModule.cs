using Leopotam.Ecs;
using RougeLike.PlayerInput.Mobile;
using RougeLike.PlayerInput.Standalone;
using UnityEngine;

namespace RougeLike.PlayerInput
{
	internal sealed class InputModule : MonoBehaviourEcsSystemModule
	{
		[SerializeField] private InputData _inputData;

		public override void AddOneFrameToSystem(EcsSystems system)
		{
			system.OneFrame<ButtonsPressedEvent>()
			      .OneFrame<PointerUpEvent>()
			      .OneFrame<PointerDownEvent>()
			      .OneFrame<OverUIEvent>()
			      .OneFrame<DragEvent>()
			      .OneFrame<ScrollEvent>();
		}

		public override void InjectData(EcsSystems system)
		{
			system.Inject(_inputData);
		}

		public override void AddSystem(EcsSystems system)
		{
#if UNITY_EDITOR
			if(_inputData.Type == InputData.InputType.Standalone) AddStandaloneInputSystem(system);
			else if(_inputData.Type == InputData.InputType.Mobile) AddMobileInputSystem(system);
#elif UNITY_STANDALONE
			AddStandaloneInputSystem(system);
#elif UNITY_ANDROID || UNITY_IOS
			AddMobileInputSystem(system);
#endif
		}

#if UNITY_EDITOR || UNITY_ANDROID || UNITY_IOS
		private static void AddMobileInputSystem(EcsSystems system)
		{
			system.Add(new MobileInputSystem())
			      .Add(new MobileFingerPositionSystem());
		}
#endif

#if UNITY_EDITOR || UNITY_STANDALONE
		private static void AddStandaloneInputSystem(EcsSystems system)
		{
			system.Add(new StandaloneInputSystem())
			      .Add(new StandaloneMovementSystem())
			      .Add(new StandalonePointerPositionSystem())
			      .Add(new StandaloneDragSystem())
			      .Add(new StandaloneScrollSystem());
		}
#endif

		public override void AddPrioritySystem(EcsSystems updateSystem) { }
	}
}