using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PartyLighting : MonoBehaviour
{
    [SerializeField]
    private float minimumAngle = 0.3f;
    [SerializeField]
    private float maximumAngle = 0.6f;
    [SerializeField]
    private float rotationSpeed = 30f;
    [SerializeField]
    private int mainDirection = 1;

    private int rotationDirection = 1;

    private Light2D light;

    private void Start()
    {
        light = GetComponent<Light2D>();
    }

    void Update()
    {
        RotateLighting();

        ChangeColorLighting();
    }

    private void ChangeColorLighting()
    {
        light.color = Random.ColorHSV();
    }

    private void RotateLighting()
    {
        if (Mathf.Abs(transform.rotation.z) < Mathf.Abs(minimumAngle))
        {
            rotationDirection = -mainDirection;
        }
        else if (Mathf.Abs(transform.rotation.z) > Mathf.Abs(maximumAngle))
        {
            rotationDirection = mainDirection;
        }
        transform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime * rotationDirection;
    }
}
