using UnityEngine;
using UnityEngine.U2D;

public class SpawnToken : MonoBehaviour
{
    public GameObject token;
    public Sprite sprite;
    private SpriteRenderer m_spriteRenderer;

    private void Awake()
    {
        // Fetch the SpriteRenderer from the GameObject
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_spriteRenderer.sprite = sprite;
        m_spriteRenderer.color = Color.blue;
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        
    }
}
