using UnityEngine;

public class SpellCastBehaviour : MonoBehaviour, IEntityBehaviour
{
	[field:SerializeField]
	public SpellType CurrentSpell { get; private set; }

	private SpellsConfig _spellConfig;

	private SpellFactory _spellFactory;

	private IPlayerInputController _playerInputController;

	public void Register(GameEntity entity)
	{
		_spellConfig = InjectionStub.Instance.Resolve<SpellsConfig>();
		_spellFactory = InjectionStub.Instance.Resolve<SpellFactory>();
		_playerInputController = InjectionStub.Instance.Resolve<IPlayerInputController>();

		_playerInputController.ChangeSpell.Changed += OnSpellChangePressed;
		_playerInputController.CastSpell.Changed += OnSpellCastPressed;
	}

	public void Deregister()
	{

		_playerInputController.ChangeSpell.Changed -= OnSpellChangePressed;
		_playerInputController.CastSpell.Changed -= OnSpellCastPressed;
	}
	private void OnSpellCastPressed(IInput<bool> obj)
	{
		CastCurrentSpell();
	}

	private void OnSpellChangePressed(IInput<int> obj)
	{
		SwapSpell(obj.Value);
	}

	public void SwapSpell(int nextIndexChange)
	{
		for(int i = 0; i< _spellConfig.Spells.Count; i++)
		{
			if (_spellConfig.Spells[i].SpellType == CurrentSpell)
			{
				int nextIndex = (i + nextIndexChange) % _spellConfig.Spells.Count;

				if(nextIndex < 0 )
				{
					nextIndex = _spellConfig.Spells.Count - 1;
				}
				CurrentSpell = _spellConfig.Spells[nextIndex].SpellType;

				return;
			}
		}
	}

	public void CastCurrentSpell()
	{
		_spellFactory.CreateSpell(transform.position,
			UnityEngine.Quaternion.Euler(0f, 0f, _playerInputController.Rotate.Value) * Vector2.up,
			CurrentSpell);
	}
}
