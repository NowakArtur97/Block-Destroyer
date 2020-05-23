using UnityEngine;

[CreateAssetMenu(fileName = "New Power", menuName = "Power")]
public class Power : ScriptableObject
{
    public PowerType type;

    public Sprite sprite;

    public float value;
}
