using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public interface IEnemy
{
    int SpeedBounty { get; }
    float TimeBounty { get; }
    EnemyType Type { get; }

    void Kill();
    void OnTriggerEnter(Collider other);
}
