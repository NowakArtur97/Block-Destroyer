using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health = 3;

    public void DealDamage(float damage)
    {
        health -= damage;
    }

    public void RestoreHeatlh(float healthRestored)
    {
        health += healthRestored;
    }

    public float GetHealth()
    {
        return health;
    }

    public void Die()
    {
        FindObjectOfType<GameSession>().BlockDestroyed();
        Destroy(gameObject);
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}
