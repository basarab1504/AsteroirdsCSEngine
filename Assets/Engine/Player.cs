namespace Asteroids
{
    public class Player : Component
    {
        public override void OnDestroy()
        {
            base.OnDestroy();
            // Game.OnGameOver();
        }
    }
}