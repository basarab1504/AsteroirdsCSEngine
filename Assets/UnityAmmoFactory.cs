using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;
using Collider = Asteroids.Collider;
using Vector3 = Asteroids.Vector3;

public class UnityAmmoFactory : UnityFactory<Ammo>
{
    public override Ammo UnityCreate()
    {
        var a = Game.Create<Ammo>();
        var c = a.AddComponent<Collider>();
        c.CollisionLayer = Layer.Bullet;
        c.OnCollision += a.Destroy;

        a.Transform.Scale = new Vector3(1, 1, 0);
        a.Lifetime = 100;
        var r = a.AddComponent<Render>();
        r.Symbol = 'B';

        return a;
    }
}