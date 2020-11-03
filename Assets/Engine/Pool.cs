using System;
using System.Collections.Generic;

namespace Asteroids
{
    public class Pool<T> : GameObject where T : IPoolable
    {
        private List<T> poolables = new List<T>();

        public IFactory<T> Factory { get; set; }

        public void RebuildPool(int size)
        {
            poolables = new List<T>(size);
            for (; size > 0; size--)
            {
                var created = Factory.Create();
                // created.Reset();
                poolables.Add(Factory.Create());
            }
        }

        public bool TryGetPoolable(out T poolable)
        {
            poolable = default(T);

            foreach (var p in poolables)
                if (!p.InUse())
                {
                    p.Reset();
                    poolable = p;
                    return true;
                }

            return false;
        }
    }
}