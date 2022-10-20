using System;
using Leopotam.Ecs;
using UnityEngine;

namespace RougeLike
{
	public abstract class EntityLinkedMonoBehaviour : MonoBehaviour
	{
		private const string EXCEPTION_TEXT = "Entity Linked Mono Behaviour is not initialized! Entity = default";

		private EcsEntity _entity = default;
		private bool _isInitialized = default;

		protected EcsEntity Entity
		{
			get
			{
				if(!_isInitialized) throw new Exception(EXCEPTION_TEXT);
				return _entity;
			}
			private set => _entity = value;
		}

		public void Init(EcsEntity entity)
		{
			_isInitialized = true;
			Entity = entity;
		}
	}
}