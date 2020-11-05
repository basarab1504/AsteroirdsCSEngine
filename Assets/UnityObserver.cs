using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;



public class UnityObserver : MonoBehaviour
{
    public Asteroids.GameObject asteroidsObject;

    // Start is called before the first frame update
    void Start()
    {
        asteroidsObject.OnActiveStateChange += x => gameObject.SetActive(x);
        asteroidsObject.OnDestroy += () => gameObject.SetActive(false);
        transform.position = new UnityEngine.Vector3(asteroidsObject.Transform.Position.X, asteroidsObject.Transform.Position.Y, asteroidsObject.Transform.Position.Z);
        transform.localScale = new UnityEngine.Vector3(asteroidsObject.Transform.Scale.X, asteroidsObject.Transform.Scale.Y, asteroidsObject.Transform.Scale.Z);
    }

    // Update is called once per frame
    void Update()
    {
        // string info = "";
        // if (asteroidsObject is Asteroid)
        //     foreach (var c in asteroidsObject.Components)
        //         if (c.GetComponent<Asteroids.Transform>() != null)
        //             info += $"{c} cords: ({c.GetComponent<Asteroids.Transform>().Position.X};{+c.GetComponent<Asteroids.Transform>().Position.Y})";
        // Debug.Log($"{asteroidsObject} is {asteroidsObject.GetComponent<Asteroids.Transform>().Position.X};{asteroidsObject.GetComponent<Asteroids.Transform>().Position.Y} : {info}");
        // if (asteroidsObject is Ship)
        //     Debug.Log(asteroidsObject.Transform.Position.X + " " + asteroidsObject.Transform.Position.Y + " " + asteroidsObject.GetComponent<Gun>().Transform.Position.X + " " + asteroidsObject.GetComponent<Gun>().Transform.Position.Y);
        transform.position = new UnityEngine.Vector3(asteroidsObject.Transform.Position.X, asteroidsObject.Transform.Position.Y, asteroidsObject.Transform.Position.Z);
        transform.rotation = Quaternion.LookRotation(transform.forward, new UnityEngine.Vector3(asteroidsObject.Transform.Position.X, asteroidsObject.Transform.Position.Y, 0).normalized);
        // if (asteroidsObject is Ship)
        //     Debug.Log(asteroidsObject.Transform.Rotation.X + " " + asteroidsObject.Transform.Rotation.Y + " " + asteroidsObject.Transform.Rotation.Z);
        // transform.rotation = Quaternion.Euler(asteroidsObject.Transform.Rotation.X, asteroidsObject.Transform.Rotation.Y, asteroidsObject.Transform.Rotation.Z);
    }
}
