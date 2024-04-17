using UnityEngine;

public class BurgerSpell : Spell
{
	[field: SerializeField]
	public float DamageRandomOffset { get; private set; }

	public override void AffectEntity(GameEntity entity)
	{
		var damagable = entity.FindBehaviour<DamagableBehaviour>();

		if (damagable!=null)
		{
			damagable.ReceiveDamage(Damage * (Random.value * DamageRandomOffset));
		}
	}
}
