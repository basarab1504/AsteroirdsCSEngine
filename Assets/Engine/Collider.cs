using System;

namespace Asteroids
{
    public class Collider : GameObject
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