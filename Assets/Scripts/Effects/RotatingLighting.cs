using UnityEngine;

public class RotatingLighting : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 30f;
    [SerializeField]
    private Vector3 beginAngles;
    [SerializeField]
    private Vector3 endAngles;

    private Vector3 angles;

    private void Start()
    {
        transform.localEulerAngles = beginAngles;
    }

    void Update()
    {
        RotateLighting();
    }

    private void RotateLighting()
    {
        angles.z = Mathf.PingPong(Time.time * rotationSpeed, endAngles.z) - beginAngles.z;

        transform.localEulerAngles = angles;
    }
}
