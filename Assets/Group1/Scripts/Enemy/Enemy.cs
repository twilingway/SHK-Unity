using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public event UnityAction<Enemy> OnDead;

    public int SpeedBounty { get; } = 1;
    public float TimeBounty { get; } = 0f;

    public void Kill()
    {   
        Destroy(gameObject);
        OnDead?.Invoke(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Kill();
        }
    }
}
