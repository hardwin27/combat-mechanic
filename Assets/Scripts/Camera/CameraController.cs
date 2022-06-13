using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private Vector2 _cameraOffset = new Vector2(0f, 0.5f);

    private void Update()
    {
        CameraFollowHandler();
    }

    private void CameraFollowHandler()
    {
        if(_playerTransform != null)
        {
            transform.position = new Vector3(_playerTransform.position.x + _cameraOffset.x, _playerTransform.position.y + _cameraOffset.y, transform.position.z);
        }
    }
}
