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

        public T Create(Vector2 pos)
        {
            var go = Game.Create<GameObject>();

            var transform = go.AddComponent<Transform>();
            transform.Position = pos;
            transform.Scale = new Vector2(1, 1);
            transform.Direction = new Vector2(0, 1);

            var created = CreateFrom(go);

            if (Spawned != null)
                Spawned(created);
                
            return created;
        }

        protected abstract T CreateFrom(GameObject gameObject);
    }
}