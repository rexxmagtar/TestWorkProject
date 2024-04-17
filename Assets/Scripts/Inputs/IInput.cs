using System;
using System.Diagnostics;
using UnityEngine;

public interface IInput<T>
{
	T Value { get; }

	event Action<IInput<T>> Changed;
}

public abstract class Input<T> : IInput<T> where T : unmanaged
{
	private T _value = default;

	T IInput<T>.Value => this.Value;

	public event Action<IInput<T>> Changed;

	protected void ForceChangeInvoke()
	{
		Changed?.Invoke(this);
	}

	protected T Value
	{
		get => _value;
		set
		{
			if (!value.Equals(_value))
			{
				_value = value;

				Changed?.Invoke(this);
			}
		}
	}
}
