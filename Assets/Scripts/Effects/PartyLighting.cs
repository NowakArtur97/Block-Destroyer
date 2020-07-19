using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PartyLighting : MonoBehaviour
{
    [SerializeField]
    private float _timeLeftUntillChange = 1;

    private Light2D light2d;
    private Color targetColor;

    private void Start()
    {
        light2d = GetComponent<Light2D>();

        targetColor = new Color(Random.value, Random.value, Random.value);
    }

    void Update() => ChangeColorLighting();

    private void ChangeColorLighting()
    {
        if (_timeLeftUntillChange <= Time.deltaTime)
        {
            light2d.color = targetColor;

            targetColor = new Color(Random.value, Random.value, Random.value);
            _timeLeftUntillChange = 1.0f;
        }
        else
        {
            light2d.color = Color.Lerp(light2d.color, targetColor, Time.deltaTime / _timeLeftUntillChange);

            _timeLeftUntillChange -= Time.deltaTime;
        }
    }
}
