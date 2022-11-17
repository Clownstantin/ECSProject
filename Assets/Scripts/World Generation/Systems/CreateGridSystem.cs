using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace RougeLike.WorldModule
{
	public class CreateGridSystem : IEcsInitSystem
	{
		private EcsWorld _world = default;
		private GridData _gridData = default;

		public void Init()
		{
			EcsEntity grid = _world.NewEntity();

			Grid gridObj = Object.Instantiate(_gridData.Grid, _gridData.WorldContainer);
			Tilemap tilemap = gridObj.GetComponentInChildren<Tilemap>();

			grid.Get<GridTag>();
			grid.Replace(new EntityTransform(gridObj.transform))
			    .Replace(new ComponentLink<Transform>(gridObj.transform))
			    .Replace(new ComponentLink<Grid>(gridObj));
			if(tilemap) grid.Replace(new ComponentLink<Tilemap>(tilemap));

			grid.Get<ChangeTransformEvent>();
			grid.Get<SpawnEvent>();
		}
	}
}