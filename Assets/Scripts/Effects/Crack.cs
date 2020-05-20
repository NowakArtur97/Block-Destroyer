using UnityEngine;

public class Crack : MonoBehaviour
{
    [SerializeField]
    private Sprite[] hitSprites;
    [SerializeField]
    private float damageDealtOnCollision = 1f;

    private Health health;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        health = GetComponent<Health>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health.DealDamage(damageDealtOnCollision);

        CrackObject();
    }

    private void CrackObject()
    {
        int healtLeft = (int)health.GetHealth() - 1;

        if (!health.IsDead())
        {
            spriteRenderer.sprite = hitSprites[healtLeft];
        }
    }
}
