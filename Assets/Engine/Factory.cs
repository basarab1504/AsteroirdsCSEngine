using UnityEngine;

namespace Asteroids
{
    public interface IFactory<T>
    {
        T Create();
    }

    // public class AmmoFactory : IFactory<Ammo>
    // {
    //     public Ammo Create()
    //     {
    //         var a = Game.Create<Ammo>();
    //         var c = a.AddComponent<Collider>();
    //         c.CollisionLayer = Layer.Bullet;
    //         c.OnCollision += a.Destroy;

    //         a.Transform.Scale = new Vector2(1, 1);
    //         a.Lifetime = 3;
    //         var r = a.AddComponent<Render>();
    //         r.Symbol = 'B';

    //         return a;
    //     }
    // }

    // public class ShipFactory : IFactory<Ship>
    // {
    //     public Ship Create()
    //     {
    //         var a = Game.Create<Ship>();
    //         var c = a.AddComponent<Collider>();
    //         c.CollisionLayer = Layer.Player;
    //         c.OnCollision += a.Destroy;

    //         a.Transform.Scale = new Vector2(2, 2);
    //         a.Speed = 1;
    //         a.Direction = new Vector2(1, 0);

    //         var am = a.AddComponent<Pool<Ammo>>();
    //         am.Factory = new AmmoFactory();
    //         am.RebuildPool(5);

    //         var p = a.AddComponent<Gun>();
    //         p.AmmoBox = am;
    //         p.Force = 1;


    //         var r = a.AddComponent<Render>();
    //         r.Symbol = 'S';

    //         return a;
    //     }
    // }

    // public class AsteroidFactory : IFactory<Asteroid>
    // {
    //     public Asteroid Create()
    //     {
    //         var a = Game.Create<Asteroid>();
    //         var c = a.AddComponent<Collider>();
    //         c.CollisionLayer = Layer.Asteroid;
    //         c.OnCollision += a.Destroy;

    //         a.Transform.Scale = new Vector2(4, 4);
    //         a.Speed = 1;
    //         a.Direction = new Vector2(0, 1);

    //         var r = a.AddComponent<Render>();
    //         r.Symbol = 'A';
    //         return a;
    //     }
    // }
}