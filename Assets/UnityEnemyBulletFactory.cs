using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;
using Collider = Asteroids.Collider;
using GameObject = Asteroids.GameObject;

public class UnityEnemyBulletFactory : UnityFactory<Ammo>
{
    public override Ammo UnityCreate()
    {
        var g = Game.Create<GameObject>();

        var a = g.AddComponent<Ammo>();
        var c = g.AddComponent<Collider>();
        c.Transform.Scale = new Vector2(0.3f, 0.3f);
        c.CollisionLayer = Layer.BulletEnemy;
        c.OnCollision += a.DestroyObject;

        a.Transform.Scale = new Vector2(0.3f, 0.3f);
        a.Lifetime = 25;

        var r = g.AddComponent<Render>();
        r.Symbol = 'B';

        return a;
    }
}
