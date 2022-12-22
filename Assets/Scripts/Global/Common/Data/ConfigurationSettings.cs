using RougeLike.PlayerModule;
using UnityEngine;

namespace RougeLike
{
	[CreateAssetMenu(menuName = "Settings/ConfigurationSettings", fileName = "ConfigurationSettings", order = 50)]
	public class ConfigurationSettings : ScriptableObject
	{
		[SerializeField] private PlayerSettings _playerSettings = default;

		public PlayerSettings PlayerSettings => _playerSettings;
	}
}