using UnityEngine;

public abstract class Spell : MonoBehaviour
{
	[field: SerializeField]
	public float Damage { get; private set; }

	[field: SerializeField]
	public float FlySpeed { get; private set; }

	public abstract void AffectEntity(GameEntity entity);

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<GameEntity>(out GameEntity entity))
		{
			AffectEntity(entity);
			Destroy(gameObject);
		}
	}
}
