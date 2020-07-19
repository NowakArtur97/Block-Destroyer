using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField]
    private float _destroyNewPowerUpDelay = 10f;
    [SerializeField]
    private float _minSpawnDelay = 6f;
    [SerializeField]
    private float _maxSpawnDelay = 8f;
    [SerializeField]
    private float _minSpawnXPosition = 1f;
    [SerializeField]
    private float _maxSpawnXPosition = 20f;
    [SerializeField]
    private float _minSpawnYPosition = 5f;
    [SerializeField]
    private float _maxSpawnYPosition = 10f;
    [SerializeField]
    private PowerUp[] _powerUps;

    private bool _isSpawning = false;

    private GameSession gameSession;

    private void Start() => gameSession = FindObjectOfType<GameSession>();

    private void Update()
    {
        if (gameSession.HasGameStarted() && !_isSpawning)
        {
            StartCoroutine(SpawningCoroutine());
        }
    }

    private IEnumerator SpawningCoroutine()
    {
        _isSpawning = true;

        yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));

        _isSpawning = false;

        Spawn();
    }

    private void Spawn()
    {
        Vector2 powerUpPosition = new Vector2(Random.Range(_minSpawnXPosition, _maxSpawnXPosition), Random.Range(_minSpawnYPosition, _maxSpawnYPosition));

        PowerUp newPowerUp = Instantiate(_powerUps[Random.Range(0, _powerUps.Length)], powerUpPosition, Quaternion.identity) as PowerUp;

        Destroy(newPowerUp.gameObject, _destroyNewPowerUpDelay);
    }
}
