﻿using UnityEngine;

namespace Asteroids
{
    public class EnemyBulletFactory : Factory<Ammo>
    {
        public override Ammo CreateFrom(GameObject g)
        {
            var a = g.AddComponent<Ammo>();

            var c = g.AddComponent<Collider>();
            c.Transform.Scale = new Vector2(0.4f, 0.4f);
            c.CollisionLayer = Layer.BulletEnemy;
            c.OnCollision += () => g.SetActive(false);

            a.Transform.Scale = new Vector2(0.4f, 0.4f);
            a.Lifetime = 50;

            return a;
        }
    }

}
