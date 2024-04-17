using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SpellsConfig), menuName = "ScriptableObjects/" + nameof(SpellsConfig), order = 1)]
public class SpellsConfig : ScriptableObject
{
	[Serializable]
	public class SpellPair
	{
		public SpellType SpellType;
		public GameObject Preafab;
	}

	public List<SpellPair> Spells;
}
