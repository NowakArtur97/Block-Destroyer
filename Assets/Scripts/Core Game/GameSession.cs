using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    private bool isAutoPlayEnabled = true;
    [SerializeField]
    private Ball ball;

    private LevelManager levelManager;

    private bool hasGameStarted = false;

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
        hasGameStarted = false;

        Instantiate(ball, new Vector3(1, 1, 0), Quaternion.identity);
    }

    private bool IsGameAWin() => numberOfBreakableBlocks <= 0;

    public bool IsAutoPlayEnabled() => isAutoPlayEnabled;

    public void SetAutoPlayEnabled(bool value) => isAutoPlayEnabled = value;

    public bool HasGameStarted() => hasGameStarted;

    public void SetGameHasStarted(bool gameHasStarted) => this.hasGameStarted = gameHasStarted;
}
