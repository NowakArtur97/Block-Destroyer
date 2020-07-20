using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Canvas menuCanvas;

    private int _currentSceneIndex;

    private void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void PlayLevel()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();
        gameSession.IsAutoPlayEnabled = false;
        gameSession.InstantiateBlocks();
        menuCanvas.enabled = false;
    }

    public void LoadNextLevel()
    {
        ++_currentSceneIndex;

        if (SceneManager.sceneCountInBuildSettings <= _currentSceneIndex)
        {
            _currentSceneIndex = 0;
        }

        SceneManager.LoadScene(_currentSceneIndex);
    }

    public void LoadPreviousLevel()
    {
        --_currentSceneIndex;

        if (0 > _currentSceneIndex)
        {
            _currentSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        }

        SceneManager.LoadScene(_currentSceneIndex);
    }

    public void RestartLevel() => SceneManager.LoadScene(_currentSceneIndex);

    public void QuiGame() => Application.Quit();
}
