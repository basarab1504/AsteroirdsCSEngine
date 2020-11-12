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

        public GameEvent GraphicsChanged { get; } = new GameEvent();
        public GameEvent GameOver { get; } = new GameEvent();
        public GameEvent GameStarted { get; } = new GameEvent();
        public GameEvent ScoreChanged { get; } = new GameEvent();

        private Clamper clamper;
        private Time time;
        private Physics physics;
        private float score;

        public float Score => score;

        private static HashSet<BaseGameEvent> events = new HashSet<BaseGameEvent>();
        private static HashSet<EngineObject> toAdd = new HashSet<EngineObject>();
        private HashSet<EngineObject> objects = new HashSet<EngineObject>();
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
            events.Clear();
            toAdd.Clear();
            clamper = new Clamper();
            clamper.AreaSize = size;
            time = new Time(framerate);
            physics = new Physics(objects);
            OnGameStarted();
        }

        public static void RegisterEvent(BaseGameEvent gameEvent)
        {
            events.Add(gameEvent);
        }

        public void ChangeMode()
        {
            if (mode == Graphics.TwoDimension)
                mode = Graphics.ThreeDimension;
            else
                mode = Graphics.TwoDimension;

            if (GraphicsChanged != null)
                GraphicsChanged.Raise();
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
            ScoreChanged.Raise();
        }

        private void OnGameStarted()
        {
            if (GameStarted != null)
                GameStarted.Raise();
        }

        private void OnGameOver()
        {
            if (GameOver != null)
                GameOver.Raise();

            foreach (var o in objects)
                o.DestroyObject();

            foreach (var e in events)
                e.RemoveAllListeners();

            toAdd.Clear();
            objects.Clear();
            events.Clear();
            toStart.Clear();
        }
    }
}