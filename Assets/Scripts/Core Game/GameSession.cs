using System;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    private bool isAutoPlayEnabled = false;
    [SerializeField]
    private Ball ball;

    private LevelManager levelManager;

    private bool gameHasStarted = false;

    private int numberOfBreakableBlocks;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void CountBlocks() => numberOfBreakableBlocks++;

    public void BlockDestroyed() => numberOfBreakableBlocks--;

    private void Update()
    {
        if (IsGameAWin())
        {
            levelManager.LoadNextLevel();
        }
    }

    public void RestartGame()
    {
        gameHasStarted = false;

        Instantiate(ball, new Vector3(1, 1, 0), Quaternion.identity);
    }

    private bool IsGameAWin() => numberOfBreakableBlocks <= 0;

    public bool IsAutoPlayEnabled() => isAutoPlayEnabled;

    public bool HasGameStarted() => gameHasStarted;

    public void SetGameHasStarted(bool gameHasStarted) => this.gameHasStarted = gameHasStarted;
}
