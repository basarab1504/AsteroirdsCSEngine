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

    public override void Update()
    {
        if (Asteroids.Physics.AnyOverlaps(Transform.Position, VisibilityRadius, Layer.Player, out Vector2 hit))
        {

            float signedAngle = Vector2.SignedAngle(Transform.Direction, hit - Transform.Position);
            
            if (Math.Abs(signedAngle) >= VisibilityAngle)
                Parent.Rotate(RotationSpeed * Mathf.Sign(signedAngle));
            else
                GetComponent<Gun>().Shoot();

            var dir = hit - Transform.Position;
            if (dir.magnitude > DistanceToKeep)
            {
                var dirNorm = dir.normalized * Speed;
                Parent.Move(dirNorm * Speed * Asteroids.Time.DeltaTime);
            }

        }
    }
}
