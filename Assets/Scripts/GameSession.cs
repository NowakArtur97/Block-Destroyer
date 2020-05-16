using System;
using UnityEngine;

public class GameSession : MonoBehaviour
{
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

    private bool IsGameAWin()
    {
        return numberOfBreakableBlocks <= 0;
    }
}
