using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Pool<T> : Component where T : Component, IPoolable<T>
    {
        private T[] pols;
        private LinkedList<T> poolables;
        public Factory<T> Factory { get; set; }

        public void RebuildPool(int size)
        {
            if (pols != null)
                foreach (var p in pols)
                    p.Parent.DestroyObject();

            pols = new T[size];
            poolables = new LinkedList<T>();

            for (int i = 0; i < size; i++)
            {
                var created = Factory.Create(Transform.Position);
                created.BecameUnusable += x => poolables.AddLast(x);
                pols[i] = created;
                poolables.AddLast(created);
            }
        }

        public bool TryGetPoolable(out T poolable)
        {
            poolable = default(T);

            if (poolables.Count == 0)
                return false;

            poolable = poolables.First.Value;

            poolable.Transform.Position = Transform.Position;
            poolable.Reset();
            poolable.SetActive(true);
            poolables.RemoveFirst();

            return true;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            if (poolables.Count != 0)
                foreach (var p in poolables)
                    p.Parent.DestroyObject();
        }
    }
}