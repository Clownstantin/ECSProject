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
		private EcsSystems _updateSystems;
		private EcsSystems _fixedUpdateSystems;
		private IEcsSystemModule[] _modules;

		private void Start()
		{
			InitWorld();
			InitModules();
			InitSystems();
		}

		private void Update() => _updateSystems?.Run();

		private void FixedUpdate() => _fixedUpdateSystems?.Run();

		private void OnDestroy()
		{
			_updateSystems?.Destroy();
			_updateSystems = null;
			_fixedUpdateSystems?.Destroy();
			_fixedUpdateSystems = null;
			_world?.Destroy();
			_world = null;
		}

		private void InitWorld()
		{
			_world = new EcsWorld();
			_updateSystems = new EcsSystems(_world);
			_fixedUpdateSystems = new EcsSystems(_world);

			_game = FindObjectOfType<Game>();
#if UNITY_EDITOR
			EcsWorldObserver.Create(_world);
			EcsSystemsObserver.Create(_updateSystems);
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
			_updateSystems.Inject(_configs);
			_fixedUpdateSystems.Inject(_configs);

			if(_game)
			{
				_updateSystems.Inject(_game);
				_fixedUpdateSystems.Inject(_game);
			}

			foreach(IEcsSystemModule module in _modules)
			{
				module.InjectData(_updateSystems, _fixedUpdateSystems);
				module.AddPrioritySystem(_updateSystems, _fixedUpdateSystems);
				module.AddSystem(_updateSystems, _fixedUpdateSystems);
				module.AddOneFrameToSystem(_updateSystems, _fixedUpdateSystems);
			}

			_updateSystems.Init();
			_fixedUpdateSystems.Init();

			_game.InitEntity(_world);
			_modules = null;
		}
	}
}