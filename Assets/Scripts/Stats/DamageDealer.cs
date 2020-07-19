using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    private float _damageDealt = 1f;
    [SerializeField]
    private readonly float _defaultDamageDealt = 1f;

    public void SetDamage(float damageDealt) => _damageDealt = damageDealt;

    public void ResetDamage() => _damageDealt = _defaultDamageDealt;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsOfBlockType(collision))
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

        playerHealth.DealDamage(_damageDealt);

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

        blockHealth.DealDamage(_damageDealt);

        if (blockHealth.IsDead())
        {
            blockHealth.Die();
        }
        else if (block.CompareTag("Block"))
        {
            block.GetComponent<Crack>().ChangeState();
        }
    }

    private static bool IsOfBlockType(Collision2D collision)
    {
        return collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Skull")
                     || collision.gameObject.CompareTag("Space Ship");
    }
}
