using System;

namespace Asteroids
{
    public class Collider : Component
    {
        public event Action OnCollision;
        public Layer CollisionLayer { get; set; }
    }
}