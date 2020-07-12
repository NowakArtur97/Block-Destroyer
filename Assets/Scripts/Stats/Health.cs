using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health = 3;

    private float maxHealth;

    private void Start()
    {
        maxHealth = health;
    }

    public void DealDamage(float damage) => health -= damage;

    public void RestoreMaxHealth() => health = maxHealth;

    public void RestoreHeatlh(float healthRestored)
    {
        if (maxHealth >= health + healthRestored)
        {
            health += healthRestored;
        }
    }

    public float GetHealth()
    {
        return health;
    }

    public void Die()
    {
        FindObjectOfType<GameSession>().BlockDestroyed();
        gameObject.SetActive(false);
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}
