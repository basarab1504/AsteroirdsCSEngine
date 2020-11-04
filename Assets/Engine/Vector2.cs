using System;

namespace Asteroids
{
    public struct Vector3
    {
        private const double DegToRad = Math.PI / 180;

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static float[,] RotationMatrix(double radians)
        {
            float[,] matrix = new float[2, 2];
            matrix[0, 0] = (float)Math.Cos(radians);
            matrix[0, 1] = -(float)Math.Sin(radians);
            matrix[1, 0] = (float)Math.Sin(radians);
            matrix[1, 1] = (float)Math.Cos(radians);
            return matrix;
        }

        public static Vector3 Rotate(Vector3 v, double degrees)
        {
            return RotateRadians(v, degrees * DegToRad);
        }

        public static Vector3 RotateRadians(Vector3 v, double radians)
        {
            var rotaionMatrix = RotationMatrix(radians);
            return new Vector3(v.X * rotaionMatrix[0, 0] + v.Y * rotaionMatrix[0, 1], v.X * rotaionMatrix[1, 0] + v.Y * rotaionMatrix[1, 1], 0);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Vector3 operator *(Vector3 a, float d)
        {
            return new Vector3(a.X * d, a.Y * d, a.Z * d);
        }
        public static Vector3 operator *(float d, Vector3 a)
        {
            return new Vector3(a.X * d, a.Y * d, a.Z * d);
        }
        public static Vector3 operator /(Vector3 a, float d)
        {
            return new Vector3(a.X / d, a.Y / d, a.Z / d);
        }
        public static bool operator ==(Vector3 a, Vector3 b)
        {
            return (a.X == b.X && a.Y == b.Y && a.Z == b.Z);
        }

        public static bool operator !=(Vector3 a, Vector3 b)
        {
            return (a.X != b.X || a.Y != b.Y || a.Z != b.Z);
        }

        public override bool Equals(object obj)
        {
            return obj is Vector3 d &&
                   X == d.X &&
                   Y == d.Y &&
                   Z == d.Z;
        }

        public override int GetHashCode()
        {
            int hashCode = -307843816;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            return hashCode;
        }
    }
}