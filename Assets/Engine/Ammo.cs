using System;

namespace Asteroids
{
    public class Ammo : GameObject, IPoolable
    {
        private float speed = 1;
        private Vector3 direction;
        public float Lifetime { get; set; }

        public override void Start()
        {
            base.Start();
            SetActive(false);
        }

        public void Shoot(Vector3 force)
        {
            this.direction = force;
            // this.speed = force;
        }

        public override void Update()
        {
            Lifetime--;
            Transform.Position += direction * speed;
        }

        public bool InUse()
        {
            return Active && Lifetime > 0;
        }

        public void Reset()
        {
            // Transform.Position = parent.GetComponent<Transform>().Position;
            SetActive(true);
        }
    }
}