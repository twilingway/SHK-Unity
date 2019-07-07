using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitySpawn : MonoBehaviour
{


    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private GameObject EnemyPrefabWithSpeed;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private Player Player;
    [SerializeField] private int SpawnCount;
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    private void Awake()
    {
        foreach (Enemy e in GameObject.FindObjectsOfType<Enemy>())
        {
            e.OnDead += ObjectDeadHandler;
            e.OnDead += Player.EnemyCollisionHandler;
            _enemies.Add(e);
        };
    }

    public void ObjectDeadHandler(Enemy owner)
    {
        _enemies.Remove(owner);
        SpawnCount--;
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        if (SpawnCount > 0)
        {
            GameObject newObject;
            if (SpawnCount % 5 == 0)
            {
                newObject = Instantiate(EnemyPrefabWithSpeed, SpawnPoint.position, Quaternion.identity, SpawnPoint);
            }
            else
            {
                newObject = Instantiate(EnemyPrefab, SpawnPoint.position, Quaternion.identity, SpawnPoint);
            }
            Enemy enemy = newObject.GetComponent<Enemy>();
            enemy.OnDead += ObjectDeadHandler;
            enemy.OnDead += Player.EnemyCollisionHandler;
            _enemies.Add(enemy);
        }
    }

    public List<Enemy> GetEnemies()
    {
        return _enemies;
    }

    public Enemy GetEnemy(int enemy)
    {
        return _enemies[enemy];
    }


}
