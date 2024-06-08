using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public Text interactText; // Reference to the UI Text element
    public string message = "Press E to collect"; // Customizable message

    private bool isPlayerNearby = false;

    void Start()
    {
        // Ensure the text is initially hidden
        interactText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Collect();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            interactText.text = message;
            interactText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactText.gameObject.SetActive(false);
        }
    }

    private void Collect()
    {
        // Add logic for what happens when the object is collected
        Debug.Log("Object collected!");

        // Optionally, destroy the object or perform other actions
        Destroy(gameObject);

        // Hide the interaction text
        interactText.gameObject.SetActive(false);
    }
}
