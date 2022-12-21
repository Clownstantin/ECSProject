using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike.UI
{
	public class CreateUISystem : IEcsInitSystem
	{
		private EcsWorld _world = default;
		private UIData _uiData = default;

		public void Init()
		{
			EcsEntity uiEntity = _world.NewEntity();

			UIManager uiManager = Object.Instantiate(_uiData.UIManager);

			uiEntity.Get<UITag>();
			uiEntity.Replace(new ComponentLink<UIManager>(uiManager));
			uiEntity.Get<SpawnEvent>();
		}
	}
}