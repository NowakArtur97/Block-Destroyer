using System;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    private float damageDealt = 1f;

    public void SetDamage(float damageDealt)
    {
        this.damageDealt = damageDealt;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            AttackBlock(collision);
        }
    }

    private void AttackBlock(Collision2D collision)
    {
        GameObject block = collision.gameObject;

        block.GetComponent<Health>().DealDamage(damageDealt);

        if (!block.GetComponent<Health>().IsDead())
        {
            block.GetComponent<Crack>().CrackObject(damageDealt);
        }
        else
        {
            block.GetComponent<Health>().Die();
        }
    }
}
