using System.Linq;
using UnityEngine;

namespace Asteroids
{
    public class Transform : Component
    {
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public Vector2 Scale { get; set; }

        // public override void OnCreate()
        // {
        //     // position = new Vector2();
        //     Direction = new Vector2(0, 1);
        //     Scale = new Vector2();
        // }
    }
}