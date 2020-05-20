using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField]
    private float minSpawnDelay = 5f;
    [SerializeField]
    private float maxSpawnDelay = 10f;

    private bool isSpawning = false;

    private GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void Update()
    {
        if (gameSession.HasGameStarted() && !isSpawning)
        {
            StartCoroutine(SpawningCoroutine());
        }
    }

    private IEnumerator SpawningCoroutine()
    {
        isSpawning = true;

        yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));

        isSpawning = false;

        Spawn();
    }

    private void Spawn()
    {
        Debug.Log("Time to spawn");
    }
}
