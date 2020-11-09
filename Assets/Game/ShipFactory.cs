using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerShipFactory : Factory<Ship>
    {
        public Factory<Ammo> BulletFactory { get; set; }
        public Factory<Ammo> LaserAmmoFactory { get; set; }

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
            c.Collision += g.DestroyObject;

            a.Transform.Scale = new Vector2(0.5f, 1);
            a.Speed = 0.02f;

            var p = g.AddComponent<Gun>();
            var am = g.AddComponent<Pool<Ammo>>();
            p.BulletCount = 6;
            p.AddAmmoType(BulletFactory);
            p.AddAmmoType(LaserAmmoFactory);
            p.Force = 10;

            a.Commands = new List<Command>()
            {
                new Command(() => Input.GetKey(KeyCode.UpArrow), () => a.GetComponent<Thruster>().AddForce(a.Transform.Direction.normalized * a.Speed)),
                new Command(() => Input.GetKey(KeyCode.RightArrow), () => a.Parent.Rotate(-a.RotationSpeed)),
                new Command(() => Input.GetKey(KeyCode.LeftArrow), () => a.Parent.Rotate(a.RotationSpeed)),
                new Command(() => Input.GetKeyDown(KeyCode.LeftAlt), () => a.GetComponent<Gun>().Shoot()),
                new Command(() => Input.GetKeyDown(KeyCode.Space), () => a.GetComponent<Gun>().NextAmmo()),
            };

            return a;
        }
    }
}

