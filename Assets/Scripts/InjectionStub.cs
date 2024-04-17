using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InjectionStub : MonoBehaviour
{
    private Dictionary<Type,object> _bindings = new Dictionary<Type,object>();

	public static InjectionStub Instance { get; private set; }

    [field: SerializeField]
	private InputActionAsset InputActions { get; set; }

	[field: SerializeField]
	private SpellsConfig SpellsConfig { get; set; }

	[field: SerializeField]
	private EnemiesConfig EnemiesConfig { get; set; }

	[field: SerializeField]
	private EnemySpawnManager EnemySpawnManager { get; set; }

	private void Awake()
	{
		Instance = this;

        DontDestroyOnLoad(Instance);

		Bind<TestProjectControls>(new TestProjectControls(InputActions));
		Bind<IPlayerInputController>(new PcPlayerInputController());
		Bind<SpellsConfig>(SpellsConfig);
		Bind<EnemiesConfig>(EnemiesConfig);
		Bind<SpellFactory>(new SpellFactory());
		Bind<EnemySpawnManager>(EnemySpawnManager);
	}

    public T Resolve<T>()
    {
        if(_bindings.TryGetValue(typeof(T), out var t))
        {
            return (T)t;
        }

        throw new KeyNotFoundException($"{typeof(T).Name} has not been binded");

	}

	private void Bind<T>(T obj)
    {
        if (_bindings.ContainsKey(typeof(T)))
        {
            throw new ArgumentException($"{typeof(T).Name} has already been binded");
        }

        _bindings.Add(typeof(T), obj);
	}

}
