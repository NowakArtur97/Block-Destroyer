using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float _paddleYPosition = 1f;
    [SerializeField]
    private float _minX = 1.4f;
    [SerializeField]
    private float _maxX = 20f;

    private GameSession gameSession;
    private Ball ball;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();

        CalculatePaddleMinAndMaxPosition();

        if (gameSession.IsAutoPlayEnabled())
        {
            ball = FindObjectOfType<Ball>();
        }
    }

    private void CalculatePaddleMinAndMaxPosition()
    {
        _minX = GetComponent<SpriteRenderer>().bounds.size.x / 2;

        _maxX = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x - _minX;
    }

    private void Update()
    {
        Vector3 mousePosInWorldUnits = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 paddlePosition = new Vector2(mousePosInWorldUnits.x, _paddleYPosition);

        paddlePosition.x = Mathf.Clamp(GetXPosition(paddlePosition), _minX, _maxX);
        transform.position = paddlePosition;
    }

    private float GetXPosition(Vector2 paddlePosition)
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return paddlePosition.x;
        }
    }

    internal void Scale(float scale)
    {
        transform.localScale = new Vector3(scale, scale, scale);

        CalculatePaddleMinAndMaxPosition();
    }
}
