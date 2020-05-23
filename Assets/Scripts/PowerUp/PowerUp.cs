using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private Power power;

    private SpriteRenderer spriteRenderer;

    private Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        spriteRenderer.sprite = power.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            Pickup();
        }
    }

    private void Pickup()
    {

    }
}
