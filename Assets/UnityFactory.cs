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
        spawned.ActiveStateChange += x => gameObject.SetActive(x);
        var instantiated = Instantiate(observer, spawned.Transform.Position, Quaternion.identity);
        instantiated.asteroidsObject = spawned.Parent;
    }
}
