using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
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
