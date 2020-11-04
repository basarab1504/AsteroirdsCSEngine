using System;
using System.Collections.Generic;

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

        public override void Update()
        {
            base.Update();
            if (Parent != null && Parent is GameObject)
                Transform.Position += Parent.GetComponent<Transform>().Position;
        }
    }
}