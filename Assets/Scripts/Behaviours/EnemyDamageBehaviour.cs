using UnityEngine;

public class EnemyDamageBehaviour : MonoBehaviour, IEntityBehaviour
{
	private EnemyEntity _enemyEntity;

	private EnemySpawnManager _spawnManager;

	public void Register(GameEntity entity)
	{
		_enemyEntity = (EnemyEntity)entity;

		_spawnManager = InjectionStub.Instance.Resolve<EnemySpawnManager>();
	}

	public void Deregister()
	{
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.TryGetComponent<DamagableBehaviour>(out DamagableBehaviour damagableBehaviour))
		{
			damagableBehaviour.ReceiveDamage(_enemyEntity.Damage);

			_spawnManager.Despawn(_enemyEntity);
		}
	}
}
