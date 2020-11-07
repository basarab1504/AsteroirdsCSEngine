using UnityEngine;

namespace Asteroids
{
    public class Asteroid : Component
    {
        public Vector3 Direction { get; set; }
        public float Speed { get; set; }

        public override void Start()
        {
            base.Start();
            PushRandom();
        }

        public override void Update()
        {
            Parent.Move(Direction * Speed * Game.DeltaTime);
        }

        private void PushRandom()
        {
            var x = Random.Range(0, 1f) > 0.5f ? -1f : 1f;
            var y = Random.Range(0, 1) > 0.5f ? -1f : 1f;
            Direction = new Vector3(x, y, 0);
        }
    }
}