using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(++currentSceneIndex);
    }

    public void RestartLevel()
    {
        Debug.Log("Restart Level");
        SceneManager.LoadScene(currentSceneIndex);
    }
}
