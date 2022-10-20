using UnityEngine;

namespace RougeLike.PlayerModule
{
	[CreateAssetMenu(menuName = "Settings/Player", fileName = "PlayerSettings", order = 51)]
	public class PlayerSettings : ScriptableObject
	{
		[Header("Stats")]
		[SerializeField] private float _moveSpeed;
		[SerializeField] private float _rotationSpeed;

		public float MoveSpeed => _moveSpeed;
		public float RotationSpeed => _rotationSpeed;
	}
}