using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _radius = 10f;

    private Vector3 _target;

    private void Start()
    {
        _target = GetRandomTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target)
        {
            _target = GetRandomTarget();
        }
    }

    private Vector3 GetRandomTarget()
    {
        return Random.insideUnitCircle * _radius;
    }
}
