﻿using System.Collections.Generic;
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
    UnityFactory unityPlayerShipFactory;
    [SerializeField]
    UnityFactory unityAsteroidFactory;
    [SerializeField]
    UnityFactory unityEnemyShipFactory;
    [SerializeField]
    UnityFactory unityEnemyBulletFactory;
    [SerializeField]
    UnityFactory unityPlayerBulletsFactory;
    [SerializeField]
    UnityFactory unityPlayerLaserAmmoFactory;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Button restart;
    [SerializeField]
    Button changeGraphics;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = targetFramerate;
        Restart();
        changeGraphics.onClick.AddListener(game.ChangeMode);
    }

    // Update is called once per frame
    void Update()
    {
        game.Update();
    }

    public void Restart()
    {
        scoreText.text = "0";

        game = new Game();
        
        game.ScoreChanged += () => scoreText.text = game.Score.ToString();
        game.GameStarted += () => restart.gameObject.SetActive(false);
        game.GameOver += () => restart.gameObject.SetActive(true);

        game.Init(new Vector2(10, 10), targetFramerate);

        Physics.LayerSettings.Add(Layer.Player, new List<Layer>() { Layer.Asteroid, Layer.EnemyShip, Layer.BulletEnemy });
        Physics.LayerSettings.Add(Layer.EnemyShip, new List<Layer>() { Layer.Player, Layer.BulletPlayer });
        Physics.LayerSettings.Add(Layer.Asteroid, new List<Layer>() { Layer.BulletPlayer });
        Physics.LayerSettings.Add(Layer.BulletPlayer, new List<Layer>() { Layer.BulletEnemy });

        // CreateEnemyShipSpawner();
        // CreateAsteroidSpawner();

        var shipSpawner = CreatePlayerShipSpawner();
        shipSpawner.Spawn();
    }

    private void CreateEnemyShipSpawner()
    {
        var enemyShipSpawnerGameObject = Game.Create<GameObject>();

        var enemyShipSpawnerTransform = enemyShipSpawnerGameObject.AddComponent<Transform>();
        enemyShipSpawnerTransform.Position = new Vector2(0, 0);
        enemyShipSpawnerTransform.Scale = new Vector2(10, 10);
        enemyShipSpawnerTransform.Direction = new Vector2(0, 1);

        var enemyShipSpawnerComponent = enemyShipSpawnerGameObject.AddComponent<CooldownSpawner<EnemyShip>>();
        enemyShipSpawnerComponent.Cooldown = 200;

        var enemyShipFactory = new EnemyShipFactory();
        var enemyPlayerBulletFactory = new EnemyBulletFactory();

        enemyPlayerBulletFactory.Spawned += unityEnemyBulletFactory.OnSpawn;
        enemyShipFactory.BulletFactory = enemyPlayerBulletFactory;
        enemyShipFactory.Spawned += unityEnemyShipFactory.OnSpawn;

        enemyShipSpawnerComponent.Factory = enemyShipFactory;
    }

    private void CreateAsteroidSpawner()
    {
        var asteroidSpawnerGameObject = Game.Create<GameObject>();

        var asteroidSpawnerTransform = asteroidSpawnerGameObject.AddComponent<Transform>();
        asteroidSpawnerTransform.Position = new Vector2(0, 0);
        asteroidSpawnerTransform.Scale = new Vector2(10, 10);
        asteroidSpawnerTransform.Direction = new Vector2(0, 1);

        var asteroidSpawner = asteroidSpawnerGameObject.AddComponent<CooldownSpawner<Asteroid>>();
        asteroidSpawner.Cooldown = 150;

        var asteroidFactory = new AsteroidFactory();
        asteroidFactory.Duplicator = new ChildAsteroidFactory();
        asteroidFactory.Duplicator.Spawned += unityAsteroidFactory.OnSpawn;
        asteroidFactory.Spawned += unityAsteroidFactory.OnSpawn;
        asteroidSpawner.Factory = asteroidFactory;
    }

    private Spawner<Ship> CreatePlayerShipSpawner()
    {
        var shipSpawnerGameObject = Game.Create<GameObject>();

        var shipSpawnerTransform = shipSpawnerGameObject.AddComponent<Transform>();
        shipSpawnerTransform.Position = new Vector2(0, 0);
        shipSpawnerTransform.Scale = new Vector2(3, 3);
        shipSpawnerTransform.Direction = new Vector2(0, 1);

        var shipSpawnerComponent = shipSpawnerGameObject.AddComponent<Spawner<Ship>>();

        var shipFactory = new PlayerShipFactory();
        var playerBulletFactory = new PlayerBulletFactory();
        var playerLaserAmmoFactory = new PlayerLaserAmmoFactory();

        playerBulletFactory.Spawned += unityPlayerBulletsFactory.OnSpawn;
        shipFactory.BulletFactory = playerBulletFactory;

        playerLaserAmmoFactory.Spawned += unityPlayerLaserAmmoFactory.OnSpawn;
        shipFactory.LaserAmmoFactory = playerLaserAmmoFactory;

        shipFactory.Spawned += unityPlayerShipFactory.OnSpawn;

        shipSpawnerComponent.Factory = shipFactory;

        return shipSpawnerComponent;
    }
}
