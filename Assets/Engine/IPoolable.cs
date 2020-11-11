using System;

namespace Asteroids
{
    public interface IPoolable<T>
    {
        event Action<T> BecameUnusable; 
        bool InUse();
        void Reset();
    }
}