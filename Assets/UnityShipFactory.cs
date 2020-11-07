using UnityEngine;
using Asteroids;
using Collider = Asteroids.Collider;
using GameObject = Asteroids.GameObject;

public class UnityShipFactory : UnityFactory<Ship>
{
    [SerializeField]
    private UnityAmmoFactory factory;
    [SerializeField]
    private UnityLaserAmmoFactory laserFactory;

    public override Ship UnityCreate()
    {
        var g = Game.Create<GameObject>();

        var a = g.AddComponent<Ship>();
        a.RotationSpeed = 5;

        var t = g.AddComponent<Thruster>();
        t.LinearDrag = 0.9f;

        var c = g.AddComponent<Collider>();
        c.Transform.Scale = new Vector2(1, 1);
        c.CollisionLayer = Layer.Player;
        c.OnCollision += a.DestroyObject;

        a.Transform.Scale = new Vector2(0.5f, 1);
        a.Speed = 0.02f;

        var p = g.AddComponent<Gun>();
        var am = g.AddComponent<Pool<Ammo>>();
        p.BulletCount = 6;
        p.AmmoBox = am;
        p.SetAmmo(factory);
        p.Force = 10;

        var r = g.AddComponent<Render>();
        r.Symbol = 'S';

        return a;
    }
}
