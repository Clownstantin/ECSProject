using System;
using UnityEngine;

namespace RougeLike.UI
{
	[Serializable]
	public struct UIData
	{
		[SerializeField] private UIManager _uiManager;

		public UIManager UIManager => _uiManager;
	}
}