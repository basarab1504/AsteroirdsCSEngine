using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids
{
    class Physics
    {
        public static Dictionary<Layer, List<Layer>> LayerSettings { get; set; }
        private static List<EngineObject> objects;
        private static IEnumerable<Collider> ActiveColliders => objects.OfType<Collider>().Where(x => x.Active && !x.Destroyed);

        public Physics(List<EngineObject> objects)
        {
            LayerSettings = new Dictionary<Layer, List<Layer>>();
            Physics.objects = objects;
        }

        public void CheckCollisions()
        {
            //лучше for
            foreach (var a in ActiveColliders)
            {
                foreach (var b in ActiveColliders.Where(x => x != a))
                {
                    if (LayerSettings.ContainsKey(b.CollisionLayer) && LayerSettings[b.CollisionLayer].Any(x => x == a.CollisionLayer) && Physics.ShouldCollide(a.Transform, b.Transform))
                    {
                        a.Process(b);
                        b.Process(a);
                    }
                }
            }
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