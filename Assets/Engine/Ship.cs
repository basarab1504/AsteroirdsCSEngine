using System;
using System.Numerics;
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

    public class Ship : Component
    {
        public float Speed { get; set; }
        public float RotationSpeed { get; set; }

        public IEnumerable<Command> Commands { get; set; }

        public override void Start()
        {
            base.Start();
            Commands = new List<Command>()
            {
                new Command(() => Input.GetKey(KeyCode.UpArrow), () => GetComponent<Thruster>().AddForce(Transform.Direction.normalized * Speed)),
                new Command(() => Input.GetKey(KeyCode.RightArrow), () => Parent.Rotate(-RotationSpeed)),
                new Command(() => Input.GetKey(KeyCode.LeftArrow), () => Parent.Rotate(RotationSpeed)),
                new Command(() => Input.GetKeyDown(KeyCode.LeftAlt), () => GetComponent<Gun>().Shoot()),
                new Command(() => Input.GetKeyDown(KeyCode.Space), () => GetComponent<Gun>().NextAmmo()),
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