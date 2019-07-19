using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour

{
    public event UnityAction<Enemy> OnDead;

    [SerializeField] private int _speedBounty = 1;
    [SerializeField] private float _timeBounty = 0f;
    [SerializeField] private EnemyType _type;

    public int SpeedBounty => _speedBounty;
    public float TimeBounty => _timeBounty;
    public EnemyType Type => _type;

    public void Kill()
    {
        Destroy(gameObject);
        OnDead?.Invoke(this);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Kill();
        }
    }
}
