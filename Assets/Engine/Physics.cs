using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids
{
    class Physics
    {
        public static Dictionary<Layer, List<Layer>> LayerSettings { get; set; }
        private static HashSet<EngineObject> objects;
        private static IEnumerable<Collider> ActiveColliders => objects.OfType<Collider>().Where(x => x.Active && !x.Destroyed);

        public Physics(HashSet<EngineObject> objects)
        {
            LayerSettings = new Dictionary<Layer, List<Layer>>();
            Physics.objects = objects;
        }

        public void CheckCollisions()
        {
            List<Collider> toCheck = new List<Collider>(objects.OfType<Collider>());

            for (int i = 0; i < toCheck.Count; i++)
            {
                Collider collider = toCheck[i];
                if (IsActive(collider) && ShouldProcess(collider))
                {
                    for (int j = 0; j < toCheck.Count; j++)
                    {
                        if (IsActive(toCheck[j]) && LayerSettings[collider.CollisionLayer].Contains(toCheck[j].CollisionLayer))
                        {
                            if (Physics.ShouldCollide(collider.Transform, toCheck[j].Transform))
                            {
                                collider.Process(toCheck[j]);
                                toCheck[j].Process(collider);
                                toCheck.RemoveAt(i);
                                toCheck.RemoveAt(j);
                                i = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private bool ShouldProcess(Collider collider)
        {
            return LayerSettings.ContainsKey(collider.CollisionLayer);
        }

        private bool IsActive(EngineObject engineObject)
        {
            return engineObject.Active && !engineObject.Destroyed;
        }

        public static bool AnyOverlaps(Vector2 point, float radius, Layer layerMask, out Vector2 hit)
        {
            var t = new Transform();
            t.Position = point;
            t.Scale = new Vector2() { x = radius, y = radius };

            hit = new Vector2(0, 0);

            if (LayerSettings.ContainsKey(layerMask))
                foreach (var a in ActiveColliders.Where(x => x.CollisionLayer == layerMask))
                {
                    if (ShouldCollide(t, a.Transform))
                    {
                        hit = a.Transform.Position;
                        return true;
                    }
                }

            return false;
        }

        public static bool ShouldCollide(Transform a, Transform b)
        {
            var dif = b.Position - a.Position;
            var sizeSum = b.Scale * 0.5f + a.Scale * 0.5f;

            if (sizeSum.x >= dif.magnitude || sizeSum.y >= dif.magnitude)
                return true;
            return false;
        }
    }
}