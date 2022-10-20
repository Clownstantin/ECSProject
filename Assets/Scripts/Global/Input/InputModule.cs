using Leopotam.Ecs;
using RougeLike.PlayerInput.Mobile;
using RougeLike.PlayerInput.Standalone;
using UnityEngine;

namespace RougeLike.PlayerInput
{
	internal sealed class InputModule : MonoBehaviourEcsSystemModule
	{
		[SerializeField] private InputData _inputData;

		public override void AddOneFrameToSystem(EcsSystems updateSystem, EcsSystems fixedUpdateSystem)
		{
			updateSystem.OneFrame<ButtonsPressedEvent>()
			            .OneFrame<PointerUpEvent>()
			            .OneFrame<PointerDownEvent>()
			            .OneFrame<OverUIEvent>()
			            .OneFrame<DragEvent>()
			            .OneFrame<ScrollEvent>();
		}

		public override void InjectData(EcsSystems updateSystem, EcsSystems fixedUpdateSystem)
		{
			updateSystem.Inject(_inputData);
			fixedUpdateSystem.Inject(_inputData);
		}

		public override void AddSystem(EcsSystems updateSystem, EcsSystems fixedUpdateSystem)
		{
#if UNITY_EDITOR
			if(_inputData.Type == InputData.InputType.Standalone) AddStandaloneInputSystem(updateSystem);
			else if(_inputData.Type == InputData.InputType.Mobile) AddMobileInputSystem(updateSystem);
#elif UNITY_STANDALONE
			AddStandaloneInputSystem(system);
#elif UNITY_ANDROID || UNITY_IOS
			AddMobileInputSystem(system);
#endif
		}

#if UNITY_EDITOR || UNITY_ANDROID || UNITY_IOS
		private static void AddMobileInputSystem(EcsSystems updateSystem)
		{
			updateSystem.Add(new MobileInputSystem())
			            .Add(new MobileFingerPositionSystem());
		}
#endif

#if UNITY_EDITOR || UNITY_STANDALONE
		private static void AddStandaloneInputSystem(EcsSystems updateSystem)
		{
			updateSystem.Add(new StandaloneInputSystem())
			            .Add(new StandalonePointerPositionSystem())
			            .Add(new StandaloneDragSystem())
			            .Add(new StandaloneScrollSystem());
		}
#endif

		public override void AddPrioritySystem(EcsSystems updateSystem, EcsSystems fixedUpdateSystem) { }
	}
}