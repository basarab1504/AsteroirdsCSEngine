using UnityEngine;

namespace Asteroids
{
    public class AsteroidFactory : Factory<Asteroid>
    {
        public override Asteroid CreateFrom(GameObject g)
        {
            var a = g.AddComponent<Asteroid>();
            var c = g.AddComponent<Collider>();
            c.Transform.Scale = new Vector2(1, 1);
            c.CollisionLayer = Layer.Asteroid;
            c.OnCollision += g.DestroyObject;

            a.Transform.Scale = new Vector2(1, 1);
            a.Speed = 1;
            a.Direction = new Vector2(0, 1);

            var r = g.AddComponent<Render>();
            r.Symbol = 'A';
            return a;
        }
    }
}

