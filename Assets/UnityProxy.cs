using System.Collections.Generic;
using UnityEngine;
using Asteroids;
using Transform = Asteroids.Transform;
using GameObject = Asteroids.GameObject;

public class UnityProxy : MonoBehaviour
{
    [SerializeField]
    int targetFramerate;
    Game game;

    [SerializeField]
    UnityFactory shipFactory;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = targetFramerate;

        game = new Game();
        game.Init(new Vector2(10, 10), targetFramerate);
        Game.LayerSettings.Add(Layer.Player, new List<Layer>() { Layer.Asteroid, Layer.EnemyShip, Layer.BulletEnemy });
        Game.LayerSettings.Add(Layer.EnemyShip, new List<Layer>() { Layer.Player, Layer.BulletPlayer });
        Game.LayerSettings.Add(Layer.Asteroid, new List<Layer>() { Layer.BulletPlayer });
        Game.LayerSettings.Add(Layer.BulletPlayer, new List<Layer>() { Layer.BulletEnemy });

        // var asteroidSpawner = Game.Create<GameObject>().AddComponent<CooldownSpawner<Asteroid>>();

        // var AStransform = asteroidSpawner.GetComponent<Transform>();
        // AStransform.Position = new Vector2(0, 0);
        // AStransform.Scale = new Vector2(1, 1);
        // AStransform.Direction = new Vector2(0, 1);

        // asteroidSpawner.Transform.Scale = new Vector2(10, 10);
        // asteroidSpawner.Cooldown = 75;
        // asteroidSpawner.Factory = new AsteroidFactory();

        // var enemyShipSpawner = Game.Create<GameObject>().AddComponent<CooldownSpawner<Ship>>();

        // var AStransform = enemyShipSpawner.GetComponent<Transform>();
        // AStransform.Position = new Vector2(0, 0);
        // AStransform.Scale = new Vector2(1, 1);
        // AStransform.Direction = new Vector2(0, 1);

        // enemyShipSpawner.Transform.Scale = new Vector2(10, 10);
        // enemyShipSpawner.Cooldown = 250;
        // enemyShipSpawner.Factory = new EnemyShipFactory();

        var shipSpawner = Game.Create<GameObject>();

        var AStransform = shipSpawner.GetComponent<Transform>();
        AStransform.Position = new Vector2(0, 0);
        AStransform.Scale = new Vector2(1, 1);
        AStransform.Direction = new Vector2(0, 1);

        var spawner = shipSpawner.AddComponent<Spawner<Ship>>();

        spawner.Transform.Scale = new Vector2(10, 10);
        var sf = new ShipFactory();
        sf.Spawned += shipFactory.OnSpawn;
        spawner.Factory = sf;

        spawner.Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        game.Update();
    }
}
