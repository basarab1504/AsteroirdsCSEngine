using UnityEngine;

namespace Asteroids
{
    public class ShipFactory : Factory<Ship>
    {
        public Factory<Ammo> BulletFactory { get; set; }

        public override Ship CreateFrom(GameObject g)
        {
            var a = g.AddComponent<Ship>();
            a.RotationSpeed = 5;

            var t = g.AddComponent<Thruster>();
            t.LinearDrag = 0.9f;

            g.AddComponent<Player>();

            var c = g.AddComponent<Collider>();
            c.Transform.Scale = new Vector2(1, 1);
            c.CollisionLayer = Layer.Player;
            c.OnCollision += g.DestroyObject;

            a.Transform.Scale = new Vector2(0.5f, 1);
            a.Speed = 0.02f;

            // var p = g.AddComponent<Gun>();
            // var am = g.AddComponent<Pool<Ammo>>();
            // p.BulletCount = 6;
            // p.AmmoBox = am;
            // p.SetAmmo(BulletFactory);
            // p.Force = 10;

            var r = g.AddComponent<Render>();
            r.Symbol = 'S';

            return a;
        }
    }
}

