using UnityEngine;
using UnityEngine.UI;

namespace RougeLike.UI
{
	public class UIManager : EntityLinkedMonoBehaviour
	{
		[SerializeField] private Button _generateButton;

		public Button GenerateButton => _generateButton;
	}
}