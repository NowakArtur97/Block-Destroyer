using UnityEngine;

public class Crack : MonoBehaviour
{
    [SerializeField]
    private Sprite[] hitSprites;
    [SerializeField]
    private Sprite defaultSprite;

    private Health health;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        health = GetComponent<Health>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeState()
    {
        int healthLeft = (int)health.GetHealth() - 1;

        spriteRenderer.sprite = hitSprites[healthLeft];
    }

    public void RevertChanges()
    {
        spriteRenderer.sprite = defaultSprite;
    }
}
