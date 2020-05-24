using UnityEngine;

public class ObjectCleaner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ObjectCleaner " + collision.gameObject.tag);
        if (collision.CompareTag("PowerUp"))
        {
            Destroy(collision.gameObject);
        }
    }
}
