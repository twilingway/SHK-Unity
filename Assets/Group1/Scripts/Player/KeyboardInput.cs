using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private bool _timer = true;
    [SerializeField] private float _time = 20f;

    void Update()
    {
        TakeTime();
        Move();
    }

    private void TakeTime()
    {
        if (_timer)
        {
            _time -= Time.deltaTime;
            if (_time < 0)
            {
                _timer = false;
                _speed /= 2;
            }
        }
    }

    public void AddSpeed(float speed)
    {
        _speed *= speed;
    }
    public void AddTime(float time)
    {
        _time += time;
    }
    public void SetTimer(bool timer)
    {
        _timer = timer;
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, _speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -_speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(_speed * Time.deltaTime, 0, 0);
    }
}
