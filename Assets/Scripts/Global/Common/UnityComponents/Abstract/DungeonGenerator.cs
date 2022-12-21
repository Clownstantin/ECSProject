using UnityEngine;

namespace RougeLike
{
	public abstract class DungeonGenerator : MonoBehaviour
	{
		[SerializeField] protected ProceduralData proceduralData = default;
		[SerializeField] protected TilemapVisualizer visualizer = default;

		public void GenerateDungeon() => RunProceduralGeneration();

		protected abstract void RunProceduralGeneration();
	}
}