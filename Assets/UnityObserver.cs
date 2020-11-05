using UnityEngine;

public class UnityObserver : MonoBehaviour
{
    public Asteroids.GameObject asteroidsObject;

    // Start is called before the first frame update
    void Start()
    {
        asteroidsObject.ActiveStateChange += x => gameObject.SetActive(x);
        asteroidsObject.Destroy += () => Destroy(gameObject);
        transform.position = asteroidsObject.Transform.Position;
        transform.localScale = asteroidsObject.Transform.Scale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = asteroidsObject.Transform.Position;
        transform.rotation = Quaternion.LookRotation(transform.forward, asteroidsObject.Transform.Rotation.normalized);
    }
}
