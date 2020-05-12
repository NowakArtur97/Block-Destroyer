using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Paddle mainPaddle;

    private Vector2 ballStartingPos;

    private void Start()
    {
        ballStartingPos = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        Vector2 paddlePos = new Vector2(mainPaddle.transform.position.x, ballStartingPos.y);
        transform.position = paddlePos;
    }
}
