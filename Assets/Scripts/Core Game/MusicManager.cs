using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _soundTrack;

    private AudioSource audioSource;
    private AudioClip song;

    private void Start()
    {
        song = _soundTrack[SceneManager.GetActiveScene().buildIndex];

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!audioSource.isPlaying) audioSource.PlayOneShot(song);
    }
}
