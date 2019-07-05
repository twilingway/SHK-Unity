using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void EventDelegate();

public class InfinitySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject EnemyPrefabWithSpeed;
    public Transform SpawnPoint;
    public Player Player;
    public int SpawnCount;
    public List<Enemy> Enemies = new List<Enemy>();

    public static InfinitySpawn Instance;

    public void Awake()
    {
        Instance = this;

        foreach (Enemy e in GameObject.FindObjectsOfType<Enemy>())
        {
            e.OnDead += ObjectDeadHandler;
            e.OnDead += Player.EnemyCollisionHandler;
            Enemies.Add(e);
        };
    }

    public void ObjectDeadHandler(Enemy owner)
    {
        Enemies.Remove(owner);
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
            Enemies.Add(enemy);
        }
    }
}
