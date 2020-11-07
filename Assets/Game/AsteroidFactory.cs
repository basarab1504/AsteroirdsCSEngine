using UnityEngine;

namespace Asteroids
{
    public class AsteroidFactory : Factory<Asteroid>
    {
        public override Asteroid CreateFrom(GameObject gameObject)
        {
            var a = gameObject.AddComponent<Asteroid>();
            var c = gameObject.AddComponent<Collider>();
            c.Transform.Scale = new Vector2(1, 1);
            c.CollisionLayer = Layer.Asteroid;
            c.OnCollision += a.DestroyObject;

            a.Transform.Scale = new Vector2(1, 1);
            a.Speed = 1;
            a.Direction = new Vector2(0, 1);

            var r = gameObject.AddComponent<Render>();
            r.Symbol = 'A';
            return a;
        }
    }
}

