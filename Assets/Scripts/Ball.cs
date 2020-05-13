using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Paddle mainPaddle;
    [SerializeField]
    private float xPush = 0f;
    [SerializeField]
    private float yPush = 15f;

    private Vector2 ballStartingPos;
    private bool gameHasStarted = false;

    private void Start()
    {
        ballStartingPos = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        if (!gameHasStarted)
        {
            LockBallToPaddle();
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameHasStarted = true;

            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(mainPaddle.transform.position.x, ballStartingPos.y);

        transform.position = paddlePos;
    }
}
