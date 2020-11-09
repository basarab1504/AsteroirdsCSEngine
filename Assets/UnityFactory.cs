using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Asteroids;
using Component = Asteroids.Component;

public class UnityFactory : MonoBehaviour
{
    public Action<UnityObserver> Instantiated;

    [SerializeField]
    UnityObserver observer;

    public void OnSpawn(Component spawned)
    {
        var instantiated = Instantiate(observer, spawned.Transform.Position, Quaternion.identity);
        spawned.ActiveStateChange += x => instantiated.gameObject.SetActive(x);
        spawned.Destroy += () => Destroy(instantiated.gameObject);
        instantiated.asteroidsObject = spawned.Parent;

        if (Instantiated != null)
            Instantiated(instantiated);
    }
}
