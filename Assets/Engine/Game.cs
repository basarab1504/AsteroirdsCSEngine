using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids
{
    class Game
    {
        public event Action GameOver;
        public event Action GameStarted;
        public event Action ScoreChanged;

        private Clamper clamper;
        private Time time;
        private Physics physics;
        private float score;

        public float Score => score;

        private List<EngineObject> objects = new List<EngineObject>();
        private static List<EngineObject> toAdd = new List<EngineObject>();
        private List<EngineObject> toStart = new List<EngineObject>();
        private List<EngineObject> ActiveObjects => objects.FindAll(x => x.Active && !x.Destroyed);

        // public void OnScoreUp()
        // {
        //     score++;
        //     if (ScoreChanged != null)
        //         ScoreChanged();
        // }

        // public void OnGameOver()
        // {
        //     if (GameOver != null)
        //         GameOver();
        // }

        public static T Create<T>() where T : EngineObject
        {
            var created = Activator.CreateInstance<T>();
            toAdd.Add(created);
            created.OnCreate();
            return created;
        }

        public void Init(Vector2 size, int framerate)
        {
            clamper = new Clamper();
            clamper.AreaSize = size;
            time = new Time(framerate);
            physics = new Physics(objects);

            if (GameStarted != null)
                GameStarted();
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

            physics.CheckCollisions();

            objects.RemoveAll(x => x.Destroyed);

            time.Update();
        }
    }
}