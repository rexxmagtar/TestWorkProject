public class PlayerEntity : GameEntity
{
	protected override void OnDamageReceived(float damage)
	{
		base.OnDamageReceived(damage);

		if (Health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
