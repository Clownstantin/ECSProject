using UnityEngine;

namespace RougeLike
{
	public readonly struct AnimatorParameterBase
	{
		public static int HorizontalHash => Animator.StringToHash("Horizontal");
		public static int VerticalHash => Animator.StringToHash("Vertical");
		public static int MoveAmountHash => Animator.StringToHash("MoveAmount");
	}
}