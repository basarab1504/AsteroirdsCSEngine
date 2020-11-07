using UnityEngine;

namespace Asteroids
{
    public class AmmoFactory : Factory<Ammo>
    {
        public override Ammo CreateFrom(GameObject g)
        {
            var a = g.AddComponent<Ammo>();

            var c = g.AddComponent<Collider>();
            c.Transform.Scale = new Vector2(0.4f, 0.4f);
            c.CollisionLayer = Layer.BulletPlayer;
            c.OnCollision += a.DestroyObject;

            a.Transform.Scale = new Vector2(0.4f, 0.4f);
            a.Lifetime = 50;

            var r = g.AddComponent<Render>();
            r.Symbol = 'B';

            return a;
        }
    }
}
