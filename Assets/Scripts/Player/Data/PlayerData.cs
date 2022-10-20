using System;
using UnityEngine;

namespace RougeLike.PlayerModule
{
	[Serializable]
	public struct PlayerData
	{
		[SerializeField] private GameObject _playerPrefab;
		[SerializeField] private Transform _container;

		public GameObject PlayerPrefab => _playerPrefab;
		public Transform Container => _container;
	}
}