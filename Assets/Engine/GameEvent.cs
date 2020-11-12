using System;

namespace Asteroids
{
    public abstract class BaseGameEvent
    {
        public BaseGameEvent()
        {
            Game.RegisterEvent(this);
        }

        public abstract void RemoveAllListeners();
    }

    public class GameEvent : BaseGameEvent
    {
        private event Action gameEvent;

        public void Raise()
        {
            if (gameEvent != null)
                gameEvent();
        }

        public void AddListener(Action action)
        {
            gameEvent += action;
        }

        public void RemoveListener(Action action)
        {
            gameEvent -= action;
        }

        public override void RemoveAllListeners()
        {
            gameEvent = null;
        }
    }

    public class GameEvent<T> : BaseGameEvent
    {
        private event Action<T> gameEvent;

        public void Raise(T arg)
        {
            if (gameEvent != null)
                gameEvent(arg);
        }

        public void AddListener(Action<T> action)
        {
            gameEvent += action;
        }

        public void RemoveListener(Action<T> action)
        {
            gameEvent -= action;
        }

        public override void RemoveAllListeners()
        {
            gameEvent = null;
        }
    }
}