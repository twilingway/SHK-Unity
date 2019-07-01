using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMover : MonoBehaviour
{
    private Vector3 _target;

    void Start()
    {
        _target = Random.insideUnitCircle * 4;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, 2 * Time.deltaTime);
        if (transform.position == _target)
        {
            _target = Random.insideUnitCircle * 4;
        }
    }
}
