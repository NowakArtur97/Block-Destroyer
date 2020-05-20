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
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private GameSession gameSession;

    private void Start()
    {
        ballStartingPosition = new Vector2(transform.position.x, transform.position.y);

        audioSource = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();

        rigidbody2D = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        gameSession = FindObjectOfType<GameSession>();
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
            animator.SetBool(BURNING_ANIMATION_STATE, true);

            PlayRandomSound();
            Burn();
        }
    }

    private void Burn()
    {
        //bool isBurning = animator.GetBool(BURNING_ANIMATION_STATE);
        //animator.SetBool(BURNING_ANIMATION_STATE, !isBurning);

        Vector2 moveDirection = rigidbody2D.velocity;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            spriteRenderer.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void PlayRandomSound()
    {
        AudioClip randomSound = sounds[Random.Range(0, sounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }
}
