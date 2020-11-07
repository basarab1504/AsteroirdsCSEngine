using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;
using Collider = Asteroids.Collider;
using GameObject = Asteroids.GameObject;

public class UnityLaserAmmoFactory : UnityFactory<Ammo>
{
    public override Ammo UnityCreate()
    {
        var g = Game.Create<GameObject>();

        var a = g.AddComponent<Ammo>();
        var c = g.AddComponent<Collider>();
        c.Transform.Scale = new Vector3(0.2f, 0.2f, 0);
        c.CollisionLayer = Layer.BulletPlayer;

        a.Transform.Scale = new Vector3(0.2f, 0.2f, 0);
        a.Lifetime = 100;
        var r = g.AddComponent<Render>();
        r.Symbol = 'B';

        return a;
    }
}