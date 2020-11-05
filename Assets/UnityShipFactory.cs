using UnityEngine;
using Asteroids;
using Collider = Asteroids.Collider;

public class UnityShipFactory : UnityFactory<Ship>
{
    [SerializeField]
    private UnityAmmoFactory factory;
    [SerializeField]
    private UnityLaserAmmoFactory laserFactory;

    public override Ship UnityCreate()
    {
        var a = Game.Create<Ship>();
        a.RotationSpeed = 5;

        var t = a.AddComponent<Thruster>();
        t.LinearDrag = 0.9f;

        var c = a.AddComponent<Collider>();
        c.Transform.Scale = new Vector2(1, 1);
        c.CollisionLayer = Layer.Player;
        c.OnCollision += a.DestroyComponent;

        a.Transform.Scale = new Vector2(0.5f, 1);
        a.Speed = 0.02f;

        var p = a.AddComponent<Gun>();
        var am = p.AddComponent<Pool<Ammo>>();
        p.BulletCount = 3;
        p.AmmoBox = am;
        p.SetAmmo(factory);
        p.Force = 10;

        var r = a.AddComponent<Render>();
        r.Symbol = 'S';

        return a;
    }
}
