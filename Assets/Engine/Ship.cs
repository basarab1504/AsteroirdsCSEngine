using UnityEngine;

namespace Asteroids
{
    public class Ship : GameObject
    {
        public float Speed { get; set; }
        private Gun Gun { get; set; }
        private Thruster Thruster { get; set; }
        public Vector2 Direction { get; set; }

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
            Thruster = GetComponent<Thruster>();

            // Transform.Rotation = Vector3.Rotate(Transform.Rotation, 45);
        }

        public override void Update()
        {
            // if (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.W))
            //     Direction = new Vector3(0, 1, 0);
            // else if (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.W))
            //     Direction = new Vector3(0, -1, 0);
            //сделать ввод с клавы

            // if (new Random().NextDouble() > 0.99f)
            // {
            //     Transform.Rotation = Vector3.Rotate(Transform.Rotation, 45);
            //     Thruster.AddForce(Transform.Rotation * Speed);
            // }

            //     Gun.Shoot(Direction);
            // Rotate(45);


            // Move(Direction * Speed * Game.DeltaTime);
            // Transform.Position += Direction * Speed * Game.DeltaTime;
        }
    }
}