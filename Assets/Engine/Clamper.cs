using System;
using UnityEngine;

namespace Asteroids
{
    public class Clamper
    {
        private Vector2 AreaBorders => AreaSize * 0.5f;
        public Vector2 AreaSize { get; set; }

        public void Clamp(GameObject go)
        {
            // Console.WriteLine("X:" + AreaBorders.X + "Y:" + AreaBorders.Y);

            float x = go.Transform.Position.x;
            float y = go.Transform.Position.y;

            if (x > AreaBorders.x || x < -AreaBorders.x || y > AreaBorders.y || y < -AreaBorders.y)
            {
                Vector2 pos;

                if (Mathf.Abs(x) >= Mathf.Abs(y))
                    pos = new Vector2(-x, y);
                else
                    pos = new Vector2(x, -y);

                go.Transform.Position = pos;
            }
        }
    }
}