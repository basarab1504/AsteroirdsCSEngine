using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids
{
    class Game
    {
        private static float time;
        private Clamper clamper;
        private static int framerate;

        public static float Time => time;
        public static float DeltaTime => 1f / framerate;

        private static List<Component> objects = new List<Component>();
        private static List<Component> ActiveObjects => objects.FindAll(x => x.Active);
        private static List<Component> toAdd = new List<Component>();
        private static List<Component> toStart = new List<Component>();
        private static List<Component> toDestroy = new List<Component>();

        public static T Create<T>() where T : Component, new()
        {
            var created = new T();
            toAdd.Add(created);
            created.Awake();
            return created;
        }

        public static void Destroy(Component Component)
        {
            toDestroy.Add(Component);
        }

        public void Init(Vector3 size, int framerate)
        {
            clamper = new Clamper();
            clamper.AreaSize = size;
            Game.framerate = framerate;

            // var asteroidSpawner = Create<CooldownSpawner<Asteroid>>();
            // asteroidSpawner.Transform.Scale = clamper.AreaSize;
            // asteroidSpawner.ToSpawnCount = 3;
            // asteroidSpawner.Cooldown = 5;
            // asteroidSpawner.Factory = new AsteroidFactory();

            // var shipSpawner = Game.Create<Spawner<Ship>>();
            // shipSpawner.ToSpawnCount = 1;
            // shipSpawner.Factory = new ShipFactory();
            // shipSpawner.Spawn();
        }

        public void Update()
        {
            foreach (var i in toAdd)
            {
                toStart.Add(i);
            }
            toAdd.Clear();

            foreach (var i in toStart)
            {
                i.Start();
                objects.Add(i);
            }
            toStart.Clear();

            foreach (GameObject go in ActiveObjects.OfType<GameObject>())
                clamper.Clamp(go);

            Collision();

            // Render();

            foreach (var u in ActiveObjects)
                u.Update();

            foreach (var de in toDestroy)
                objects.Remove(de);
            toDestroy.Clear();

            time++;

            //двинуть объекты
            //проверить коллизии
            //отрисовать
        }

        public void Collision()
        {
            foreach (Collider c in ActiveObjects.OfType<Collider>())
            {
                //collision check
            }
        }

        public void Render()
        {
            char[,] matrix = new char[(int)clamper.AreaSize.X, (int)clamper.AreaSize.X];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = '-';
                }
            }

            int centerX = (int)Math.Ceiling(clamper.AreaSize.X * 0.5f) - 1;
            int centerY = (int)Math.Ceiling(clamper.AreaSize.Y * 0.5f) - 1;

            foreach (Render r in ActiveObjects.OfType<Render>())
            {
                int x = centerX + (int)Math.Ceiling(r.Parent.GetComponent<Transform>().Position.X * 0.5f);
                int y = centerY + (int)Math.Ceiling(r.Parent.GetComponent<Transform>().Position.Y * 0.5f);
                matrix[y, x] = r.Symbol;
                Console.WriteLine(r.Symbol + " G" + r.Parent.GetComponent<Transform>().Position.X + " " + r.Parent.GetComponent<Transform>().Position.Y + " | " + "S" + x + " " + y);
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("=========");
        }
    }
}