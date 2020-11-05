using System;
using Asteroids;
using UnityEngine;

public class EnemyShip : Ship
{
    public override void Start()
    {
        base.Start();
        // Direction = GetDirection();
    }

    // public override void Update()
    // {
    //     base.Update();
    //     if (Game.AnyOverlaps(Transform.Position, 10, Layer.Player, out Vector3 hit))
    //     {
    //         Vector2 a;
    //         Vector2.sig
    //         float signedAngle = Vector3.SignedAngle(transform.up, hit.transform.position - transform.position, Vector3.forward);
    //         if (signedAngle >= visibilityAngle)
    //         {
    //             Rotate(rigidbody.rotation + rotationSpeed * Mathf.Sign(signedAngle));
    //         }
    //         Transform.Rotation = Vector3.Rotate()
    //     }
    // }

    // private Vector3 GetDirection()
    // {
    //     var m = rnd.NextDouble() > 0.9f ? -1 : 1;
    //     return new Vector3(0, m, 0);
    // }
}
