using UnityEngine;

namespace Asteroids
{
    public class Gun : Component
    {
        public Pool<Ammo> AmmoBox { get; set; }
        public float Force { get; set; }
        public int BulletCount { get; set; }

        public override void Start()
        {
            base.Start();
            AmmoBox = GetComponent<Pool<Ammo>>();
        }

        public void SetAmmo(Factory<Ammo> factory)
        {
            AmmoBox.Factory = factory;
            AmmoBox.RebuildPool(BulletCount);
        }

        public void Shoot()
        {
            Ammo ammo;
            if (AmmoBox.TryGetPoolable(out ammo))
            {
                ammo.Transform.Position = Transform.Position;
                ammo.Shoot(Transform.Direction.normalized * Force);
            }
        }
    }
}