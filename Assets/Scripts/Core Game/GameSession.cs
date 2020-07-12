using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    private bool isAutoPlayEnabled = true;
    [SerializeField]
    private Ball ball;

    private bool hasGameStarted = false;

    private int numberOfBreakableBlocks;

    private List<Block> allBlocks = new List<Block>();

    public void LoadBlocks(Block block)
    {
        numberOfBreakableBlocks++;
        allBlocks.Add(block);
    }

    public void BlockDestroyed()
    {
        if (hasGameStarted)
        {
            numberOfBreakableBlocks--;
        }
    }

    private void Update()
    {
        if (IsGameAWin() && hasGameStarted)
        {
            FindObjectOfType<LevelManager>().LoadNextLevel();
        }
    }

    public void RestartGame()
    {
        hasGameStarted = false;

        Instantiate(ball, new Vector3(1, 1, 0), Quaternion.identity);
    }

    public void InstantiateBlocks()
    {
        foreach (Block block in allBlocks)
        {
            block.gameObject.SetActive(true);
            block.GetComponent<Health>()?.RestoreMaxHealth();
            block.GetComponent<Crack>()?.RevertChanges();
        }
    }

    private bool IsGameAWin() => numberOfBreakableBlocks <= 0;

    public bool IsAutoPlayEnabled() => isAutoPlayEnabled;

    public void SetAutoPlayEnabled(bool value) => isAutoPlayEnabled = value;

    public bool HasGameStarted() => hasGameStarted;

    public void SetGameHasStarted(bool hasGameStarted)
    {
        this.hasGameStarted = hasGameStarted;
    }
}
