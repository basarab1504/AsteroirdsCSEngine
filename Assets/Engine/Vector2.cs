// using System;
using UnityEngine;

namespace Asteroids
{
    public static class Vector2Extensions
    {
        public static float[,] RotationMatrix(float radians)
        {
            float[,] matrix = new float[2, 2];
            matrix[0, 0] = Mathf.Cos(radians);
            matrix[0, 1] = -Mathf.Sin(radians);
            matrix[1, 0] = Mathf.Sin(radians);
            matrix[1, 1] = Mathf.Cos(radians);
            return matrix;
        }

        public static Vector2 Rotate(this Vector2 v, float angle)
        {
            return RotateRadians(v, angle * Mathf.Deg2Rad);
        }

        public static Vector2 RotateRadians(this Vector2 v, float radians)
        {
            var rotaionMatrix = RotationMatrix(radians);
            return new Vector2(v.x * rotaionMatrix[0, 0] + v.y * rotaionMatrix[0, 1], v.x * rotaionMatrix[1, 0] + v.y * rotaionMatrix[1, 1]);
        }
    }
}