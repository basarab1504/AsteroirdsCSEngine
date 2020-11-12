using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Gun : Component
    {
        private List<Pool<Ammo>> ammoBoxes = new List<Pool<Ammo>>();
        public float Force { get; set; }

        public void AddAmmoBox(Pool<Ammo> ammoBox)
        {
            if (!ammoBoxes.Contains(ammoBox))
                ammoBoxes.Add(ammoBox);
        }

        public bool TryShootWithType(int indexOfAmmo)
        {
            if (indexOfAmmo < ammoBoxes.Count)
            {
                Ammo ammo;
                if (ammoBoxes[indexOfAmmo].TryGetPoolable(out ammo))
                {
                    ammo.Shoot(Transform.Direction.normalized * Force);
                    return true;
                }
            }
            return false;
        }
    }
}