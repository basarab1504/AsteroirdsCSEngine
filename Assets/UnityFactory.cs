using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;
using Collider = Asteroids.Collider;
using Vector3 = Asteroids.Vector3;

public abstract class UnityFactory<T> : MonoBehaviour, IFactory<T> where T : Asteroids.GameObject
{
    [SerializeField]
    UnityObserver observer;

    public T Create()
    {
        var created = UnityCreate();
        created.OnActiveStateChange += x => gameObject.SetActive(x);
        var instantiated = Instantiate(observer, new UnityEngine.Vector3(created.Transform.Position.X, created.Transform.Position.Y, created.Transform.Position.Z), Quaternion.identity);
        instantiated.asteroidsObject = created;
        return created;
    }

    public abstract T UnityCreate();
}
