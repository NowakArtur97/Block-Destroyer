using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            RestartAndSpawnBall(collision);
        }
    }

    private void RestartAndSpawnBall(Collider2D collision)
    {
        gameSession.RestartGame();

        Destroy(collision.gameObject);
    }
}