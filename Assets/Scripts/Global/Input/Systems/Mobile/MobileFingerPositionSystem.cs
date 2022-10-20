#if UNITY_EDITOR || UNITY_ANDROID || UNITY_IOS
using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike.PlayerInput.Mobile
{
	internal sealed class MobileFingerPositionSystem : IEcsRunSystem
	{
		private EcsFilter<InputTag> _inputFilter = default;

		private Vector3 _oldPositon;

		public void Run()
		{
			if(Input.touchCount == 0) return;

			Vector3 position = Input.GetTouch(0).position;

			if(position == _oldPositon || _inputFilter.GetEntitiesCount() < 1) return;

			_oldPositon = position;
			_inputFilter.GetEntity(0).Replace(new Coordinate(position));
		}
	}
}
#endif