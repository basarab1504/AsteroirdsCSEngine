using System;

namespace Asteroids
{
    public class Spawner<T> : GameObject where T : GameObject
    {
        public IFactory<T> Factory { get; set; }

        public virtual void Spawn()
        {
            var spawned = Factory.Create();
            spawned.Transform.Position = GetPosition();
        }

        private Vector3 GetPosition()
        {
            float x;
            float y;

            var areaSizeX = Transform.Scale.X * 0.5f;
            var areaSizeY = Transform.Scale.Y * 0.5f;

            var rnd = new Random();

            bool XoY = rnd.NextDouble() > 0.5f ? true : false;

            if (XoY)
            {
                x = rnd.NextDouble() > 0.5f ? -areaSizeX : areaSizeX;
                y = (float)rnd.NextDouble() * (areaSizeY - (-areaSizeY)) + (-areaSizeY);
            }
            else
            {
                y = rnd.NextDouble() > 0.5f ? -areaSizeY : areaSizeY;
                x = (float)rnd.NextDouble() * (areaSizeY - (-areaSizeX)) + (-areaSizeX);
            }

            return new Vector3(x, y, 0);
        }
    }

    class CooldownSpawner<T> : Spawner<T> where T : GameObject
    {
        private float lastSpawnTick;

        public float Cooldown { get; set; }

        public override void Update()
        {
            if (Game.Time > lastSpawnTick + Cooldown)
            {
                Spawn();
                lastSpawnTick = Game.Time;
            }
        }
    }
}