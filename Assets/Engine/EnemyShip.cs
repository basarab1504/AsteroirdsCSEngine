using System;
using Asteroids;

public class EnemyShip : Ship
{
    public override void Start()
    {
        base.Start();
        Direction = GetDirection();
    }

    private Vector3 GetDirection()
    {
        var rnd = new Random();

        var m = rnd.NextDouble() > 0.9f ? -1 : 1;

        return new Vector3(0, m, 0);
    }
}
