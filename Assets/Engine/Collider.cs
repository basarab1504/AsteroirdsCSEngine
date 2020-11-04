using System;

namespace Asteroids
{
    public class Collider : GameObject
    {
        public event Action OnCollision;
        public Layer CollisionLayer { get; set; }

        public void Process(Collider other)
        {
            var dif = other.Transform.Position - Transform.Position;
            var sizeSum = other.Transform.Scale * 0.5f + Transform.Scale * 0.5f;

            if (Vector3.Magnitude(sizeSum) >= Vector3.Magnitude(dif))
                OnCollision();
        }
    }
}