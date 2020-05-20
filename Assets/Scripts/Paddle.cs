using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float paddleYPosition = 1f;
    [SerializeField]
    private float minX = 1.4f;
    [SerializeField]
    private float maxX = 20f;

    private GameSession gameSession;
    private Ball ball;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();

        ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        Vector3 mousePosInWorldUnits = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 paddlePosition = new Vector2(mousePosInWorldUnits.x, paddleYPosition);

        paddlePosition.x = Mathf.Clamp(GetXPosition(paddlePosition), minX, maxX);
        transform.position = paddlePosition;
    }

    private float GetXPosition(Vector2 paddlePosition)
    {
        if (gameSession.IsAutoPlayEnabled() && gameSession.HasGameStarted())
        {
            return ball.transform.position.x;
        }
        else
        {
            return paddlePosition.x;
        }
    }
}
