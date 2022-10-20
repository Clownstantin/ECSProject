#if UNITY_EDITOR || UNITY_STANDALONE
using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike.PlayerInput.Standalone
{
	internal sealed class StandalonePointerPositionSystem : IEcsRunSystem
	{
		private EcsFilter<InputTag> _inputFilter = default;

		private Vector3 _oldPositon;

		public void Run()
		{
			Vector3 position = Input.mousePosition;

			if(position == _oldPositon || _inputFilter.GetEntitiesCount() < 1) return;

			_oldPositon = position;
			_inputFilter.GetEntity(0).Replace(new Coordinate(position));
		}
	}
}
#endif