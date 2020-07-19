using UnityEngine;

public class RotatingLighting : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 30f;
    [SerializeField]
    private Vector3 _beginAngles;
    [SerializeField]
    private Vector3 _endAngles;

    private Vector3 angles;

    private void Start() => transform.localEulerAngles = _beginAngles;

    private void Update() => RotateLighting();

    private void RotateLighting()
    {
        angles.z = Mathf.PingPong(Time.time * _rotationSpeed, _endAngles.z) - _beginAngles.z;

        transform.localEulerAngles = angles;
    }
}
