using System;

namespace Asteroids
{
    public class Collider : Component
    {
        public GameEvent Collision { get; } = new GameEvent();
        public Layer CollisionLayer { get; set; }

        public void Process(Collider other)
        {
            if (Collision != null)
                Collision.Raise();
        }

        public override void OnDestroy()
        {
            Collision.RemoveAllListeners();
            base.OnDestroy();
        }
    }
}