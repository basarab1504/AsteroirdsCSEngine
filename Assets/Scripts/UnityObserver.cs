using Asteroids;
using UnityEngine;
using Graphics = Asteroids.Graphics;

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
    private void Start()
    {
        CheckGraphics();

        asteroidsObject.ActiveStateChange += x => transform.position = asteroidsObject.Transform.Position;
        asteroidsObject.ActiveStateChange += x => gameObject.SetActive(x);
        asteroidsObject.Destroy += () => Destroy(gameObject);
        Game.GraphicsChanged += CheckGraphics;
        asteroidsObject.Destroy += () => Game.GraphicsChanged -= CheckGraphics;
        
        transform.position = asteroidsObject.Transform.Position;
        transform.localScale = new Vector3(asteroidsObject.Transform.Scale.x, asteroidsObject.Transform.Scale.y, 1);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = asteroidsObject.Transform.Position;
        transform.rotation = Quaternion.LookRotation(transform.forward, asteroidsObject.Transform.Direction.normalized);
    }

    private void CheckGraphics()
    {
        if (Game.Mode == Graphics.TwoDimension && gameObject.GetComponent<SpriteRenderer>() == null || Game.Mode == Graphics.ThreeDimension && gameObject.GetComponent<MeshRenderer>() == null)
            ChangeGraphics();
    }

    private void ChangeGraphics()
    {
        if (Game.Mode == Asteroids.Graphics.TwoDimension)
        {
            DestroyImmediate(GetComponent<MeshRenderer>());
            DestroyImmediate(GetComponent<MeshFilter>());
            gameObject.AddComponent<SpriteRenderer>().sprite = sprite;
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
        else
        {
            DestroyImmediate(GetComponent<SpriteRenderer>());
            gameObject.AddComponent<MeshFilter>().mesh = mesh;
            gameObject.AddComponent<MeshRenderer>().material = material;
            gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
        }
    }
}
