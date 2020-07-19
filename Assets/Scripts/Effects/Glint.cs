using UnityEngine;

public class Glint : MonoBehaviour
{
    [SerializeField]
    private GameObject _glintVFX;
    [SerializeField]
    private float _durationOfGlint = 1f;

    private void OnCollisionEnter2D(Collision2D collision) => GlintObject();

    private void GlintObject()
    {
        GameObject glint = Instantiate(_glintVFX, transform.position, transform.rotation);
        Destroy(glint, _durationOfGlint);
    }
}
