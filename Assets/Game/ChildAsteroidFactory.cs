using UnityEngine;

namespace Asteroids
{
    public class ChildAsteroidFactory : Factory<Asteroid>
    {
        protected override Asteroid CreateFrom(GameObject g)
        {
            var a = g.AddComponent<Asteroid>();

            var c = g.AddComponent<Collider>();
            c.Transform.Scale = new Vector2(0.5f, 0.5f);
            c.CollisionLayer = Layer.Asteroid;
            c.Collision += g.DestroyObject;

            g.AddComponent<Scorable>().Score = 2;

            a.Speed = 2;
            a.Direction = new Vector2(0, 1);

            return a;
        }
    }
}