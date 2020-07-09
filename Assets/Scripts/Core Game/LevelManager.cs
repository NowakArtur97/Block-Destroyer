using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentSceneIndex;

    private void Start()
    {
        int numberOfLevelManagers = FindObjectsOfType<LevelManager>().Length;

        if (numberOfLevelManagers > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
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
