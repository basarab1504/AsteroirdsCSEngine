﻿using UnityEngine;

namespace Asteroids
{
    public class PlayerLaserAmmoFactory : Factory<Ammo>
    {
        protected override Ammo CreateFrom(GameObject g)
        {
            var a = g.AddComponent<Ammo>();
            var c = g.AddComponent<Collider>();
            c.Transform.Scale = new Vector2(0.2f, 0.2f);
            c.CollisionLayer = Layer.BulletPlayer;

            a.Transform.Scale = new Vector2(0.2f, 0.2f);
            a.Lifetime = 100;

            return a;
        }
    }
}
