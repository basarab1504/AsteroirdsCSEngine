using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Pool<T> : Component where T : Component, IPoolable
    {
        private List<T> poolables = new List<T>();

        public Factory<T> Factory { get; set; }

        public void RebuildPool(int size)
        {
            poolables = new List<T>(size);
            for (; size > 0; size--)
            {
                var created = Factory.Create(Transform.Position);
                poolables.Add(created);
            }
        }

        public bool TryGetPoolable(out T poolable)
        {
            poolable = default(T);

            foreach (var p in poolables)
                if (!p.InUse())
                {
                    p.Transform.Position = Transform.Position;
                    p.Reset();
                    poolable = p;
                    return true;
                }

            return false;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            foreach(var p in poolables)
                p.Parent.DestroyObject();

            poolables.Clear();
        }
    }
}