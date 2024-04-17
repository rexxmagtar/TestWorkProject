using UnityEngine;

public interface IPlayerInputController
{
	IInput<Vector2> Move { get; }

	IInput<float> Rotate { get; }

	IInput<bool> CastSpell { get; }

	IInput<int> ChangeSpell { get; }

}
