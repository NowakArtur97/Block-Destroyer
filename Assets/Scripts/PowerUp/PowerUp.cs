using System;
using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private Power power;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
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
                yield return ActivateSizeTypePowerUp();
                break;
            case PowerType.SPEED:
                yield return ActivateSpeedTypePowerUp();
                break;
            default:
                throw new NotImplementedException();
        }

        Destroy(gameObject);
    }

    private IEnumerator ActivateSpeedTypePowerUp()
    {
        Ball ball = FindObjectOfType<Ball>();

        ball.GetComponent<Rigidbody2D>().velocity *= power.value;

        yield return new WaitForSecondsRealtime(power.duration);

        ball.GetComponent<Rigidbody2D>().velocity /= power.value;
    }

    private IEnumerator ActivateSizeTypePowerUp()
    {
        Paddle paddle = FindObjectOfType<Paddle>();

        paddle.Scale(power.value);

        yield return new WaitForSecondsRealtime(power.duration);

        paddle.Scale(1);
    }

    private IEnumerator ActivatePowerTypePowerUp()
    {
        Ball ball = FindObjectOfType<Ball>();

        DamageDealer damageDealer = ball.GetComponent<DamageDealer>();

        damageDealer.SetDamage(power.value);
        ball.ToggleBurning();
        yield return new WaitForSecondsRealtime(power.duration);
        ball.ToggleBurning();
        damageDealer.ResetDamage();
    }
}
