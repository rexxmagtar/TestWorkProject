using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class GameEntity : MonoBehaviour
{
	[field: SerializeField]
	public float Health { get; set; }

	[field: SerializeField]
	public float MaxHealth { get; set; }

	[field: SerializeField]
	public float MoveSpeed { get; set; }

	[field: SerializeField]
	[field: Range(0,1)]
	public float Armor { get; private set; }

	[field: SerializeField]
	private DamagableBehaviour DamagableBehaviour { get; set; }

	[field: SerializeField]
	private List<MonoBehaviour> Behaviours { get; set; }

	private List<IEntityBehaviour> _behavioursConverted;


	protected virtual void Awake()
	{
		_behavioursConverted = new List<IEntityBehaviour>();

		foreach(var beh in Behaviours)
		{
			_behavioursConverted.Add(beh as IEntityBehaviour);
		}


		foreach (var behaviour in _behavioursConverted)
        {
            behaviour.Register(this);
        }

		DamagableBehaviour.OnDamageReceived += OnDamageReceived;
	}

	protected virtual void OnDestroy()
	{
		DamagableBehaviour.OnDamageReceived -= OnDamageReceived;

		foreach (var behaviour in _behavioursConverted)
		{
			behaviour.Deregister();
		}
	}

	public T FindBehaviour<T>() where T : class, IEntityBehaviour
	{
		return _behavioursConverted.Find(match=>match.GetType()  == typeof(T)) as T;
	}

	protected virtual void OnDamageReceived(float damage)
	{
		Health -= damage;
	}

#if UNITY_EDITOR
	[ContextMenu("Collect behaviours")]
    private void CollectBehaviours()
    {
		var allChildren = GetComponentsInChildren<MonoBehaviour>();

		Behaviours = new List<MonoBehaviour>();

		foreach (var beh in allChildren)
		{
			if(beh is IEntityBehaviour)
			{
				Behaviours.Add(beh);
			}
		}

        EditorUtility.SetDirty(this);
    }
#endif
}
