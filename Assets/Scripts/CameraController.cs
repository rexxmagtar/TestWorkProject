using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    private PlayerMoveBehaviour _playerMove;

    // Start is called before the first frame update
    void Start()
    {
		_playerMove = FindObjectOfType<PlayerMoveBehaviour>();
	}

	private void LateUpdate()
	{
        _camera.transform.position = _playerMove.transform.position + Vector3.back*10;
	}
}
