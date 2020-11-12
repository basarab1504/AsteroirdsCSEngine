using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerShipFactory : Factory<Ship>
    {
        public Factory<Ammo> BulletFactory { get; set; }
        public Factory<Ammo> LaserAmmoFactory { get; set; }

        protected override Ship CreateFrom(GameObject g)
        {
            var a = g.AddComponent<Ship>();
            a.RotationSpeed = 5;

            var t = g.AddComponent<Thruster>();
            t.LinearDrag = 0.9f;

            g.AddComponent<Player>();

            var c = g.AddComponent<Collider>();
            c.Transform.Scale = new Vector2(1, 1);
            c.CollisionLayer = Layer.Player;
            // c.Collision += g.DestroyObject;

            a.Transform.Scale = new Vector2(0.5f, 1);
            a.Speed = 0.02f;

            var p = g.AddComponent<Gun>();

            var am = Game.Create<Pool<Ammo>>();
            am.BaseSize = 6;
            am.Factory = BulletFactory;
            am.Parent = g;

            var lm = Game.Create<Pool<Ammo>>();
            lm.BaseSize = 2;
            lm.FixedSize = true;
            lm.Factory = LaserAmmoFactory;
            lm.Parent = g;

            p.AddAmmoBox(am);
            p.AddAmmoBox(lm);

            p.Force = 10;

            a.Commands = new List<Command>()
            {
                new Command(() => Input.GetAxisRaw("Vertical") > 0, () => a.GetComponent<Thruster>().AddForce(a.Transform.Direction.normalized * a.Speed)),
                new Command(() => Input.GetAxisRaw("Horizontal") > 0, () => a.Parent.Rotate(-a.RotationSpeed)),
                new Command(() => Input.GetAxisRaw("Horizontal") < 0, () => a.Parent.Rotate(a.RotationSpeed)),
                new Command(() => Input.GetMouseButtonDown(0), () => a.GetComponent<Gun>().TryShootWithType(0)),
                new Command(() => Input.GetMouseButtonDown(1), () => a.GetComponent<Gun>().TryShootWithType(1)),
            };

            return a;
        }
    }
}

