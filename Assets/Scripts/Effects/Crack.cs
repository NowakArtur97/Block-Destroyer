using UnityEngine;

public class Crack : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _hitSprites;
    [SerializeField]
    private Sprite _defaultSprite;

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

        spriteRenderer.sprite = healthLeft >= _hitSprites.Length ? _defaultSprite : _hitSprites[healthLeft];
    }

    public void RevertChanges() => spriteRenderer.sprite = _defaultSprite;
}
