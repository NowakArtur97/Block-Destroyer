using System.Collections;
using UnityEngine;

public class StarShining : MonoBehaviour
{
    [SerializeField]
    private float minTimeBeforeShining = 0f;
    [SerializeField]
    private float maxTimeBeforeShining = 2f;

    private void Start()
    {
        GetComponent<Animator>().enabled = false;
        StartCoroutine(StarLightAnimation());
    }

    private IEnumerator StarLightAnimation()
    {
        float random = Random.Range(minTimeBeforeShining, maxTimeBeforeShining);
        yield return new WaitForSeconds(random);
        GetComponent<Animator>().enabled = true;
    }
}
