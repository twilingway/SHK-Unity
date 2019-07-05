using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private bool _isLive = true;
    
    public string Name;
    [SerializeField] private int _speedBounty = 1;
    [SerializeField] private float _timeBounty = 0f;

    public int GetSpeed()
    {
        return _speedBounty;
    }

    public float GetTime()
    {
        return _timeBounty;
    }

    public bool IsLive
    {
        get
        {
            return _isLive;
        }
        set
        {
            _isLive = value;
            if (_isLive == false)
            {
                Destroy(gameObject);
                if (OnDead != null)
                {
                    OnDead(this);
                }
            }
        }
    }

    public event UnityAction<Enemy> OnDead;
}
