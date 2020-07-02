using UnityEngine;

public class RotatingLighting : MonoBehaviour
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

    void Update()
    {
        RotateLighting();
    }

    private void RotateLighting()
    {
        //if (Mathf.Abs(transform.rotation.z) < Mathf.Abs(minimumAngle))
        //{
        //    rotationDirection = -mainDirection;
        //}
        //else if (Mathf.Abs(transform.rotation.z) > Mathf.Abs(maximumAngle))
        //{
        //    rotationDirection = mainDirection;
        //}
        transform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime * rotationDirection;

        //Debug.Log(transform.rotation.z);
    }
}
