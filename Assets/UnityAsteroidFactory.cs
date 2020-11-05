using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;
using Collider = Asteroids.Collider;

public class UnityAsteroidFactory : UnityFactory<Asteroid>
{
    public override Asteroid UnityCreate()
    {
        var a = Game.Create<Asteroid>();
        var c = a.AddComponent<Collider>();
        c.Transform.Scale = new Vector2(1, 1);
        c.CollisionLayer = Layer.Asteroid;
        c.OnCollision += a.DestroyComponent;

        a.Transform.Scale = new Vector2(1, 1);
        a.Speed = 1;
        a.Direction = new Vector2(0, 1);

        var r = a.AddComponent<Render>();
        r.Symbol = 'A';
        return a;
    }


}
