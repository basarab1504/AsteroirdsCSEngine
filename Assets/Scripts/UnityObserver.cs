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
    public Game Game { get; set; }
    public Asteroids.GameObject AsteroidsObject { get; set; }

    // Start is called before the first frame update
    private void Start()
    {
        CheckGraphics();

        AsteroidsObject.ActiveStateChange.AddListener(x => transform.position = AsteroidsObject.Transform.Position);
        AsteroidsObject.ActiveStateChange.AddListener(x => gameObject.SetActive(x));
        AsteroidsObject.Destroy.AddListener(() => Destroy(gameObject));
        Game.GraphicsChanged.AddListener(CheckGraphics);
        AsteroidsObject.Destroy.AddListener(() => Game.GraphicsChanged.RemoveListener(CheckGraphics));

        transform.position = AsteroidsObject.Transform.Position;
        transform.localScale = new Vector3(AsteroidsObject.Transform.Scale.x, AsteroidsObject.Transform.Scale.y, 1);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = AsteroidsObject.Transform.Position;
        transform.rotation = Quaternion.LookRotation(transform.forward, AsteroidsObject.Transform.Direction.normalized);
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
