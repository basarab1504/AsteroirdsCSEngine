﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;
using Collider = Asteroids.Collider;
using GameObject = Asteroids.GameObject;

public class UnityAsteroidFactory : UnityFactory<Asteroid>
{
    public override Asteroid UnityCreate()
    {
        var g = Game.Create<GameObject>();

        var a = g.AddComponent<Asteroid>();
        var c = g.AddComponent<Collider>();
        c.Transform.Scale = new Vector2(1, 1);
        c.CollisionLayer = Layer.Asteroid;
        c.OnCollision += a.DestroyObject;

        a.Transform.Scale = new Vector2(1, 1);
        a.Speed = 1;
        a.Direction = new Vector2(0, 1);

        var r = g.AddComponent<Render>();
        r.Symbol = 'A';
        return a;
    }


}
