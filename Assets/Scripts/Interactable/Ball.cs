using UnityEngine;

public class Ball : MonoBehaviour
{
    private const string BURNING_ANIMATION_STATE = "IsBurning";
    private const string ELECTRIFIED_ANIMATION_STATE = "IsElectrified";

    [SerializeField]
    private float _distanceFromPaddle = 0.5f;
    [SerializeField]
    private float _xPush = 1f;
    [SerializeField]
    private float _yPush = 15f;
    [SerializeField]
    private AudioClip[] _sounds;

    private Vector2 _ballToPaddleVector;

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

        _ballToPaddleVector = new Vector2(mainPaddle.transform.position.x, mainPaddle.transform.position.y + _distanceFromPaddle);

        GetComponent<Rigidbody2D>().velocity = new Vector2(_xPush, _yPush);
    }

    void Update()
    {
        if (!gameSession.IsAutoPlayEnabled)
        {
            if (!gameSession.HasGameStarted)
            {
                LockBallToPaddle();

                LaunchBall();
            }
        }
    }

    private void LaunchBall()
    {
        if (WasMouseButtonClicked())
        {
            gameSession.HasGameStarted = true;

            GetComponent<Rigidbody2D>().velocity = new Vector2(_xPush, _yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(mainPaddle.transform.position.x, _ballToPaddleVector.y);

        transform.position = paddlePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameSession.HasGameStarted)
        {
            PlayRandomSound();

            if (IsBallBurning())
            {
                TurnOppositeWayToCollision(collision);
            }
        }
    }

    private void TurnOppositeWayToCollision(Collision2D collision)
    {
        Vector3 contactPoint = collision.contacts[0].point;
        Vector3 direction = contactPoint - ballBody.transform.position;
        ballBody.transform.up = direction;
    }

    public void ToggleBurning() => animator.SetBool(BURNING_ANIMATION_STATE, !IsBallBurning());

    public void ToggleElectrified() => animator.SetBool(ELECTRIFIED_ANIMATION_STATE, !IsBallElectrified());

    private void PlayRandomSound()
    {
        AudioClip randomSound = _sounds[Random.Range(0, _sounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }

    private bool IsBallBurning() => animator.GetBool(BURNING_ANIMATION_STATE);

    private bool IsBallElectrified() => animator.GetBool(ELECTRIFIED_ANIMATION_STATE);

    private static bool WasMouseButtonClicked() => Input.GetMouseButtonDown(0);
}
