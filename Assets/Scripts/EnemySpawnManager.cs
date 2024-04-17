using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
	[field:SerializeField]
	private int PoolSize { get;set;}

	[field: SerializeField]
	private List<Transform> SpawnPoints {get; set;}

	private Queue<EnemyEntity> _entitiesPool = new Queue<EnemyEntity>();

	private EnemiesConfig _enemiesConfig;

	private void Start()
	{
		_entitiesPool = new Queue<EnemyEntity>(PoolSize);
		_enemiesConfig = InjectionStub.Instance.Resolve<EnemiesConfig>();

		for(int i=0; i<PoolSize; i++)
		{
			var enemy = Instantiate(_enemiesConfig.EnemiesVariants[Random.Range(0, _enemiesConfig.EnemiesVariants.Count)],Vector3.zero, Quaternion.identity,this.transform);

			enemy.gameObject.SetActive(false);

			_entitiesPool.Enqueue(enemy.GetComponent<EnemyEntity>());
		}


		while(_entitiesPool.Count > 0)
		{
			SpawnRandomEnemy();
		}
	}

	public EnemyEntity SpawnRandomEnemy()
	{
		var spawnPoint = SpawnPoints[Random.Range(0,SpawnPoints.Count)];

		var enemy = _entitiesPool.Dequeue();

		enemy.transform.position = spawnPoint.position;

		enemy.gameObject.SetActive(true );

		enemy.Health = enemy.MaxHealth;

		return enemy;
	}

	public void Despawn(EnemyEntity entity)
	{
		entity.transform.position = Vector3.zero;
		entity.gameObject.SetActive(false);

		_entitiesPool.Enqueue(entity);

		SpawnRandomEnemy();

	}
}
