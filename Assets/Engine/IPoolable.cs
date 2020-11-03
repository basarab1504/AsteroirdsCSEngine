namespace Asteroids
{
    public interface IPoolable
    {
        bool InUse();
        void Reset();
    }
}