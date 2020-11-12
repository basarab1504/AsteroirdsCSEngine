using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Pool<T> : Component where T : Component, IPoolable<T>
    {
        private List<T> poolObjects;
        private Queue<T> free;
        public Factory<T> Factory { get; set; }
        public int BaseSize { get; set; }
        public bool FixedSize { get; set; }

        public override void Start()
        {
            base.Start();
            poolObjects = new List<T>();
            free = new Queue<T>();

            for (int i = 0; i < BaseSize; i++)
                CreatePoolable();
        }

        public bool TryGetPoolable(out T poolable)
        {
            poolable = default(T);

            if (free.Count == 0)
            {
                if (FixedSize)
                    return false;
                else
                    CreatePoolable();
            }

            poolable = free.Dequeue();

            poolable.Transform.Position = Transform.Position;
            poolable.Reset();
            poolable.SetActive(true);

            return true;
        }

        private void OnPoolableBecameUnuable(T poolable)
        {
            free.Enqueue(poolable);
        }

        private void CreatePoolable()
        {
            var created = Factory.Create(Transform.Position);
            created.BecameUnusable.AddListener(OnPoolableBecameUnuable);
            poolObjects.Add(created);
            free.Enqueue(created);
        }
    }
}