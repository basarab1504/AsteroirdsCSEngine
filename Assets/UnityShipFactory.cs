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
        c.CollisionLayer = Layer.Player;
        c.OnCollision += a.Destroy;

        a.Transform.Scale = new Vector3(2, 2, 0);
        a.Speed = 1;
        a.Direction = new Vector3(1, 0, 0);

        var am = a.AddComponent<Pool<Ammo>>();
        am.Factory = factory;
        am.RebuildPool(3);

        var p = a.AddComponent<Gun>();
        p.AmmoBox = am;
        p.Force = 3;

        var r = a.AddComponent<Render>();
        r.Symbol = 'S';

        return a;
    }
}
