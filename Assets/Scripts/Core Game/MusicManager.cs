using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] soundTrack;

    private AudioSource audioSource;
    private AudioClip song;

    private void Start()
    {
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
