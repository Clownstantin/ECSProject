using System;
using UnityEngine;

namespace RougeLike.PlayerInput
{
	[Serializable]
	public struct InputData
	{
		[SerializeField] private bool _multitouch;
		[Header("!Editor Only!")]
		[SerializeField] private InputType _type;

		public bool Multitouch => _multitouch;
		public InputType Type => _type;

		public enum InputType { Standalone, Mobile }
	}
}