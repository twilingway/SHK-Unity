using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject Player;

    private GameObject[] _enemys;
   
    void Start()
    {
        _enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        int size = _enemys.Length;
        foreach (var enemy in _enemys)
        {
            if (enemy == null)
            {
                size--;
                continue;
            }

            if (Vector3.Distance(Player.transform.position, enemy.transform.position) < 0.2f)
            {
                CheckObjectName(enemy);
            }
        }

        if (size == 0)
        {
            End();
            enabled = false;
        }
    }

    public void End()
    {
        GameOver.SetActive(true);
    }

    public void CheckObjectName(GameObject someObject)
    {
        if (someObject.name == "Speed")
        {   
            var player  = Player.GetComponent<KeyboardInput>();
            player.AddSpeed(2);
            player.AddTime(20);
            player.SetTimer(true);
            Destroy(someObject);
        }

        if (someObject.name == "Enemy")
        {
            Destroy(someObject);
        }
    }
}
