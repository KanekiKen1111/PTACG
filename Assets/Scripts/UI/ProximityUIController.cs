using UnityEngine;

public class ProximityUIController2D : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject interactionPromptUI; // Reference to the UI that shows interaction prompt
    public GameObject interactionCanvas;   // Reference to the canvas to show when interacting

    private bool isPlayerNearby = false; // Flag to check if the player is nearby

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ShowInteractionCanvas();
        }

        if (interactionCanvas.activeSelf && Input.GetKeyDown(KeyCode.C))
        {
            HideInteractionCanvas();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactionPromptUI != null)
            {
                interactionPromptUI.SetActive(true); // Show interaction prompt when player is nearby
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (interactionPromptUI != null)
            {
                interactionPromptUI.SetActive(false); // Hide interaction prompt when player leaves
            }
        }
    }

    private void ShowInteractionCanvas()
    {
        if (interactionCanvas != null)
        {
            interactionCanvas.SetActive(true); // Show the interaction canvas
        }
    }

    private void HideInteractionCanvas()
    {
        if (interactionCanvas != null)
        {
            interactionCanvas.SetActive(false); // Hide the interaction canvas
        }
    }
}
