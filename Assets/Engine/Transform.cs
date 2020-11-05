using System.Linq;
using UnityEngine;

namespace Asteroids
{
    public class Transform : Component
    {
        private Vector2 position;
        public Vector2 Position
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
        public Vector2 Rotation { get; set; }
        public Vector2 Scale { get; set; }

        public override void OnCreate()
        {
            position = new Vector2();
            Rotation = new Vector2(0, 1);
            Scale = new Vector2();
        }
    }
}