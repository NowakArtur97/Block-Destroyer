using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health = 4;

    public void DealDamage(float damage)
    {
        health -= damage;
    }

    public float GetHealth()
    {
        return health;
    }

    private void Update()
    {
        if (IsDead())
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}
