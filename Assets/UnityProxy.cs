using System.Collections.Generic;
using UnityEngine;
using Asteroids;
using Transform = Asteroids.Transform;
using GameObject = Asteroids.GameObject;
using UnityEngine.UI;
using Physics = Asteroids.Physics;

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
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Button restart;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = targetFramerate;
        Restart();
    }

    public void Restart()
    {
        game = new Game();
        game.ScoreChanged += () => scoreText.text = game.Score.ToString();
        // game.GameStarted += () => restart.gameObject.SetActive(false);
        // game.GameOver += () => restart.gameObject.SetActive(true);
        game.Init(new Vector2(10, 10), targetFramerate);

        Physics.LayerSettings.Add(Layer.Player, new List<Layer>() { Layer.Asteroid, Layer.EnemyShip, Layer.BulletEnemy });
        Physics.LayerSettings.Add(Layer.EnemyShip, new List<Layer>() { Layer.Player, Layer.BulletPlayer });
        Physics.LayerSettings.Add(Layer.Asteroid, new List<Layer>() { Layer.BulletPlayer });
        Physics.LayerSettings.Add(Layer.BulletPlayer, new List<Layer>() { Layer.BulletEnemy });

        var asteroidSpawner = Game.Create<GameObject>();

        var asteroidSpawnerTransform = asteroidSpawner.AddComponent<Transform>();
        asteroidSpawnerTransform.Position = new Vector2(0, 0);
        asteroidSpawnerTransform.Scale = new Vector2(10, 10);
        asteroidSpawnerTransform.Direction = new Vector2(0, 1);

        var aSpawner = asteroidSpawner.AddComponent<CooldownSpawner<Asteroid>>();
        aSpawner.Cooldown = 150;

        var af = new AsteroidFactory();
        af.Spawned += asteroidFactory.OnSpawn;
        aSpawner.Factory = af;

        // var enemyShipSpawner = Game.Create<GameObject>();

        // var enemyShipSpawnerTransform = enemyShipSpawner.AddComponent<Transform>();
        // enemyShipSpawnerTransform.Position = new Vector2(0, 0);
        // enemyShipSpawnerTransform.Scale = new Vector2(10, 10);
        // enemyShipSpawnerTransform.Direction = new Vector2(0, 1);

        // var eSpawner = enemyShipSpawner.AddComponent<CooldownSpawner<EnemyShip>>();
        // eSpawner.Cooldown = 200;

        // var ef = new EnemyShipFactory();
        // ef.Spawned += enemyShipFactory.OnSpawn;
        // eSpawner.Factory = ef;

        var shipSpawnerGameObject = Game.Create<GameObject>();

        var shipSpawnerTransform = shipSpawnerGameObject.AddComponent<Transform>();

        shipSpawnerTransform.Position = new Vector2(0, 0);
        shipSpawnerTransform.Scale = new Vector2(1, 1);
        shipSpawnerTransform.Direction = new Vector2(0, 1);

        var spawner = shipSpawnerGameObject.AddComponent<Spawner<Ship>>();

        spawner.Transform.Scale = new Vector2(2, 2);
        var sf = new ShipFactory();
        var bf = new PlayerBulletFactory();
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
