using UnityEngine;

namespace Asteroids
{
    public class PlayerBulletFactory : Factory<Ammo>
    {
        public override Ammo CreateFrom(GameObject g)
        {
            var a = g.AddComponent<Ammo>();

            var c = g.AddComponent<Collider>();
            c.Transform.Scale = new Vector2(0.4f, 0.4f);
            c.CollisionLayer = Layer.BulletPlayer;
            c.Collision += () => g.SetActive(false);

            a.Transform.Scale = new Vector2(0.4f, 0.4f);
            a.Lifetime = 50;

            return a;
        }
    }
}
