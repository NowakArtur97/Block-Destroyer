using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            FindObjectOfType<LevelManager>().RestartLevel();
        }
    }
}