namespace RougeLike
{
	internal struct Health
	{
		private float _health;

		public float Value => _health;
		public bool IsAlive => _health > 0;

		public Health(float value) => _health = value;

		public void Damage(float damage)
		{
			_health -= damage;
			if(_health < 0) _health = 0;
		}
	}
}