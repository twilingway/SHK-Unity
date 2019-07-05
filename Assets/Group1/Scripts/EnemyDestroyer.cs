using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    public GameObject Player;

    [SerializeField] private float _distance = 0.2f;

    private void Update()
    {
        for (int i = InfinitySpawn.Instance.Enemies.Count - 1; i >= 0; i--)
        {
            var enemy = InfinitySpawn.Instance.Enemies[i];
            
            if (Vector3.Distance(Player.transform.position, enemy.transform.position) < _distance)
            {
                enemy.IsLive = false;
            }
        }
    }
}
