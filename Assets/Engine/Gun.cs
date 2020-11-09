using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Gun : Component
    {
        private List<Factory<Ammo>> ammoTypes = new List<Factory<Ammo>>();
        private int ammoTypeIndex;
        private Pool<Ammo> AmmoBox { get; set; }
        public float Force { get; set; }
        public int BulletCount { get; set; }

        public override void Start()
        {
            base.Start();
            AmmoBox = GetComponent<Pool<Ammo>>();
        }

        public void AddAmmoType(Factory<Ammo> ammoType)
        {
            if (!ammoTypes.Contains(ammoType))
            {
                ammoTypes.Add(ammoType);

                if (ammoTypes.Count == 1)
                    SetAmmo(ammoType);
            }
        }

        private void SetAmmo(Factory<Ammo> ammoType)
        {
            GetComponent<Pool<Ammo>>().Factory = ammoType;
            GetComponent<Pool<Ammo>>().RebuildPool(BulletCount);
        }

        public void NextAmmo()
        {
            ammoTypeIndex++;

            if (ammoTypeIndex >= ammoTypes.Count)
                ammoTypeIndex = 0;

            SetAmmo(ammoTypes[ammoTypeIndex]);
        }

        public void Shoot()
        {
            Ammo ammo;
            if (AmmoBox.TryGetPoolable(out ammo))
            {
                ammo.Shoot(Transform.Direction.normalized * Force);
            }
        }
    }
}