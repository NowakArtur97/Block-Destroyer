using System;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    private bool isAutoPlayEnabled = false;
    [SerializeField]
    private Ball ball;

    private bool gameHasStarted = false;

    private int numberOfBreakableBlocks;

    public void CountBlocks()
    {
        numberOfBreakableBlocks++;
    }

    public void BlockDestroyed()
    {
        numberOfBreakableBlocks--;
    }

    private void Update()
    {
        if (IsGameAWin())
        {
            Debug.Log("Load Next Level");
            throw new NotImplementedException("Add after creating more levels");
            //FindObjectOfType<LevelManager>().LoadNextLevel();
        }
    }

    public void RestartGame()
    {
        gameHasStarted = false;

        Instantiate(ball, new Vector3(1, 1, 0), Quaternion.identity);
    }

    private bool IsGameAWin()
    {
        return numberOfBreakableBlocks <= 0;
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public bool HasGameStarted()
    {
        return gameHasStarted;
    }

    public void SetGameHasStarted(bool gameHasStarted)
    {
        this.gameHasStarted = gameHasStarted;
    }
}
