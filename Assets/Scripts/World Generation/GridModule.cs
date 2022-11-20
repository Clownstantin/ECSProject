using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike.WorldModule
{
	public class GridModule : MonoBehaviourEcsSystemModule
	{
		[SerializeField] private GridData _gridData;
		[SerializeField] private ProceduralData _proceduralData;

		public override void InjectData(EcsSystems system)
		{
			system.Inject(_gridData)
			      .Inject(_proceduralData);
		}

		public override void AddSystem(EcsSystems system)
		{
			system.Add(new CreateGridSystem())
			      .Add(new GenerateGridSystem());
		}
	}
}