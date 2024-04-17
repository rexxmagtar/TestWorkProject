using System;
using UnityEngine;

public class DamagableBehaviour : MonoBehaviour, IEntityBehaviour
{
	public event Action<float> OnDamageReceived;

	private GameEntity _entity;

	public void Register(GameEntity entity)
	{
		_entity = entity;
	}

	public void Deregister()
	{
	}

	public void ReceiveDamage(float damage)
	{
		var resultDamage = damage * (1- _entity.Armor);
		OnDamageReceived?.Invoke(resultDamage);
	}

}
