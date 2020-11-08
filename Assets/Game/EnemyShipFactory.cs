using UnityEngine;

namespace Asteroids
{
    public class EnemyShipFactory : Factory<EnemyShip>
    {
        public Factory<Ammo> BulletFactory { get; set; }

        public override EnemyShip CreateFrom(GameObject g)
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
            c.OnCollision += g.DestroyObject;

            a.Transform.Scale = new Vector2(0.5f, 1);
            a.Speed = 1f;

            var p = g.AddComponent<Gun>();
            var am = p.AddComponent<Pool<Ammo>>();
            p.BulletCount = 1;
            p.AmmoBox = am;
            p.SetAmmo(BulletFactory);
            p.Force = 6;

            return a;
        }
    }
}

