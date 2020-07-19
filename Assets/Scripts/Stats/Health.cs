using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float _health = 4;

    private float _maxHealth { get; set; }

    private void Start() => _maxHealth = _health;

    public void DealDamage(float damage) => _health -= damage;

    public void RestoreMaxHealth() => _health = _maxHealth;

    public void RestoreHeatlh(float healthRestored)
    {
        if (_maxHealth >= _health + healthRestored) _health += healthRestored;
    }

    public float GetHealth() => _health;

    public void Die()
    {
        FindObjectOfType<GameSession>().BlockDestroyed();
        gameObject.SetActive(false);
    }

    public bool IsDead() => _health <= 0;
}
