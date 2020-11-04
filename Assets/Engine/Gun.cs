using System;
using System.Collections.Generic;

namespace Asteroids
{
    public class Gun : GameObject
    {
        public Pool<Ammo> AmmoBox { get; set; }
        public float Force { get; set; }

        public void Shoot(Vector3 direction)
        {
            Ammo ammo;
            if (AmmoBox.TryGetPoolable(out ammo))
            {
                ammo.Transform.Position = Transform.Position;
                ammo.Shoot(direction * Force);
            }
            // if (currentCapacity > 0)
            // {
            //     Console.WriteLine("POS: " + Transform.Position.X + Transform.Position.Y);
            //     var ammo = AmmoBox.Create();
            //     ammo.Shoot(new Vector3(0, 1, 0) * Force); //добавить направление текущее у объекта
            // }
        }
    }
}