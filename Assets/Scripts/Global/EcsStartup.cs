using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;
using UnityEngine;

namespace RougeLike
{
	internal sealed class EcsStartup : MonoBehaviour
	{
		private readonly IEcsSystemModule[] r_integratedModules = { new CommonModule() };

		[SerializeField] private ConfigurationSettings _configs;

		private Game _game;
		private EcsWorld _world;
		private EcsSystems _systems;
		private IEcsSystemModule[] _modules;

		private void Start()
		{
			InitWorld();
			InitModules();
			InitSystems();
		}

		private void Update() => _systems?.Run();

		private void OnDestroy()
		{
			_systems?.Destroy();
			_systems = null;
			_world?.Destroy();
			_world = null;
		}

		private void InitWorld()
		{
			_world = new EcsWorld();
			_systems = new EcsSystems(_world);

			_game = FindObjectOfType<Game>();
#if UNITY_EDITOR
			EcsWorldObserver.Create(_world);
			EcsSystemsObserver.Create(_systems);
#endif
		}

		private void InitModules()
		{
			MonoBehaviourEcsSystemModule[] childModules = GetComponentsInChildren<MonoBehaviourEcsSystemModule>();
			int childModulesCount = childModules.Length;
			int modulesCount = childModulesCount + r_integratedModules.Length;
			_modules = new IEcsSystemModule[modulesCount];

			for(int i = 0; i < _modules.Length; i++)
				_modules[i] = i < childModulesCount ? childModules[i] : r_integratedModules[i - childModulesCount];
		}

		private void InitSystems()
		{
			InjectData();

			foreach(IEcsSystemModule module in _modules)
			{
				module.InjectData(_systems);
				module.AddPrioritySystem(_systems);
				module.AddSystem(_systems);
				module.AddOneFrameToSystem(_systems);
			}

			_systems.Init();

			_game.InitEntity(_world);
			_modules = null;
		}

		private void InjectData()
		{
			_systems.Inject(_configs);
			if(_game) _systems.Inject(_game);
		}
	}
}