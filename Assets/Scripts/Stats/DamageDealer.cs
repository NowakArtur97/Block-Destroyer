using System;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    private float damageDealt = 1f;
    [SerializeField]
    private float defaultDamageDealt = 1f;

    public void SetDamage(float damageDealt)
    {
        this.damageDealt = damageDealt;
    }

    public void ResetDamage()
    {
        damageDealt = defaultDamageDealt;
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

        if (block.GetComponent<Health>().IsDead())
        {
            block.GetComponent<Health>().Die();
        }
        else
        {
            block.GetComponent<Crack>().CrackObject();
        }
    }
}
