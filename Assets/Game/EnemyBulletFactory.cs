﻿using UnityEngine;

namespace Asteroids
{
    public class EnemyBulletFactory : Factory<Ammo>
    {
        public override Ammo CreateFrom(GameObject g)
        {
            var a = g.AddComponent<Ammo>();
            var c = g.AddComponent<Collider>();
            c.Transform.Scale = new Vector2(0.3f, 0.3f);
            c.CollisionLayer = Layer.BulletEnemy;
            c.OnCollision += g.DestroyObject;

            a.Transform.Scale = new Vector2(0.3f, 0.3f);
            a.Lifetime = 25;

            var r = g.AddComponent<Render>();
            r.Symbol = 'B';

            return a;
        }
    }

}