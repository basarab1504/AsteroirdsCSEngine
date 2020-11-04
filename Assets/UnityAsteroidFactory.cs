using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;
using Collider = Asteroids.Collider;
using Vector3 = Asteroids.Vector3;

public class UnityAsteroidFactory : UnityFactory<Asteroid>
{
    public override Asteroid UnityCreate()
    {
        var a = Game.Create<Asteroid>();
        var c = a.AddComponent<Collider>();
        c.Transform.Scale = new Vector3(1, 1, 0);
        c.CollisionLayer = Layer.Asteroid;
        c.OnCollision += a.Destroy;

        a.Transform.Scale = new Vector3(4, 4, 0);
        a.Speed = 1;
        a.Direction = new Vector3(0, 1, 0);

        var r = a.AddComponent<Render>();
        r.Symbol = 'A';
        return a;
    }


}
