using System;
using UnityEngine;

namespace Asteroids
{
    public class Ammo : GameObject, IPoolable
    {
        private Vector2 direction;
        private float actualLifetime;
        public float Lifetime { get; set; }

        public override void Start()
        {
            base.Start();
            actualLifetime = Lifetime;
            SetActive(false);
        }

        public void Shoot(Vector2 force)
        {
            this.direction = force;
            // this.speed = force;
        }

        public override void Update()
        {
            actualLifetime--;
            if (actualLifetime <= 0)
                SetActive(false);
            Transform.Position += direction * Game.DeltaTime;
        }

        public bool InUse()
        {
            return Active && actualLifetime > 0;
        }

        public void Reset()
        {
            actualLifetime = Lifetime;
            SetActive(true);
        }
    }
}