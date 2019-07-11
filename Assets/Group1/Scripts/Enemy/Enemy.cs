using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public event UnityAction<Enemy> OnDead;

    public int SpeedBounty { get; } = 1;
    public float TimeBounty { get; } = 0f;

    private bool _isLive = true;

    public void Kill(bool isLive)
    {
        _isLive = isLive;
        if (_isLive == false)
        {
           
            if (OnDead != null)
            {
                OnDead(this);
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Kill(false);
        }
    }
}
