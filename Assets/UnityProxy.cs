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
    [SerializeField]
    UnityFactory asteroidFactory;
    [SerializeField]
    UnityFactory enemyShipFactory;
    [SerializeField]
    UnityFactory playerBulletsFactory;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = targetFramerate;

        game = new Game();
        game.Init(new Vector2(10, 10), targetFramerate);
        // Game.LayerSettings.Add(Layer.Player, new List<Layer>() { Layer.Asteroid, Layer.EnemyShip, Layer.BulletEnemy });
        // Game.LayerSettings.Add(Layer.EnemyShip, new List<Layer>() { Layer.Player, Layer.BulletPlayer });
        // Game.LayerSettings.Add(Layer.Asteroid, new List<Layer>() { Layer.BulletPlayer });
        // Game.LayerSettings.Add(Layer.BulletPlayer, new List<Layer>() { Layer.BulletEnemy });

        // var asteroidSpawner = Game.Create<GameObject>();

        // var asteroidSpawnerTransform = asteroidSpawner.GetComponent<Transform>();
        // asteroidSpawnerTransform.Position = new Vector2(0, 0);
        // asteroidSpawnerTransform.Scale = new Vector2(10, 10);
        // asteroidSpawnerTransform.Direction = new Vector2(0, 1);

        // var aSpawner = asteroidSpawner.AddComponent<CooldownSpawner<Asteroid>>();
        // aSpawner.Cooldown = 150;

        // var af = new AsteroidFactory();
        // af.Spawned += asteroidFactory.OnSpawn;
        // aSpawner.Factory = af;

        // var enemyShipSpawner = Game.Create<GameObject>();

        // var enemyShipSpawnerTransform = enemyShipSpawner.GetComponent<Transform>();
        // enemyShipSpawnerTransform.Position = new Vector2(0, 0);
        // enemyShipSpawnerTransform.Scale = new Vector2(10, 10);
        // enemyShipSpawnerTransform.Direction = new Vector2(0, 1);

        // var eSpawner = enemyShipSpawner.AddComponent<CooldownSpawner<EnemyShip>>();
        // eSpawner.Cooldown = 200;

        // var ef = new EnemyShipFactory();
        // ef.Spawned += enemyShipFactory.OnSpawn;
        // eSpawner.Factory = ef;
        // eSpawner.Spawn();

        var shipSpawner = Game.Create<GameObject>();

        var shipSpawnerTransform = shipSpawner.GetComponent<Transform>();
        shipSpawnerTransform.Position = new Vector2(0, 0);
        shipSpawnerTransform.Scale = new Vector2(1, 1);
        shipSpawnerTransform.Direction = new Vector2(0, 1);

        var spawner = shipSpawner.AddComponent<Spawner<Ship>>();

        spawner.Transform.Scale = new Vector2(2, 2);
        var sf = new ShipFactory();
        var bf = new BulletFactory();
        bf.Spawned += playerBulletsFactory.OnSpawn;
        sf.BulletFactory = bf;
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
