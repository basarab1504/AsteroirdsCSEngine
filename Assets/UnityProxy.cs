﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;

public class UnityProxy : MonoBehaviour
{
    [SerializeField]
    int targetFramerate;
    Game game;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = targetFramerate;

        game = new Game();
        game.Init(new Asteroids.Vector3(10, 10, 0), targetFramerate);
        game.LayerSettings.Add(Layer.Player, new List<Layer>() { Layer.Asteroid, /*Layer.Bullet,*/ Layer.EnemyShip });
        game.LayerSettings.Add(Layer.EnemyShip, new List<Layer>() { Layer.Bullet });
        game.LayerSettings.Add(Layer.Asteroid, new List<Layer>() { Layer.Bullet });

        // var asteroidSpawner = Game.Create<CooldownSpawner<Asteroid>>();
        // asteroidSpawner.Transform.Scale = new Asteroids.Vector3(10, 10, 0);
        // asteroidSpawner.Cooldown = 50;
        // asteroidSpawner.Factory = GetComponent<UnityAsteroidFactory>();

        var enemyShipSpawner = Game.Create<CooldownSpawner<Ship>>();
        enemyShipSpawner.Transform.Scale = new Asteroids.Vector3(10, 10, 0);
        enemyShipSpawner.Cooldown = 50;
        enemyShipSpawner.Factory = GetComponent<UnityShipFactory>();

        // var shipSpawner = Game.Create<Spawner<Ship>>();
        // shipSpawner.Factory = GetComponent<UnityShipFactory>();
        // shipSpawner.Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        game.Update();
    }
}
