using UnityEngine;

namespace Asteroids
{
    public class Spawner<T> : Component where T : Component
    {
        public Factory<T> Factory { get; set; }

        public virtual void Spawn()
        {
            var spawned = Factory.Create(GetPosition());
        }

        private Vector2 GetPosition()
        {
            float x;
            float y;

            var areaSizeX = Transform.Scale.x * 0.5f;
            var areaSizeY = Transform.Scale.y * 0.5f;

            bool XoY = Random.Range(0f, 1f) > 0.5f ? true : false;

            if (XoY)
            {
                x = Random.Range(0f, 1f) > 0.5f ? -areaSizeX : areaSizeX;
                y = Random.Range(-areaSizeY, areaSizeY);
            }
            else
            {
                y = Random.Range(0f, 1f) > 0.5f ? -areaSizeY : areaSizeY;
                x = Random.Range(-areaSizeX, areaSizeX);
            }

            return new Vector2(x, y);
        }
    }

    class CooldownSpawner<T> : Spawner<T> where T : Component
    {
        private float lastSpawnTick;

        public float Cooldown { get; set; }

        public override void Update()
        {
            if (Time.CurrentTime > lastSpawnTick + Cooldown)
            {
                Spawn();
                lastSpawnTick = Time.CurrentTime;
            }
        }
    }
}