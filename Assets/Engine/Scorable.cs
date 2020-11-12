using System;

namespace Asteroids
{
    public class Scorable : Component
    {
        public Action Scored;

        public int Score { get; set; }

        public override void Start()
        {
            base.Start();
            GetComponent<Collider>().Collision.AddListener(OnScored);
        }

        private void OnScored()
        {
            if (Scored != null)
                Scored();
        }
    }
}