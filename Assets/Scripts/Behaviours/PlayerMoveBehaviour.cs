using UnityEngine;

public class PlayerMoveBehaviour : MonoBehaviour, IEntityBehaviour
{
	private Rigidbody2D _rb;

	private IPlayerInputController _playerInputController;

	private PlayerEntity _playerEntity;

	public void Register(GameEntity entity)
	{
		_playerEntity = (PlayerEntity)entity;

		_playerInputController = InjectionStub.Instance.Resolve<IPlayerInputController>();

		_rb = _playerEntity.GetComponentInChildren<Rigidbody2D>();
	}

	public void Deregister()
	{
	}

	private void FixedUpdate()
	{
		_rb.velocity = _playerInputController.Move.Value.normalized * _playerEntity.MoveSpeed;
		_rb.rotation = _playerInputController.Rotate.Value;
	}
}
