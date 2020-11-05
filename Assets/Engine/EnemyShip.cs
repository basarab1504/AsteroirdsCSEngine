using System;
using Asteroids;
using UnityEngine;

public class EnemyShip : Ship
{
    public float VisibilityAngle { get; set; }

    public override void Start()
    {
        base.Start();
        // Direction = GetDirection();
    }

    public override void Update()
    {
        base.Update();
        if (Game.AnyOverlaps(Transform.Position, 10, Layer.Player, out Vector2 hit))
        {
            float signedAngle = Vector2.SignedAngle(Transform.Rotation, hit - Transform.Position);
            if (signedAngle >= VisibilityAngle)
            {
                Rotate(1 * Mathf.Sign(signedAngle));
            }
        }
    }

    // private Vector3 GetDirection()
    // {
    //     var m = rnd.NextDouble() > 0.9f ? -1 : 1;
    //     return new Vector3(0, m, 0);
    // }
}
