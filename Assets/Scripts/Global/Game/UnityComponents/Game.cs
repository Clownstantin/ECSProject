using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike
{
	public class Game : MonoBehaviour
	{
		private EcsEntity _gameEntity = default;

		private void Awake()
		{
			if(FindObjectsOfType<Game>().Length > 1)
			{
				Destroy(gameObject);
				throw new UnityException("You can have only one 'Game' object in the scene!");
			}

			DontDestroyOnLoad(this);
		}

		public void InitEntity(EcsWorld world)
		{
			_gameEntity = world.NewEntity();
			_gameEntity.Get<GameTag>();
		}

		public void SetComponent<T>() where T : struct => _gameEntity.Get<T>();

		public void DelComponent<T>() where T : struct => _gameEntity.Del<T>();

		public void ReplaceComponent<T>(T component) where T : struct => _gameEntity.Replace(component);
	}
}