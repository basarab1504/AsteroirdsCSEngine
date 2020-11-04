using System.Linq;

namespace Asteroids
{
    public class Transform : Component
    {
        private Vector3 position;
        public Vector3 Position
        {
            //мерзко и ужасно
            get => position;
            set
            {
                position = value;
                if (Parent != null)
                {
                    foreach (var child in Parent.Components.OfType<GameObject>())
                        child.Transform.Position = value;
                }
            }
        }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }

        public Vector3 Up => Rotation - Position;

        public override void OnCreate()
        {
            position = new Vector3();
            Rotation = new Vector3();
            Scale = new Vector3();
        }
    }
}