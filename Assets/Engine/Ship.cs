using System;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Ship : Component
    {
        public float Speed { get; set; }
        public float RotationSpeed { get; set; }
        public IEnumerable<Command> Commands { get; set; }

        public override void Start()
        {
            base.Start();
            GetComponent<Collider>().Collision.AddListener(Parent.DestroyObject);
        }

        public override void Update()
        {
            foreach (var c in Commands)
            {
                if (c.CanExecute())
                    c.Execute();
            }
        }
    }
}