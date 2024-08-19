using UnityEngine;

public class BossDestructionHandler : MonoBehaviour
{
    public GameObject endingCanvas; // Reference to the ending canvas

    private void OnDestroy()
    {
        if (endingCanvas != null)
        {
            endingCanvas.SetActive(true);
        }
    }
}