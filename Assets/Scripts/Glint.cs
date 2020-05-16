using UnityEngine;

public class Glint : MonoBehaviour
{
    [SerializeField]
    private GameObject glintVFX;
    [SerializeField]
    private float durationOfGlint = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GlintObject();
    }

    private void GlintObject()
    {
        GameObject glint = Instantiate(glintVFX, transform.position, transform.rotation);
        Destroy(glint, durationOfGlint);
    }
}
