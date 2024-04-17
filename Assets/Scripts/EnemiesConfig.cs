using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(EnemiesConfig), menuName = "ScriptableObjects/" + nameof(EnemiesConfig), order = 1)]
public class EnemiesConfig : ScriptableObject
{
	public List<GameObject> EnemiesVariants;
}
