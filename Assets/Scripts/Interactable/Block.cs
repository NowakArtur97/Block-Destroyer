using UnityEngine;

public class Block : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<GameSession>().LoadBlocks(this);
    }
}
