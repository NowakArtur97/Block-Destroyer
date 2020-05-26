using System;
using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private Power power;

    private SpriteRenderer spriteRenderer;
    private Ball ball;
    private DamageDealer damageDealer;

    private bool isBurning = false;

    private Coroutine coroutine;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();

        damageDealer = ball.GetComponent<DamageDealer>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        spriteRenderer.sprite = power.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            StartCoroutine(Pickup());
        }
    }

    private IEnumerator Pickup()
    {
        switch (power.type)
        {
            case PowerType.ATTACK:
                yield return ActivatePowerTypePowerUp();
                break;
            case PowerType.HEALTH:
                break;
            case PowerType.SIZE:
                break;
            case PowerType.SPEED:
                break;
            default:
                throw new NotImplementedException();
        }

        Destroy(gameObject, 1);
    }

    private IEnumerator ActivatePowerTypePowerUp()
    {
        damageDealer.SetDamage(power.value);
        ball.ToggleBurning();
        yield return new WaitForSecondsRealtime(power.duration);
        ball.ToggleBurning();
        damageDealer.ResetDamage();
    }
}
