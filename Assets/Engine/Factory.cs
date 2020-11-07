using UnityEngine;

namespace Asteroids
{
    public interface IFactory<T>
    {
        T Create();
    }
}