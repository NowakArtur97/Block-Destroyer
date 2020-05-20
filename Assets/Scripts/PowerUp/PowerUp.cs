using System;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Paddle"))
        {
            Pickup();
        }
    }

    private void Pickup()
    {

    }
}
