#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace RougeLike.Dev
{
	[CustomEditor(typeof(DungeonGenerator), true)]
	public class DungeonGeneratorEditor : Editor
	{
		private DungeonGenerator _generator = default;

		private void Awake() => _generator = (DungeonGenerator)target;

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			if(GUILayout.Button("Generate")) _generator.GenerateDungeon();
		}
	}
}
#endif