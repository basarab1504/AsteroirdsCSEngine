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

// namespace Asteroids
// {
//     public struct Vector2
//     {
//         private const double DegToRad = Math.PI / 180;

//         public float x { get; set; }
//         public float y { get; set; }
//         public float z { get; set; }

//         public Vector2(float x, float y, float z)
//         {
//             x = x;
//             y = y;
//             z = z;
//         }

//         public static float[,] RotationMatrix(double radians)
//         {
//             float[,] matrix = new float[2, 2];
//             matrix[0, 0] = Math.Cos(radians);
//             matrix[0, 1] = -Math.Sin(radians);
//             matrix[1, 0] = Math.Sin(radians);
//             matrix[1, 1] = Math.Cos(radians);
//             return matrix;
//         }

//         public static Vector2 Cross(Vector2 a, Vector2 b)
//         {
//             return new Vector2(a.y * b.z - a.z * b.y, a.x * b.z, a.x * b.y - a.y * b.x);
//         }

//         public static float SignedAngle(Vector2 a, Vector2 b)
//         {
//             var angle = Math.Acos(Dot(Normalize(a), Normalize(b)));
//             var cross = crossProduct(Va, Vb);
//             if (dotProduct(Vn, cross) < 0)
//             { // Or > 0
//                 angle = -angle;
//             }
//             return Sign
//         }

//         public static Vector2 Normalize(Vector2 v)
//         {
//             var m = Magnitude(v);
//             return new Vector2(v.x / m, v.y / m, 0);
//         }

//         public static float Magnitude(Vector2 v)
//         {
//             return Math.Sqrt(Math.Pow(v.x, 2) + Math.Pow(v.y, 2));
//         }

//         public static Vector2 Rotate(Vector2 v, double angle)
//         {
//             return RotateRadians(v, angle * DegToRad);
//         }

//         public static Vector2 RotateRadians(Vector2 v, double radians)
//         {
//             var rotaionMatrix = RotationMatrix(radians);
//             return new Vector2(v.x * rotaionMatrix[0, 0] + v.y * rotaionMatrix[0, 1], v.x * rotaionMatrix[1, 0] + v.y * rotaionMatrix[1, 1], 0);
//         }

//         public static float Dot(Vector2 a, Vector2 b)
//         {
//             return Math.Acos((a.x * b.x + a.y * b.y) / (Magnitude(a) * Magnitude(b)));
//         }

//         public static Vector2 operator +(Vector2 a, Vector2 b)
//         {
//             return new Vector2(a.x + b.x, a.y + b.y, a.z + b.z);
//         }
//         public static Vector2 operator -(Vector2 a, Vector2 b)
//         {
//             return new Vector2(a.x - b.x, a.y - b.y, a.z - b.z);
//         }
//         public static Vector2 operator *(Vector2 a, float d)
//         {
//             return new Vector2(a.x * d, a.y * d, a.z * d);
//         }
//         public static Vector2 operator *(float d, Vector2 a)
//         {
//             return new Vector2(a.x * d, a.y * d, a.z * d);
//         }
//         public static Vector2 operator /(Vector2 a, float d)
//         {
//             return new Vector2(a.x / d, a.y / d, a.z / d);
//         }
//         public static bool operator ==(Vector2 a, Vector2 b)
//         {
//             return (a.x == b.x && a.y == b.y && a.z == b.z);
//         }

//         public static bool operator !=(Vector2 a, Vector2 b)
//         {
//             return (a.x != b.x || a.y != b.y || a.z != b.z);
//         }

//         public override bool Equals(object obj)
//         {
//             return obj is Vector2 d &&
//                    x == d.x &&
//                    y == d.y &&
//                    z == d.z;
//         }

//         public override int GetHashCode()
//         {
//             int hashCode = -307843816;
//             hashCode = hashCode * -1521134295 + x.GetHashCode();
//             hashCode = hashCode * -1521134295 + y.GetHashCode();
//             hashCode = hashCode * -1521134295 + z.GetHashCode();
//             return hashCode;
//         }
//     }
// }