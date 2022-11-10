using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike.CameraModule
{
	internal sealed class CameraModule : MonoBehaviourEcsSystemModule
	{
		[SerializeField] private CameraData _cameraData = default;

		public override void InjectData(EcsSystems system) => system.Inject(_cameraData);

		public override void AddSystem(EcsSystems system)
		{
			system.Add(new CameraCreateSystem())
			      .Add(new CameraInitSystem());
		}
	}
}