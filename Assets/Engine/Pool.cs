using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Pool<T> : Component where T : Component, IPoolable<T>
    {
        private T[] poolables;
        private LinkedList<T> free;
        public Factory<T> Factory { get; set; }

        public void RebuildPool(int size)
        {
            if (poolables != null)
                foreach (var p in poolables)
                    p.Parent.DestroyObject();

            poolables = new T[size];
            free = new LinkedList<T>();

            for (int i = 0; i < size; i++)
            {
                var created = Factory.Create(Transform.Position);
                created.BecameUnusable += x => free.AddLast(x);
                poolables[i] = created;
                free.AddLast(created);
            }
        }

        public bool TryGetPoolable(out T poolable)
        {
            poolable = default(T);

            if (free.Count == 0)
                return false;

            poolable = free.First.Value;

            poolable.Transform.Position = Transform.Position;
            poolable.Reset();
            poolable.SetActive(true);
            free.RemoveFirst();

            return true;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            if (free.Count != 0)
                foreach (var p in free)
                    p.Parent.DestroyObject();
        }
    }
}