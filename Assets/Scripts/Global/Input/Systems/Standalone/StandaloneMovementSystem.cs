#if UNITY_EDITOR || UNITY_STANDALONE
using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike.PlayerInput.Standalone
{
	internal class StandaloneMovementSystem : IEcsRunSystem
	{
		private EcsFilter<InputTag> _inputFilter = default;

		private const string Horizontal = nameof(Horizontal);
		private const string Vertical = nameof(Vertical);

		public void Run()
		{
			if(_inputFilter.GetEntitiesCount() < 1) return;

			EcsEntity input = _inputFilter.GetEntity(0);
			var moveInput = new Vector3(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
			input.Replace(new MoveInput(moveInput));
		}
	}
}
#endif