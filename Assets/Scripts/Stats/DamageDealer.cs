using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    private float damageDealt = 1f;
    [SerializeField]
    private float defaultDamageDealt = 1f;

    public void SetDamage(float damageDealt)
    {
        this.damageDealt = damageDealt;
    }

    public void ResetDamage()
    {
        damageDealt = defaultDamageDealt;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Skull"))
        {
            AttackBlock(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lose Collider"))
        {
            SubtractPlayerHealth();
        }
    }

    private void SubtractPlayerHealth()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player Health");

        Health playerHealth = player.GetComponent<Health>();

        playerHealth.DealDamage(damageDealt);

        if (playerHealth.IsDead())
        {
            FindObjectOfType<LevelManager>().RestartLevel();
        }
        else
        {
            player.GetComponent<Crack>().ChangeState();
        }
    }

    private void AttackBlock(GameObject block)
    {
        Health blockHealth = block.GetComponent<Health>();

        blockHealth.DealDamage(damageDealt);

        if (blockHealth.IsDead())
        {
            blockHealth.Die();
        }
        else if (block.CompareTag("Block"))
        {
            block.GetComponent<Crack>().ChangeState();
        }
    }
}
