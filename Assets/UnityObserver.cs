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

    }

    // Update is called once per frame
    void Update()
    {
        // if (asteroidsObject is Ship)
            // Debug.Log(asteroidsObject.Transform.Position.X + " " + asteroidsObject.Transform.Position.Y + " " + asteroidsObject.GetComponent<Gun>().Transform.Position.X + " " + asteroidsObject.GetComponent<Gun>().Transform.Position.Y);
        transform.position = new UnityEngine.Vector3(asteroidsObject.Transform.Position.X, asteroidsObject.Transform.Position.Y, asteroidsObject.Transform.Position.Z);
    }
}
