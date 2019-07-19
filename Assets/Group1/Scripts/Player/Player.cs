using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _time = 20f;

    private bool IsTimerOn => _time >= 0;

    private void Update()
    {
        if (IsTimerOn)
        {
            SubtractBountyTime(Time.deltaTime);
        }
        Move();
    }

    private void SubtractBountyTime(float time)
    {
        _time -= time;
        if (_time < 0)
        {
            _speed /= 2;
        }
    }

    public void AddBounty(Enemy enemy)
    {
        _speed *= enemy.SpeedBounty;
        _time += enemy.TimeBounty;
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, _speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
    }
}
