using UnityEngine;

namespace RougeLike
{
	public abstract class DungeonGenerator : MonoBehaviour
	{
		[SerializeField] protected Vector2Int startPosition = default;
		[SerializeField] protected TilemapVisualizer visualizer = default;

		public void GenerateDungeon() => RunProceduralGeneration();

		public void ClearDungeon() => visualizer.Clear();
		
		protected abstract void RunProceduralGeneration();
	}
}