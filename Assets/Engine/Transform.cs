namespace Asteroids
{
    public class Transform : Component
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }

        public override void Awake()
        {
            Position = new Vector3();
            Rotation = new Vector3();
            Scale = new Vector3();
        }
    }
}