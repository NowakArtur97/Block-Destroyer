using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    [SerializeField]
    private float backgroundMovingSpeed = 0.5f;

    private Material material;
    private Vector2 offset;

    private void Start()
    {
        material = GetComponent<Renderer>().material;

        offset = new Vector2(backgroundMovingSpeed, 0);
    }

    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
