using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _time = 20f;

    private BoxCollider _boxCollider;
    private Vector3 _sizeDefault;

    private void Awake()
    {
        _boxCollider = transform.GetComponent<BoxCollider>();
        _sizeDefault = _boxCollider.size;
    }

    private bool IsTimerOn => _time >= 0;

    private void Update()
    {
        if (IsTimerOn)
        {
            SubtractBountyTime(Time.deltaTime);
        }
    }

    private void SubtractBountyTime(float time)
    {
        _time -= time;
        if (_time < 0)
        {
            _speed /= 2;
            _boxCollider.size = _sizeDefault;
        }
    }

    public void AddBounty(Enemy enemy)
    {
        _speed *= enemy.SpeedBounty;
        _time += enemy.TimeBounty;
        if (enemy.InterectionBounty.x > 0f)
        { 
            _boxCollider.size = Vector3.Scale(_boxCollider.size, enemy.InterectionBounty);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f ) * _speed;
    }
}
