using UnityEngine;
using Asteroids;
using Collider = Asteroids.Collider;

public class UnityEnemyShipFactory : UnityFactory<Ship>
{
    [SerializeField]
    private UnityAmmoFactory factory;

    public override Ship UnityCreate()
    {
        var a = Game.Create<EnemyShip>();
        a.VisibilityRadius = 100;
        a.VisibilityAngle = 15;
        a.KeepDistance = 3;
        a.RotationSpeed = 5;

        // var t = a.AddComponent<Thruster>();
        // t.LinearDrag = 0.9f;

        var c = a.AddComponent<Collider>();
        c.Transform.Scale = new Vector2(1, 1);
        c.CollisionLayer = Layer.EnemyShip;
        c.OnCollision += a.DestroyComponent;

        a.Transform.Scale = new Vector2(0.5f, 1);
        a.Speed = 1f;
        a.Direction = new Vector2(1, 0);

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
