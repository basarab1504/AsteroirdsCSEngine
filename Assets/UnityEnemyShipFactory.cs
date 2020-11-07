﻿using UnityEngine;
using Asteroids;
using Collider = Asteroids.Collider;
using GameObject = Asteroids.GameObject;

public class UnityEnemyShipFactory : UnityFactory<Ship>
{
    [SerializeField]
    private UnityEnemyBulletFactory factory;

    public override Ship UnityCreate()
    {
        var g = Game.Create<GameObject>();

        var a = g.AddComponent<EnemyShip>();
        a.VisibilityRadius = 100;
        a.VisibilityAngle = 15;
        a.RotationSpeed = 5;

        var c = g.AddComponent<Collider>();
        c.Transform.Scale = new Vector2(1, 1);
        c.CollisionLayer = Layer.EnemyShip;
        c.OnCollision += a.DestroyObject;

        a.Transform.Scale = new Vector2(0.5f, 1);
        a.Speed = 1f;

        var p = g.AddComponent<Gun>();
        var am = p.AddComponent<Pool<Ammo>>();
        p.BulletCount = 3;
        p.AmmoBox = am;
        p.SetAmmo(factory);
        p.Force = 6;

        var r = g.AddComponent<Render>();
        r.Symbol = 'S';

        return a;
    }
}
