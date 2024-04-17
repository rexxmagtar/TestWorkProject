using UnityEngine;

public class EnemyEntity : GameEntity
{
	[field: SerializeField]
	public float Damage { get; private set; }

	private EnemySpawnManager _spawnManager;

	protected override void Awake()
	{
		base.Awake();

		_spawnManager = InjectionStub.Instance.Resolve<EnemySpawnManager>();
	}

	protected override void OnDamageReceived(float damage)
	{
		base.OnDamageReceived(damage);

		if (Health <= 0)
		{
			_spawnManager.Despawn(this);
		}
	}
}
