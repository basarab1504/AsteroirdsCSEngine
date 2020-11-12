using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids
{
    class Game
    {
        private static Graphics mode = Graphics.TwoDimension;
        public static Graphics Mode => mode;

        public static event Action GraphicsChanged;
        public event Action GameOver;
        public event Action GameStarted;
        public event Action ScoreChanged;

        private Clamper clamper;
        private Time time;
        private Physics physics;
        private float score;

        public float Score => score;

        private HashSet<EngineObject> objects = new HashSet<EngineObject>();
        private static HashSet<EngineObject> toAdd = new HashSet<EngineObject>();
        private HashSet<EngineObject> toStart = new HashSet<EngineObject>();

        public static T Create<T>() where T : EngineObject
        {
            var created = Activator.CreateInstance<T>();
            toAdd.Add(created);
            created.OnCreate();
            return created;
        }

        public void Init(Vector2 size, int framerate)
        {
            toAdd.Clear();
            clamper = new Clamper();
            clamper.AreaSize = size;
            time = new Time(framerate);
            physics = new Physics(objects);
            OnGameStarted();
        }

        public void ChangeMode()
        {
            if (mode == Graphics.TwoDimension)
                mode = Graphics.ThreeDimension;
            else
                mode = Graphics.TwoDimension;

            if (GraphicsChanged != null)
                GraphicsChanged();
        }

        public void Update()
        {
            foreach (var s in toAdd.OfType<Scorable>())
                s.Scored += () => OnScoreChanged(s.Score);

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

            foreach (GameObject go in objects.OfType<GameObject>())
                if (IsActive(go))
                    clamper.Clamp(go);

            foreach (var u in objects)
                if (IsActive(u))
                    u.Update();

            physics.CheckCollisions();

            if (objects.OfType<Player>().Any(x => x.Destroyed))
                OnGameOver();

            objects.RemoveWhere(x => x.Destroyed);

            time.Update();
        }

        private bool IsActive(EngineObject obj)
        {
            return obj.Active && !obj.Destroyed;
        }

        private void OnScoreChanged(int toAdd)
        {
            score += toAdd;
            ScoreChanged();
        }

        private void OnGameStarted()
        {
            if (GameStarted != null)
                GameStarted();
        }

        private void OnGameOver()
        {
            if (GameOver != null)
                GameOver();

            foreach (var o in objects)
                o.DestroyObject();
        }
    }
}