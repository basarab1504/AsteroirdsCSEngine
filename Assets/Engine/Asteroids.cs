using UnityEngine;

namespace Asteroids
{
    public class Asteroid : Component
    {
        public Factory<Asteroid> Duplicator { get; set; }
        public int SpawnOnDestoy { get; set; }
        public Vector3 Direction { get; set; }
        public float Speed { get; set; }

        public override void Start()
        {
            base.Start();
            PushRandom();
        }

        public override void Update()
        {
            Parent.Move(Direction * Speed * Time.DeltaTime);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            for (int i = 0; i < SpawnOnDestoy; i++)
                Duplicator.Create(Transform.Position);
        }

        private void PushRandom()
        {
            var x = Random.Range(0, 1f) > 0.5f ? -1f : 1f;
            var y = Random.Range(0, 1f) > 0.5f ? -1f : 1f;
            Direction = new Vector3(x, y, 0);
        }
    }
}