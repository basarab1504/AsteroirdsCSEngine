using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;
using Component = Asteroids.Component;

public class UnityFactory : MonoBehaviour
{
    [SerializeField]
    UnityObserver observer;

    public void OnSpawn(Component spawned)
    {
        var instantiated = Instantiate(observer, spawned.Transform.Position, Quaternion.identity);
        spawned.ActiveStateChange += x => instantiated.gameObject.SetActive(x);
        instantiated.asteroidsObject = spawned.Parent;
    }
}
