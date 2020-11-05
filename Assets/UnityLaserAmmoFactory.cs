﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;
using Collider = Asteroids.Collider;

public class UnityLaserAmmoFactory : UnityFactory<Ammo>
{
    public override Ammo UnityCreate()
    {
        var a = Game.Create<Ammo>();
        var c = a.AddComponent<Collider>();
        c.Transform.Scale = new Vector3(0.2f, 0.2f, 0);
        c.CollisionLayer = Layer.BulletPlayer;

        a.Transform.Scale = new Vector3(0.2f, 0.2f, 0);
        a.Lifetime = 100;
        var r = a.AddComponent<Render>();
        r.Symbol = 'B';

        return a;
    }
}