using System;
using Asteroids;
using UnityEngine;

public class EnemyShip : Ship
{
    public float VisibilityAngle { get; set; }
    public float VisibilityRadius { get; set; }
    public float DistanceToKeep { get; set; }

    public override void Start()
    {
        base.Start();
    }
}
