using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField]
    private float destroyNewPowerUpDelay = 10f;
    [SerializeField]
    private float minSpawnDelay = 5f;
    [SerializeField]
    private float maxSpawnDelay = 10f;
    [SerializeField]
    private float minSpawnXPosition = 1f;
    [SerializeField]
    private float maxSpawnXPosition = 20f;
    [SerializeField]
    private float minSpawnYPosition = 5f;
    [SerializeField]
    private float maxSpawnYPosition = 10f;
    [SerializeField]
    private PowerUp powerUp;

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
        Vector2 powerUpPosition = new Vector2(Random.Range(minSpawnXPosition, maxSpawnXPosition), Random.Range(minSpawnYPosition, maxSpawnYPosition));

        PowerUp newPowerUp = Instantiate(powerUp, powerUpPosition, Quaternion.identity) as PowerUp;

        Destroy(newPowerUp.gameObject, destroyNewPowerUpDelay);
    }
}
