namespace Asteroids
{
    public struct Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
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