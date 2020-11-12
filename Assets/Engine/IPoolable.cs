using System;

namespace Asteroids
{
    public interface IPoolable<T>
    {
        GameEvent<T> BecameUnusable { get; }
        bool InUse();
        void Reset();
    }
}