using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] soundTrack;

    private AudioSource audioSource;
    private AudioClip song;

    private void Start()
    {
        int numberOfMusicPlayers = FindObjectsOfType<Music>().Length;

        if (numberOfMusicPlayers > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        song = soundTrack[SceneManager.GetActiveScene().buildIndex];

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(song);
        }
    }
}
