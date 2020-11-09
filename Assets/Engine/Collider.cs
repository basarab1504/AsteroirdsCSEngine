using System;

namespace Asteroids
{
    public class Collider : Component
    {
        public event Action Collision;
        public Layer CollisionLayer { get; set; }

        public void Process(Collider other)
        {
            if (Collision != null)
                Collision();
        }
    }
}