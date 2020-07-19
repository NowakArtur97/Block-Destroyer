using System;
using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private Power _power;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        spriteRenderer.sprite = _power.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (HasPlayerPickedUpPowerUp(collision))
        {
            StartCoroutine(PickuUpCoroutine());
        }
    }

    private IEnumerator PickuUpCoroutine()
    {
        switch (_power.type)
        {
            case PowerType.ATTACK:
                yield return ActivatePowerTypePowerUpCoroutine();
                break;
            case PowerType.HEALTH:
                ActivateHealthTypePowerUpCoroutine();
                break;
            case PowerType.SIZE:
                yield return ActivateSizeTypePowerUpCoroutine();
                break;
            case PowerType.SPEED:
                yield return ActivateSpeedTypePowerUpCoroutine();
                break;
            default:
                throw new NotImplementedException();
        }

        Destroy(gameObject);
    }

    private void ActivateHealthTypePowerUpCoroutine()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player Health");

        Health playerHealth = player.GetComponent<Health>();

        playerHealth.RestoreHeatlh(_power.value);

        player.GetComponent<Crack>().ChangeState();
    }

    private IEnumerator ActivateSpeedTypePowerUpCoroutine()
    {
        Ball ball = FindObjectOfType<Ball>();

        ball.GetComponent<Rigidbody2D>().velocity *= _power.value;

        ball.ToggleElectrified();

        yield return new WaitForSecondsRealtime(_power.duration);

        ball.ToggleElectrified();

        ball.GetComponent<Rigidbody2D>().velocity /= _power.value;
    }

    private IEnumerator ActivateSizeTypePowerUpCoroutine()
    {
        Paddle paddle = FindObjectOfType<Paddle>();

        paddle.Scale(_power.value);

        yield return new WaitForSecondsRealtime(_power.duration);

        paddle.Scale(1);
    }

    private IEnumerator ActivatePowerTypePowerUpCoroutine()
    {
        Ball ball = FindObjectOfType<Ball>();

        DamageDealer damageDealer = ball.GetComponent<DamageDealer>();

        damageDealer.SetDamage(_power.value);

        ball.ToggleBurning();

        yield return new WaitForSecondsRealtime(_power.duration);

        ball.ToggleBurning();

        damageDealer.ResetDamage();
    }

    private bool HasPlayerPickedUpPowerUp(Collider2D collision) => collision.CompareTag("Paddle");
}
