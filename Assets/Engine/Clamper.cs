using System;
using UnityEngine;

namespace Asteroids
{
    public class Clamper
    {
        private Vector3 AreaBorders => AreaSize * 0.5f;
        public Vector3 AreaSize { get; set; }

        public void Clamp(GameObject go)
        {
            // Console.WriteLine("X:" + AreaBorders.X + "Y:" + AreaBorders.Y);

            float x = go.Transform.Position.X;
            float y = go.Transform.Position.Y;

            if (x > AreaBorders.X || x < -AreaBorders.X || y > AreaBorders.Y || y < -AreaBorders.Y)
            {
                Vector3 pos;

                if (Mathf.Abs(x) >= Mathf.Abs(y))
                    pos = new Vector3(-x, y, 0);
                else
                    pos = new Vector3(x, -y, 0);

                go.Transform.Position = pos;
            }
        }
    }
}