using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public event UnityAction<Enemy> OnDead;

    [SerializeField] private string _name;
    [SerializeField] private int _speedBounty = 1;
    [SerializeField] private float _timeBounty = 0f;

    private bool _isLive = true;

    public string Name
    {
        get
        {
            return _name;
        }
    }

    public int SpeedBounty
    {
        get
        {
            return _speedBounty;
        }
    }

    public float TimeBounty
    {
        get
        {
            return _timeBounty;
        }
    }

    public bool IsLive
    {
        get
        {
            return _isLive;
        }
    }

    public void SetIsLive(bool isLive)
    {
        _isLive = isLive;
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
