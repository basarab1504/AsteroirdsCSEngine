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

            if (free.Count == 1)
                CreatePoolable();

            poolable = free.Dequeue();

            poolable.Transform.Position = Transform.Position;
            poolable.Reset();
            poolable.SetActive(true);

            return true;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        private void CreatePoolable()
        {
            var created = Factory.Create(Transform.Position);
            created.BecameUnusable += x => free.Enqueue(x);
            poolObjects.Add(created);
            free.Enqueue(created);
        }
    }
}