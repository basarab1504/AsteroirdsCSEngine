using UnityEngine;

public class UnityObserver : MonoBehaviour
{
    public Asteroids.GameObject asteroidsObject;

    // Start is called before the first frame update
    void Start()
    {
        asteroidsObject.OnActiveStateChange += x => gameObject.SetActive(x);
        asteroidsObject.OnDestroy += () => gameObject.SetActive(false);
        transform.position = asteroidsObject.Transform.Position;
        transform.localScale = asteroidsObject.Transform.Scale;
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
        transform.position = asteroidsObject.Transform.Position;
        transform.rotation = Quaternion.LookRotation(transform.forward, asteroidsObject.Transform.Position.normalized);
        // if (asteroidsObject is Ship)
        //     Debug.Log(asteroidsObject.Transform.Rotation.X + " " + asteroidsObject.Transform.Rotation.Y + " " + asteroidsObject.Transform.Rotation.Z);
        // transform.rotation = Quaternion.Euler(asteroidsObject.Transform.Rotation.X, asteroidsObject.Transform.Rotation.Y, asteroidsObject.Transform.Rotation.Z);
    }
}
