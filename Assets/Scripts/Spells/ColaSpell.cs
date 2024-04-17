using UnityEngine;

public class ColaSpell : Spell
{
	[field: SerializeField]
	[field: Range(0,1)]
	public float SlowDown { get; private set; }

	public override void AffectEntity(GameEntity entity)
	{
		var damagable = entity.FindBehaviour<DamagableBehaviour>();

		if (damagable != null)
		{
			damagable.ReceiveDamage(Damage);
		}

		entity.MoveSpeed*=SlowDown;
	}
}

