using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    [SerializeField]
    private float _backgroundMovingSpeed = 0.5f;

    private Material material;
    private Vector2 offset;

    private void Start()
    {
        material = GetComponent<Renderer>().material;

        offset = new Vector2(_backgroundMovingSpeed, 0);
    }

    void Update() => material.mainTextureOffset += offset * Time.deltaTime;
}
