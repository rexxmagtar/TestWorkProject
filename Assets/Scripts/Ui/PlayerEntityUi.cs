using TMPro;
using UnityEngine;

public class PlayerEntityUi : MonoBehaviour
{
	[field: SerializeField]
	private TextMeshProUGUI CurrentSpellInfo { get; set; }

	[field: SerializeField]
	private SpellCastBehaviour SpellCastBehaviour { get; set; }

	private void Update()
	{
		transform.rotation = Quaternion.identity;
		CurrentSpellInfo.text = SpellCastBehaviour.CurrentSpell.ToString();
	}
}
