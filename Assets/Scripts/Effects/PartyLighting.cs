using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PartyLighting : MonoBehaviour
{
    [SerializeField]
    private float timeLeftUntillChange = 1;

    private Light2D light;
    private Color targetColor;

    private void Start()
    {
        light = GetComponent<Light2D>();

        targetColor = new Color(Random.value, Random.value, Random.value);
    }

    void Update()
    {
        ChangeColorLighting();
    }

    private void ChangeColorLighting()
    {
        if (timeLeftUntillChange <= Time.deltaTime)
        {
            light.color = targetColor;

            targetColor = new Color(Random.value, Random.value, Random.value);
            timeLeftUntillChange = 1.0f;
        }
        else
        {
            light.color = Color.Lerp(light.color, targetColor, Time.deltaTime / timeLeftUntillChange);

            timeLeftUntillChange -= Time.deltaTime;
        }
    }
}
