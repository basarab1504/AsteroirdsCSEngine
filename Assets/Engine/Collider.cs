using System;

namespace Asteroids
{
    public class Collider : Component
    {
        public event Action OnCollision;
        public Layer CollisionLayer { get; set; }

        public void Process(Collider other)
        {
            if (OnCollision != null)
                OnCollision();
        }
    }
}