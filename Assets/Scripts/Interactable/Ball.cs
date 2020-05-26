using UnityEngine;

public class Ball : MonoBehaviour
{
    private const string BURNING_ANIMATION_STATE = "IsBurning";

    [SerializeField]
    private float distanceFromPaddle = 0.5f;
    [SerializeField]
    private float xPush = 1f;
    [SerializeField]
    private float yPush = 15f;
    [SerializeField]
    private AudioClip[] sounds;

    private Vector2 ballToPaddleVector;

    private Paddle mainPaddle;

    private Animator animator;
    private AudioSource audioSource;
    private GameSession gameSession;

    private GameObject ballBody;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();

        gameSession = FindObjectOfType<GameSession>();

        mainPaddle = FindObjectOfType<Paddle>();

        ballBody = transform.GetChild(0).gameObject;

        ballToPaddleVector = new Vector2(mainPaddle.transform.position.x, mainPaddle.transform.position.y + distanceFromPaddle);
    }

    void Update()
    {
        if (!gameSession.HasGameStarted())
        {
            LockBallToPaddle();
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameSession.SetGameHasStarted(true);

            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(mainPaddle.transform.position.x, ballToPaddleVector.y);

        transform.position = paddlePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameSession.HasGameStarted())
        {
            PlayRandomSound();

            if (animator.GetBool(BURNING_ANIMATION_STATE))
            {
                TurnOtherWayToCollision(collision);
            }
        }
    }

    private void TurnOtherWayToCollision(Collision2D collision)
    {
        Vector3 contactPoint = collision.contacts[0].point;
        Vector3 direction = contactPoint - ballBody.transform.position;
        ballBody.transform.up = direction;
    }

    public void ToggleBurning()
    {
        animator.SetBool(BURNING_ANIMATION_STATE, !animator.GetBool(BURNING_ANIMATION_STATE));
    }

    private void PlayRandomSound()
    {
        AudioClip randomSound = sounds[Random.Range(0, sounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }
}
