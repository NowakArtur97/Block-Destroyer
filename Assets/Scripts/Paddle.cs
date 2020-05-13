using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float paddleYPosition = 1f;
    [SerializeField]
    private float minX = 1.4f;
    [SerializeField]
    private float maxX= 20f;

    private void Update()
    {
        Vector3 mousePosInWorldUnits = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 paddlePos = new Vector2(mousePosInWorldUnits.x, paddleYPosition);

        paddlePos.x = Mathf.Clamp(paddlePos.x, minX, maxX);
        transform.position = paddlePos;
    }
}
