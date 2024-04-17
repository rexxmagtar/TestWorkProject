using UnityEngine;

public class PcPlayerInputController : IPlayerInputController
{
    private PcInputAxis _playerMoveInput;
	private PcRotation _pcRotation;
	private PcCastSpell _pcCastSpell;
	private PcSwapSpell _pcSwapSpell;

	IInput<Vector2> IPlayerInputController.Move => _playerMoveInput;

	IInput<float> IPlayerInputController.Rotate => _pcRotation;

	IInput<bool> IPlayerInputController.CastSpell => _pcCastSpell;

	IInput<int> IPlayerInputController.ChangeSpell => _pcSwapSpell;


	public PcPlayerInputController()
	{
		_playerMoveInput = new PcInputAxis();
		_pcRotation = new PcRotation();
		_pcCastSpell = new PcCastSpell();
		_pcSwapSpell = new PcSwapSpell();
	}
}
