using UnityEngine;

namespace Asteroids
{
    public class Thruster : Component
    {
        public Vector2 Velocity { get; set; }
        public float LinearDrag { get; set; }

        public override void OnCreate()
        {
            base.OnCreate();
            Velocity = new Vector2();
            LinearDrag = 1;
        }

        public void AddForce(Vector2 force)
        {
            Velocity += force;
        }

        public override void Update()
        {
            base.Update();
            Velocity *= LinearDrag;
            Parent.GetComponent<Transform>().Position += Velocity;
        }
    }
}