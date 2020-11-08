using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityObserver : MonoBehaviour
{
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private Mesh mesh;
    [SerializeField]
    private Material material;
    [SerializeField]
    private Color color;

    public Asteroids.GameObject asteroidsObject;

    // Start is called before the first frame update
    void Start()
    {
        OnChangeGraphics();
        asteroidsObject.ActiveStateChange += x => transform.position = asteroidsObject.Transform.Position;
        asteroidsObject.ActiveStateChange += x => gameObject.SetActive(x);
        asteroidsObject.Destroy += () => Destroy(gameObject);
        transform.position = asteroidsObject.Transform.Position;
        transform.localScale = asteroidsObject.Transform.Scale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = asteroidsObject.Transform.Position;
        transform.rotation = Quaternion.LookRotation(transform.forward, asteroidsObject.Transform.Direction.normalized);
    }

    public void OnChangeGraphics()
    {
        // if (UnityProxy.Is2D)
        // {
        //     // DestroyImmediate(GetComponent<MeshRenderer>());
        //     // DestroyImmediate(GetComponent<MeshFilter>());
        //     // gameObject.AddComponent<SpriteRenderer>().sprite = sprite;
        //     // gameObject.GetComponent<SpriteRenderer>().color = color;
        // }
        // else
        // {
        //     DestroyImmediate(GetComponent<SpriteRenderer>());
        //     gameObject.AddComponent<MeshFilter>().mesh = mesh;
        //     gameObject.AddComponent<MeshRenderer>().material = material;
        // }
    }
}
