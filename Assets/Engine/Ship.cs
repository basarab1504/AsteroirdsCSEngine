using System;
using System.Collections.Generic;

namespace Asteroids
{
    public class Ship : GameObject
    {
        public Gun Gun { get; set; }
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
        }

        public override void Update()
        {
            // if (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.W))
            //     Direction = new Vector3(0, 1, 0);
            // else if (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.W))
            //     Direction = new Vector3(0, -1, 0);
            //сделать ввод с клавы
            if (new Random().NextDouble() > 0.99f)
                Gun.Shoot();

            Transform.Position += Direction * Speed * Game.DeltaTime;
        }
    }
}