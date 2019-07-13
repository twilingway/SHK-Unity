using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InfinitySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyPrefabWithSpeed;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;
    [SerializeField] private int _spawnCount;
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    private void Awake()
    {
        foreach (Enemy e in GameObject.FindObjectsOfType<Enemy>())
        {
            AddSubscription(e);
        };
    }

    private void ObjectDeadHandler(Enemy owner)
    {
        _enemies.Remove(owner);
        _spawnCount--;
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (_spawnCount > 0)
        {
            GameObject newObject;

            if (_spawnCount % 5 == 0)
            {
                newObject = Instantiate(_enemyPrefabWithSpeed, _spawnPoint.position, Quaternion.identity, _spawnPoint);
            }
            else
            {
                newObject = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity, _spawnPoint);
            }
            AddSubscription(newObject.GetComponent<Enemy>());
        }
    }

    private void AddSubscription(Enemy enemy)
    {
        enemy.OnDead += ObjectDeadHandler;
        enemy.OnDead += _player.AddBounty;
        _enemies.Add(enemy);
    }
}
