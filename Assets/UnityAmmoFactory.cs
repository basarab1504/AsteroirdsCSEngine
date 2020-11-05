using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;
using Collider = Asteroids.Collider;

public class UnityAmmoFactory : UnityFactory<Ammo>
{
    public override Ammo UnityCreate()
    {
        var a = Game.Create<Ammo>();
        var c = a.AddComponent<Collider>();
        c.Transform.Scale = new Vector2(0.4f, 0.4f);
        c.CollisionLayer = Layer.Bullet;
        c.OnCollision += a.Destroy;

        a.Transform.Scale = new Vector2(0.4f, 0.4f);
        a.Lifetime = 100;
        var r = a.AddComponent<Render>();
        r.Symbol = 'B';

        return a;
    }
}