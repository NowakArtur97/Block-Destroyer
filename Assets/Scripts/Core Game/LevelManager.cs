using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Canvas menuCanvas;

    private int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void PlayLevel()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();
        gameSession.SetAutoPlayEnabled(false);
        gameSession.InstantiateBlocks();
        menuCanvas.enabled = false;
    }

    public void LoadNextLevel()
    {
        ++currentSceneIndex;

        if (SceneManager.sceneCountInBuildSettings <= currentSceneIndex)
        {
            currentSceneIndex = 0;
        }

        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadPreviousLevel()
    {
        --currentSceneIndex;

        if (0 > currentSceneIndex)
        {
            currentSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        }

        SceneManager.LoadScene(currentSceneIndex);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}
