using UnityEngine;

public class Crack : MonoBehaviour
{
    [SerializeField]
    private Sprite[] hitSprites;

    private Health health;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        health = GetComponent<Health>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void CrackObject(float damage)
    {
        int healthLeft = (int)(health.GetHealth() - damage);

        spriteRenderer.sprite = hitSprites[healthLeft];
    }
}
