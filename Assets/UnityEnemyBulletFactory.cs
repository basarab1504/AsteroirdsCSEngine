using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;
using Collider = Asteroids.Collider;

public class UnityEnemyBulletFactory : UnityFactory<Ammo>
{
    public override Ammo UnityCreate()
    {
        var a = Game.Create<Ammo>();
        var c = a.AddComponent<Collider>();
        c.Transform.Scale = new Vector2(0.3f, 0.3f);
        c.CollisionLayer = Layer.BulletEnemy;
        c.OnCollision += a.DestroyComponent;

        a.Transform.Scale = new Vector2(0.3f, 0.3f);
        a.Lifetime = 75;

        var r = a.AddComponent<Render>();
        r.Symbol = 'B';

        return a;
    }
}
