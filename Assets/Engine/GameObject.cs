using System;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids
{
    public class GameObject : Component
    {
        public Transform Transform { get; set; }

        public override void Awake()
        {
            base.Awake();
            Transform = AddComponent<Transform>();
        }

        public override void Start()
        {
            base.Start();
            SetActive(true);
        }

        public float Speed { get; set; }

        public void Move(Vector3 direction)
        {
            Transform.Position += direction;
            foreach (var child in Components.OfType<GameObject>())
                child.Move(direction);
        }
    }
}