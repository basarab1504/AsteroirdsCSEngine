using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyShipFactory : Factory<EnemyShip>
    {
        public Factory<Ammo> BulletFactory { get; set; }

        protected override EnemyShip CreateFrom(GameObject g)
        {
            var a = g.AddComponent<EnemyShip>();
            a.VisibilityRadius = 100;
            a.VisibilityAngle = 15;
            a.DistanceToKeep = 3;
            a.RotationSpeed = 5;

            g.AddComponent<Scorable>().Score = 10;

            var c = g.AddComponent<Collider>();
            c.Transform.Scale = new Vector2(1, 1);
            c.CollisionLayer = Layer.EnemyShip;
            c.Collision += g.DestroyObject;

            a.Transform.Scale = new Vector2(0.5f, 1);
            a.Speed = 1f;

            var p = g.AddComponent<Gun>();
            var am = p.AddComponent<Pool<Ammo>>();
            p.BulletCount = 1;
            p.AddAmmoType(BulletFactory);
            p.Force = 6;

            a.Commands = new List<Command>()
            {
                new Command(() => Asteroids.Physics.AnyOverlaps(a.Transform.Position, a.VisibilityRadius, Layer.Player, out Vector2 hit), () =>
                {
                    Asteroids.Physics.AnyOverlaps(a.Transform.Position, a.VisibilityRadius, Layer.Player, out Vector2 hit);
                    float signedAngle = Vector2.SignedAngle(a.Transform.Direction, hit - a.Transform.Position);

                    if (Math.Abs(signedAngle) >= a.VisibilityAngle)
                        a.Parent.Rotate(a.RotationSpeed * Mathf.Sign(signedAngle));
                    else
                        a.GetComponent<Gun>().Shoot();

                    var dir = hit - a.Transform.Position;
                    if (dir.magnitude > a.DistanceToKeep)
                    {
                        var dirNorm = dir.normalized * a.Speed;
                        a.Parent.Move(dirNorm * a.Speed * Asteroids.Time.DeltaTime);
                    }
                }),
            };

            return a;
        }
    }
}

