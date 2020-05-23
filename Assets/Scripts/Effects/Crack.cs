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

    public void CrackObject()
    {
        int healthLeft = (int)health.GetHealth() - 1;

        spriteRenderer.sprite = hitSprites[healthLeft];
    }
}
