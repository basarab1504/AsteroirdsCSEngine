namespace Asteroids
{
    public class Time
    {
        public Time(int framerate)
        {
            Time.framerate = framerate;
            time = 0;
        }

        private static int framerate;
        private static float time;
        public static float CurrentTime => time;
        public static float DeltaTime => 1f / framerate;

        public void Update()
        {
            time++;
        }
    }
}