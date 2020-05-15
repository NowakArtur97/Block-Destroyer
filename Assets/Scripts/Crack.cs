using UnityEngine;

public class Crack : MonoBehaviour
{
    [SerializeField]
    private Sprite[] hitSprites;
    [SerializeField]
    private float damageDealtOnCollision = 1f;

    private Health health;

    void Start()
    {
        health = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health.DealDamage(damageDealtOnCollision);

        int healtLeft = (int)health.GetHealth() - 1;

        if (!health.IsDead())
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[healtLeft];
        }
    }
}
