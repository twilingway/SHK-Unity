using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float _distance = 0.2f;

    private InfinitySpawn _infinity;

    private void Start()
    {
        _infinity = GetComponent<InfinitySpawn>();
    }

    private void Update()
    {
        for (int i = _infinity.GetEnemies().Count - 1; i >= 0; i--)
        {
            if (Vector3.Distance(Player.transform.position, _infinity.GetEnemy(i).transform.position) < _distance)
            {
                _infinity.GetEnemy(i).SetIsLive(false);
            }
        }
    }
}
