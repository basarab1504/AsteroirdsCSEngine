using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;
using Collider = Asteroids.Collider;
using Vector3 = Asteroids.Vector3;

public class UnityShipFactory : UnityFactory<Ship>
{
    [SerializeField]
    private UnityAmmoFactory factory;

    public override Ship UnityCreate()
    {
        var a = Game.Create<Ship>();
        var c = a.AddComponent<Collider>();
        c.Transform.Scale = new Vector3(1, 1, 0);
        c.CollisionLayer = Layer.Player;
        c.OnCollision += a.Destroy;

        a.Transform.Scale = new Vector3(1, 1, 0);
        a.Speed = 1;
        a.Direction = new Vector3(1, 0, 0);

        var p = a.AddComponent<Gun>();
        var am = p.AddComponent<Pool<Ammo>>();
        p.BulletCount = 3;
        p.AmmoBox = am;
        p.SetAmmo(factory);
        p.Force = 6;

        var r = a.AddComponent<Render>();
        r.Symbol = 'S';

        return a;
    }
}
