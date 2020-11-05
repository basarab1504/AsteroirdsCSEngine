using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;

public abstract class UnityFactory<T> : MonoBehaviour, IFactory<T> where T : Asteroids.GameObject
{
    [SerializeField]
    UnityObserver observer;

    public T Create()
    {
        var created = UnityCreate();
        // created.OnActiveStateChange += x => gameObject.SetActive(x);
        var instantiated = Instantiate(observer, created.Transform.Position, Quaternion.identity);
        instantiated.asteroidsObject = created;
        return created;
    }

    public abstract T UnityCreate();
}
