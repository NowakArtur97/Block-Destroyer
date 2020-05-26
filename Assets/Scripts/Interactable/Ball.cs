using UnityEngine;

public class Ball : MonoBehaviour
{
    private const string BURNING_ANIMATION_STATE = "IsBurning";

    [SerializeField]
    private Paddle mainPaddle;
    [SerializeField]
    private float xPush = 1f;
    [SerializeField]
    private float yPush = 15f;
    [SerializeField]
    private AudioClip[] sounds;

    private Vector2 ballStartingPosition;

    private Animator animator;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private GameSession gameSession;

    private GameObject child;

    private void Start()
    {
        ballStartingPosition = new Vector2(transform.position.x, transform.position.y);

        audioSource = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        gameSession = FindObjectOfType<GameSession>();

        child = transform.GetChild(0).gameObject;
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
        Vector2 paddlePos = new Vector2(mainPaddle.transform.position.x, ballStartingPosition.y);

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
        Vector3 direction = contactPoint - child.transform.position;
        child.transform.up = direction;
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
