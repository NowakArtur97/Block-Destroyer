using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    [SerializeField]
    private float damageDealt = 1f;

    private Health playerHealth;

    private GameSession gameSession;

    private void Start()
    {
        playerHealth = FindObjectOfType<Paddle>().GetComponent<Health>();

        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            gameSession.RestartGame();

            playerHealth.DealDamage(damageDealt);

            Destroy(collision.gameObject);
        }
    }
}