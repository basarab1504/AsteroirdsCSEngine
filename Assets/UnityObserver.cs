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
    }

    // Update is called once per frame
    void Update()
    {
        // if (asteroidsObject is Ship)
        //     Debug.Log(asteroidsObject.Transform.Position.X + " " + asteroidsObject.Transform.Position.Y + " " + asteroidsObject.GetComponent<Gun>().Transform.Position.X + " " + asteroidsObject.GetComponent<Gun>().Transform.Position.Y);
        transform.position = new UnityEngine.Vector3(asteroidsObject.Transform.Position.X, asteroidsObject.Transform.Position.Y, asteroidsObject.Transform.Position.Z);
        // if (asteroidsObject is Ship)
        //     Debug.Log(asteroidsObject.Transform.Rotation.X + " " + asteroidsObject.Transform.Rotation.Y + " " + asteroidsObject.Transform.Rotation.Z);
        // transform.rotation = Quaternion.Euler(asteroidsObject.Transform.Rotation.X, asteroidsObject.Transform.Rotation.Y, asteroidsObject.Transform.Rotation.Z);
    }
}
