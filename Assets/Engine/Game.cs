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

        public static Dictionary<Layer, List<Layer>> LayerSettings { get; set; } = new Dictionary<Layer, List<Layer>>();
        // public static Dictionary<Type, object> Factories { get; set; } = new Dictionary<Type, object>();
        private static List<EngineObject> objects = new List<EngineObject>();
        private static List<EngineObject> ActiveObjects => objects.FindAll(x => x.Active);
        private static List<EngineObject> toAdd = new List<EngineObject>();
        private static List<EngineObject> toStart = new List<EngineObject>();
        private static List<EngineObject> toDestroy = new List<EngineObject>();

        public static T Create<T>() where T : EngineObject
        {
            var created = Activator.CreateInstance<T>();
            toAdd.Add(created);
            created.OnCreate();
            return created;
        }

        // public static T Instantiate<T>(T original, Vector2 pos) where T : Component
        // {
        //     var created = new GameObject();

        //     created.AddComponent<Transform>();

        //     var transform = created.GetComponent<Transform>();
        //     transform.Position = pos;
        //     transform.Scale = new Vector2(1, 1);
        //     transform.Direction = new Vector2(0, 1);

        //     foreach (var a in original.Components)
        //         created.AddComponent<T>();

        //     // toAdd.Add(created);
        //     // created.OnCreate();

        //     // return created.GetComponent<T>();
        // }

        public static void Destroy(EngineObject obj)
        {
            toDestroy.Add(obj);
        }

        public void Init(Vector2 size, int framerate)
        {
            clamper = new Clamper();
            clamper.AreaSize = size;
            Game.framerate = framerate;
        }

        public void Update()
        {
            foreach (var i in toAdd)
            {
                toStart.Add(i);
                i.SetActive(true);
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


            foreach (var u in ActiveObjects)
                u.Update();

            CheckCollisions();

            foreach (var de in toDestroy)
                objects.Remove(de);
            toDestroy.Clear();

            time++;
        }

        public void CheckCollisions()
        {
            //лучше for
            foreach (Collider a in ActiveObjects.OfType<Collider>())
            {
                foreach (Collider b in ActiveObjects.OfType<Collider>().Where(x => x != a))
                {
                    if (LayerSettings.ContainsKey(b.CollisionLayer) && LayerSettings[b.CollisionLayer].Any(x => x == a.CollisionLayer))
                    {
                        if (ShouldCollide(a.Transform, b.Transform))
                        {
                            a.Process(b);
                            b.Process(a);
                        }
                    }
                }
            }
        }

        public static bool AnyOverlaps(Vector2 point, float radius, Layer layerMask, out Vector2 hit)
        {
            var t = new Transform();
            t.Position = point;
            t.Scale = new Vector2() { x = radius, y = radius };

            hit = new Vector2(0, 0);

            if (LayerSettings.ContainsKey(layerMask))
                foreach (Collider a in ActiveObjects.OfType<Collider>().Where(x => x.CollisionLayer == layerMask))
                {
                    if (ShouldCollide(t, a.Transform))
                    {
                        hit = a.Transform.Position;
                        return true;
                    }
                }

            return false;
        }

        public static bool ShouldCollide(Transform a, Transform b)
        {
            var dif = b.Position - a.Position;
            var sizeSum = b.Scale * 0.5f + a.Scale * 0.5f;

            if (sizeSum.x >= dif.magnitude || sizeSum.y >= dif.magnitude)
                return true;
            return false;
        }
    }
}