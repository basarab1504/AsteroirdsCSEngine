using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Command
    {
        private Func<bool> condition;
        private Action action;

        public Command(Func<bool> condition, Action action)
        {
            this.condition = condition;
            this.action = action;
        }

        public void Execute()
        {
            action();
        }

        public bool CanExecute()
        {
            return condition();
        }
    }

    public class Ship : GameObject
    {
        public float Speed { get; set; }
        private Gun Gun { get; set; }
        private Thruster Thruster { get; set; }
        public Vector2 Direction { get; set; }
        public float RotationSpeed { get; set; }

        public IEnumerable<Command> Commands { get; set; }

        public override void Start()
        {
            base.Start();
            Gun = GetComponent<Gun>();
            Thruster = GetComponent<Thruster>();

            Commands = new List<Command>()
            {
                new Command(() => Input.GetKeyDown(KeyCode.Space), () => Thruster.AddForce(Transform.Rotation * Speed)),
                new Command(() => Input.GetKey(KeyCode.RightArrow), () => Rotate(-RotationSpeed)),
                new Command(() => Input.GetKey(KeyCode.LeftArrow), () => Rotate(RotationSpeed)),
            };
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