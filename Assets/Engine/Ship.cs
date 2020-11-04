using System;
using System.Collections.Generic;

namespace Asteroids
{
    public class Ship : GameObject
    {
        private Gun Gun { get; set; }
        public float Speed { get; set; }
        public Vector3 Direction { get; set; }

        // public void AddGun(Gun gun)
        // {
        //     if (!guns.Contains(gun))
        //         guns.AddLast(gun);
        // }

        // public void RemoveGun(Gun gun)
        // {
        //     if (guns.Contains(gun))
        //         guns.AddLast(gun);
        // }

        // public void SwitchGun()
        // {
        //     guns
        // }

        public override void Start()
        {
            base.Start();
            Gun = GetComponent<Gun>();
            // Transform.Rotation = Vector3.Rotate(Transform.Rotation, 45);
        }

        public override void Update()
        {
            // if (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.W))
            //     Direction = new Vector3(0, 1, 0);
            // else if (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.W))
            //     Direction = new Vector3(0, -1, 0);
            //сделать ввод с клавы

            if (new Random().NextDouble() > 0.7f)
                    Gun.Shoot(Direction);
                // Direction = Vector3.Rotate(Direction, 45);

            Transform.Position += Direction * Speed * Game.DeltaTime;
            // Transform.Position += Direction * Speed * Game.DeltaTime;
        }
    }
}