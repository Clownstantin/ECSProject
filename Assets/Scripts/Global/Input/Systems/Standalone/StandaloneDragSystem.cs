#if UNITY_EDITOR || UNITY_STANDALONE
using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike.PlayerInput.Standalone
{
	internal sealed class StandaloneDragSystem : IEcsRunSystem
	{
		private EcsFilter<InputTag, Coordinate> _coordinateFilter = default;

		private bool _isPointerDown;
		private EcsEntity _entity;
		private Vector3 _oldPosition;

		public void Run()
		{
			if(_coordinateFilter.GetEntitiesCount() < 1) return;

			_entity = _coordinateFilter.GetEntity(0);
			Coordinate coordinate = _coordinateFilter.Get2(0);

			CheckDrag(coordinate);
			CheckPointer(coordinate);
		}

		private void CheckPointer(Coordinate coordinate)
		{
			if(_entity.Has<PointerDownEvent>())
			{
				_isPointerDown = true;
				_oldPosition = coordinate.value;
			}
			else if(_entity.Has<PointerUpEvent>())
			{
				_isPointerDown = false;
				_oldPosition = Vector3.zero;
			}
		}

		private void CheckDrag(Coordinate position)
		{
			if(!_isPointerDown || position.value == _oldPosition) return;

			_entity.Replace(new DragEvent(_oldPosition - position.value));
			_oldPosition = position.value;
		}
	}
}
#endif