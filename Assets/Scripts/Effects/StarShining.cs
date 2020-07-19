using System.Collections;
using UnityEngine;

public class StarShining : MonoBehaviour
{
    [SerializeField]
    private float _minTimeBeforeShining = 0f;
    [SerializeField]
    private float _maxTimeBeforeShining = 2f;

    private void Start()
    {
        GetComponent<Animator>().enabled = false;
        StartCoroutine(StartShiningCoroutine());
    }

    private IEnumerator StartShiningCoroutine()
    {
        float random = Random.Range(_minTimeBeforeShining, _maxTimeBeforeShining);
        yield return new WaitForSeconds(random);
        GetComponent<Animator>().enabled = true;
    }
}
