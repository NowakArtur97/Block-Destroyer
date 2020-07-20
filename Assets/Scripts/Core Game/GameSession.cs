using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    public bool IsAutoPlayEnabled { get; set; } = true;
    [SerializeField]
    private Ball _ball;

    public bool HasGameStarted { get; set; } = false;

    private int _numberOfBreakableBlocks;

    private List<Block> _allBlocks = new List<Block>();

    public void LoadBlocks(Block block)
    {
        _numberOfBreakableBlocks++;
        _allBlocks.Add(block);
    }

    public void BlockDestroyed()
    {
        if (HasGameStarted)
        {
            _numberOfBreakableBlocks--;
        }
    }

    private void Update()
    {
        if (IsGameAWin() && HasGameStarted)
        {
            FindObjectOfType<LevelManager>().LoadNextLevel();
        }
    }

    public void RestartGame()
    {
        HasGameStarted = false;

        Instantiate(_ball, new Vector3(1, 1, 0), Quaternion.identity);
    }

    public void InstantiateBlocks()
    {
        foreach (Block block in _allBlocks)
        {
            block.gameObject.SetActive(true);
            block.GetComponent<Health>()?.RestoreMaxHealth();
            block.GetComponent<Crack>()?.RevertChanges();
        }
    }

    private bool IsGameAWin() => _numberOfBreakableBlocks <= 0;
}
