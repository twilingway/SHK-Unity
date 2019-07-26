using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    [SerializeField] private Vector3 _sizeOverScreen = new Vector3(10f, 10f, 0f);
    [SerializeField] private Camera _camera;
    [SerializeField] private Rigidbody _player;

    private BoxCollider _boxCollider;
    private float _distance;

    private void Awake()
    {   
        _boxCollider = transform.GetComponent<BoxCollider>();
        _distance = Math.Abs(_camera.transform.position.z);

       var position1 = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, 0f, _distance));
       var position2 = _camera.ScreenToWorldPoint(new Vector3(0f, _camera.pixelHeight, _distance));
       
        _boxCollider.size = new Vector3(position1.x * 2, Math.Abs(position1.y) + position2.y, _boxCollider.size.z);
        _boxCollider.size += _sizeOverScreen;
    }

    private void FixedUpdate()
    {
        _player.position = new Vector3
        (   
            Mathf.Clamp(_player.position.x, -_boxCollider.size.x / 2, _boxCollider.size.x / 2),
            Mathf.Clamp(_player.position.y, -_boxCollider.size.y / 2, _boxCollider.size.y / 2),
            0.0f
        );
    }
}
