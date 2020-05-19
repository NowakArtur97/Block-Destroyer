using UnityEngine;

public class Ball : MonoBehaviour
{
    private const string BURNING_ANIMATION_STATE = "IsBurning";

    [SerializeField]
    private Paddle mainPaddle;
    [SerializeField]
    private float xPush = 0f;
    [SerializeField]
    private float yPush = 15f;
    [SerializeField]
    private AudioClip[] sounds;

    private Vector2 ballStartingPos;
    private bool gameHasStarted = false;

    private Animator animator;

    private AudioSource audioSource;

    private void Start()
    {
        ballStartingPos = new Vector2(transform.position.x, transform.position.y);

        audioSource = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameHasStarted)
        {
            PlayRandomSound();
            Burn();
        }
    }

    private void Burn()
    {
        bool isBurning = animator.GetBool(BURNING_ANIMATION_STATE);
        animator.SetBool(BURNING_ANIMATION_STATE, !isBurning);
    }

    private void PlayRandomSound()
    {
        AudioClip randomSound = sounds[Random.Range(0, sounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }
}
