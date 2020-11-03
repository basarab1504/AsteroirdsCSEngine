using System;

namespace Asteroids
{
    public class Asteroid : GameObject
    {
        public float Speed { get; set; }
        public Vector3 Direction { get; set; }

        public override void Start()
        {
            base.Start();
            PushRandom();
        }

        public override void Update()
        {
            Transform.Position += Direction * Speed * Game.DeltaTime;
        }

        private void PushRandom()
        {
            Random rnd = new Random();
            var x = rnd.NextDouble() > 0.5f ? -1f : 1f;
            var y = rnd.NextDouble() > 0.5f ? -1f : 1f;
            Direction = new Vector3(x, y, 0);
        }
    }
}