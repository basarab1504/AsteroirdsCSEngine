using System;
using Asteroids;
using UnityEngine;

public class EnemyShip : Ship
{
    public float VisibilityAngle { get; set; }
    public float VisibilityRadius { get; set; }
    public float KeepDistance { get; set; }

    public override void Start()
    {
        base.Start();
        // Direction = GetDirection();
    }

    public override void Update()
    {
        // base.Update();
        if (Game.AnyOverlaps(Transform.Position, VisibilityRadius, Layer.Player, out Vector2 hit))
        {
            float signedAngle = Vector2.SignedAngle(Transform.Rotation, hit - Transform.Position);
            if (Math.Abs(signedAngle) >= VisibilityAngle)
            {
                Rotate(RotationSpeed * Mathf.Sign(signedAngle));
            }

            var dir = hit - Transform.Position;
            if (dir.magnitude > KeepDistance)
            {
                var dirNorm = dir.normalized * Speed;
                Move(dirNorm * Speed * Game.DeltaTime);
                // GetComponent<Thruster>().AddForce(dirNorm);
            }
        }
    }

    // private Vector3 GetDirection()
    // {
    //     var m = rnd.NextDouble() > 0.9f ? -1 : 1;
    //     return new Vector3(0, m, 0);
    // }
}
