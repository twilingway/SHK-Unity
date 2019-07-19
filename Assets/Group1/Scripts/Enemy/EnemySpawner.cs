using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;
    [SerializeField] private int _spawnCount;
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    private void Awake()
    {
        foreach (var e in GameObject.FindObjectsOfType<Enemy>())
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
            if (_spawnCount % 5 == 0)
            {
                AddEnemy(EnemyType.Default);
            }
            else
            {
                AddEnemy(EnemyType.WithSpeed);
            }
        }
    }

    private GameObject CreateEnemy(GameObject gameObject)
    {
        return Instantiate(gameObject, _spawnPoint.position, Quaternion.identity, _spawnPoint);
    }

    private void AddSubscription(Enemy enemy)
    {
        enemy.OnDead += ObjectDeadHandler;
        enemy.OnDead += _player.AddBounty;
        _enemies.Add(enemy);
    }

    public void AddEnemy(EnemyType enemyTypes)
    {
        switch (enemyTypes)
        {
            case EnemyType.Default:
                AddSubscription(CreateEnemy(_prefabs[0]).GetComponent<Enemy>());
                break;
            case EnemyType.WithSpeed:
                AddSubscription(CreateEnemy(_prefabs[1]).GetComponent<Enemy>());
                break;
            default:
                break;
        }
    }
}
