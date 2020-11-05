using UnityEngine;

namespace Asteroids
{
    public class GameObject : Component
    {
        public Transform Transform { get; set; }

        public override void OnCreate()
        {
            base.OnCreate();
            Transform = AddComponent<Transform>();
        }

        public void Rotate(float angle)
        {
            Transform.Direction = Transform.Direction.Rotate(angle);
        }

        public void Move(Vector2 direction)
        {
            Transform.Position += direction;
        }
    }
}