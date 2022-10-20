#if UNITY_EDITOR || UNITY_STANDALONE
using Leopotam.Ecs;
using RougeLike.PlayerInput;
using UnityEngine;

internal sealed class StandaloneScrollSystem : IEcsRunSystem
{
	private EcsFilter<InputTag, ScrollEvent> _inputFilter = default;

	public void Run()
	{
		if(_inputFilter.GetEntitiesCount() < 1) return;
		_inputFilter.Get2(0).delta = Input.mouseScrollDelta.y;
	}
}
#endif