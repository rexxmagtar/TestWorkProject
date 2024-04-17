using UnityEngine;

public class EnemyMoveBehaviour : MonoBehaviour, IEntityBehaviour
{
	private PlayerEntity _playerEntity;

	private EnemyEntity _enemyEntity;

	private Rigidbody2D _rb;

	public void Register(GameEntity entity)
	{
		_enemyEntity = (EnemyEntity)entity;

		_playerEntity = FindObjectOfType<PlayerEntity>();

		_rb = _enemyEntity.GetComponent<Rigidbody2D>();
	}

	public void Deregister()
	{

	}

    private void FixedUpdate()
    {
		if(_playerEntity == null)
		{
			return;
		}

		var directionToPlayer = (_playerEntity.transform.position - _enemyEntity.transform.position).normalized;

		_rb.velocity = directionToPlayer * _enemyEntity.MoveSpeed;
    }
}
