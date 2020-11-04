using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;
using Collider = Asteroids.Collider;
using Vector3 = Asteroids.Vector3;

public class UnityLaserAmmoFactory : UnityFactory<Ammo>
{
    public override Ammo UnityCreate()
    {
        var a = Game.Create<Ammo>();
        var c = a.AddComponent<Collider>();
        c.Transform.Scale = new Vector3(0.2f, 0.2f, 0);
        c.CollisionLayer = Layer.Bullet;

        a.Transform.Scale = new Vector3(0.2f, 0.2f, 0);
        a.Lifetime = 100;
        var r = a.AddComponent<Render>();
        r.Symbol = 'B';

        return a;
    }
}