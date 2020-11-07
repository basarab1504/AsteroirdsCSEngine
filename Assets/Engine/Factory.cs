using UnityEngine;
using System;

namespace Asteroids
{
    // public interface IFactory<in T>
    // {
    //     T Create();
    // }

    public abstract class Factory<T> where T : Component
    {
        public event Action<T> Spawned;

        public T Create()
        {
            var go = Game.Create<GameObject>();

            var transform = go.AddComponent<Transform>();
            transform.Position = new Vector2(0, 0);
            transform.Scale = new Vector2(1, 1);
            transform.Direction = new Vector2(0, 1);

            var created = CreateFrom(go);

            if (Spawned != null)
                Spawned(created);
                
            return created;
        }

        public abstract T CreateFrom(GameObject gameObject);
    }
}