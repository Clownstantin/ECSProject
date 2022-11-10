using Leopotam.Ecs;
using RougeLike.PlayerInput;
using UnityEngine;

namespace RougeLike.PlayerModule
{
	public class PlayerAnimationSystem : IEcsRunSystem
	{
		private EcsFilter<PlayerTag> _playerFilter = default;
		private EcsFilter<InputTag> _inputFilter = default;

		public void Run()
		{
			if(_inputFilter.IsEmpty() || _playerFilter.IsEmpty()) return;

			EcsEntity player = _playerFilter.GetEntity(0);
			EcsEntity input = _inputFilter.GetEntity(0);

			if(player.TryGet(out ComponentLink<Animator> animator) && input.TryGet(out MoveInput moveInput))
			{
				Animator anim = animator.value;
				Vector3 moveVector = moveInput.value;

				float absMoveInput = Mathf.Abs(moveVector.x) + Mathf.Abs(moveVector.y);
				float moveAmount = Mathf.Clamp01(absMoveInput);
				anim.SetFloat(AnimatorParameterBase.MoveAmountHash, moveAmount);
			}
		}
	}
}