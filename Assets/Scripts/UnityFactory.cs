﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Asteroids;
using Component = Asteroids.Component;

public class UnityFactory : MonoBehaviour
{
    [SerializeField]
    UnityObserver observer;

    public void OnSpawn(Component spawned)
    {
        var instantiated = Instantiate(observer, spawned.Transform.Position, Quaternion.identity);
        spawned.ActiveStateChange.AddListener(x => instantiated.gameObject.SetActive(x));
        spawned.Destroy.AddListener(() => Destroy(instantiated.gameObject));
        instantiated.asteroidsObject = spawned.Parent;
    }
}
