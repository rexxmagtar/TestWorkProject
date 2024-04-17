using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PcInputAxis : Input<Vector2>
{
	private TestProjectControls _inputActions;

	public PcInputAxis()
	{
		Value = Vector2.zero;

		_inputActions = InjectionStub.Instance.Resolve<TestProjectControls>();


		_inputActions.TestProjectMap.PcDirectionUp.performed += OnDirectionUpPerfomed;
		_inputActions.TestProjectMap.PcDirectionDown.performed += OnDirectionDownPerfomed;
		_inputActions.TestProjectMap.PcDirectionLeft.performed += OnDirectionLeftPerfomed;
		_inputActions.TestProjectMap.PcDirectionRight.performed += OnDirectionRightPerformed;

		_inputActions.TestProjectMap.PcDirectionUp.canceled += OnDirectionUpCanceled;
		_inputActions.TestProjectMap.PcDirectionDown.canceled += OnDirectionDownCanceled;
		_inputActions.TestProjectMap.PcDirectionLeft.canceled += OnDirectionLeftCanceled;
		_inputActions.TestProjectMap.PcDirectionRight.canceled += OnDirectionRightCanceled;
	}

	private void OnDirectionUpPerfomed(InputAction.CallbackContext obj)
	{
		ChangeTotalVector(true, Vector2.up);
	}

	private void OnDirectionUpCanceled(InputAction.CallbackContext obj)
	{
		ChangeTotalVector(false, Vector2.up);
	}

	private void OnDirectionDownPerfomed(InputAction.CallbackContext obj)
	{
		ChangeTotalVector(true, Vector2.down);
	}

	private void OnDirectionDownCanceled(InputAction.CallbackContext obj)
	{
		ChangeTotalVector(false, Vector2.down);
	}

	private void OnDirectionLeftPerfomed(InputAction.CallbackContext obj)
	{
		ChangeTotalVector(true, Vector2.left);
	}

	private void OnDirectionLeftCanceled(InputAction.CallbackContext obj)
	{
		ChangeTotalVector(false, Vector2.left);
	}

	private void OnDirectionRightPerformed(InputAction.CallbackContext obj)
	{
		ChangeTotalVector(true, Vector2.right);
	}

	private void OnDirectionRightCanceled(InputAction.CallbackContext obj)
	{
		ChangeTotalVector(false, Vector2.right);
	}

	~PcInputAxis()
	{
		_inputActions.TestProjectMap.PcDirectionUp.performed -= OnDirectionUpPerfomed;
		_inputActions.TestProjectMap.PcDirectionDown.performed -= OnDirectionDownPerfomed;
		_inputActions.TestProjectMap.PcDirectionLeft.performed -= OnDirectionLeftPerfomed;
		_inputActions.TestProjectMap.PcDirectionRight.performed -= OnDirectionRightPerformed;

		_inputActions.TestProjectMap.PcDirectionUp.canceled -= OnDirectionUpCanceled;
		_inputActions.TestProjectMap.PcDirectionDown.canceled -= OnDirectionDownCanceled;
		_inputActions.TestProjectMap.PcDirectionLeft.canceled -= OnDirectionLeftCanceled;
		_inputActions.TestProjectMap.PcDirectionRight.canceled -= OnDirectionRightCanceled;
	}

	private void ChangeTotalVector(bool positive, Vector2 vector)
	{
		if (positive)
		{
			Value += vector;
		}
		else
		{
			Value -= vector;
		}
	}
}

public class PcRotation : Input<float>
{
	private TestProjectControls _inputActions;

	public PcRotation()
	{
		_inputActions = InjectionStub.Instance.Resolve<TestProjectControls>();

		_inputActions.TestProjectMap.MousePosition.performed += OnMouseMove;
	}

	~PcRotation()
	{
		_inputActions.TestProjectMap.MousePosition.performed -= OnMouseMove;
	}

	private void OnMouseMove(InputAction.CallbackContext obj)
	{
		var mousePos = obj.ReadValue<Vector2>();

		var mouseDirection = (mousePos - new Vector2(Screen.width / 2, Screen.height / 2)).normalized;

		var angleRadians = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;

		angleRadians -= 90;

		if (angleRadians < 0) 
		{ 
			angleRadians += 360;
		}


		Value = angleRadians;
	}
}

public class PcCastSpell : Input<bool>
{
	private TestProjectControls _inputActions;

	public PcCastSpell()
	{
		_inputActions = InjectionStub.Instance.Resolve<TestProjectControls>();

		_inputActions.TestProjectMap.CastSpell.performed += OnCastSpell;
	}

	~PcCastSpell()
	{
		_inputActions.TestProjectMap.CastSpell.performed -= OnCastSpell;
	}

	private void OnCastSpell(InputAction.CallbackContext obj)
	{
		Value = true;
		ForceChangeInvoke();
	}
}

public class PcSwapSpell : Input<int>
{
	private TestProjectControls _inputActions;

	public PcSwapSpell()
	{
		_inputActions = InjectionStub.Instance.Resolve<TestProjectControls>();

		_inputActions.TestProjectMap.NextSpell.performed += OnNextSpell;
		_inputActions.TestProjectMap.PrevSpell.performed += OnPrevSpell;
	}

	~PcSwapSpell()
	{
		_inputActions.TestProjectMap.NextSpell.performed -= OnNextSpell;
		_inputActions.TestProjectMap.PrevSpell.performed -= OnPrevSpell;
	}

	private void OnNextSpell(InputAction.CallbackContext obj)
	{
		if (Value == 1)
		{
			ForceChangeInvoke();
		}
		else
		{
			Value = 1;
		}
	}

	private void OnPrevSpell(InputAction.CallbackContext obj)
	{
		if (Value == -1)
		{
			ForceChangeInvoke();
		}
		else
		{
			Value = -1;
		}
	}
}
