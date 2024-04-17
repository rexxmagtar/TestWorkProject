using System;
using UnityEngine;

[Serializable]
public enum SpellType
{
	Burger,
	Cola
}

public class SpellFactory
{
	private SpellsConfig _spellConfig;

	public SpellFactory()
	{
		_spellConfig = InjectionStub.Instance.Resolve<SpellsConfig>();
	}


	public Spell CreateSpell(Vector2 position, Vector2 direction,SpellType type)
	{
		var prefab = _spellConfig.Spells.Find(pr => pr.SpellType == type).Preafab;

		var gameObj = GameObject.Instantiate(prefab, (Vector3)position+Vector3.back, Quaternion.identity);

		var rb = gameObj.GetComponent<Rigidbody2D>();

		var spell = gameObj.GetComponent<Spell>();

		rb.AddForce(direction * spell.FlySpeed, ForceMode2D.Impulse);

		return spell;
	}
}
