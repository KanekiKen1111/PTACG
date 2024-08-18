using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [Header("Health Pickup Settings")]
    public float restoreAmount = 100f; // Amount of health to restore
    public GameObject pickupText; // UI text object to show the pickup message

    private Health playerHealth; // Reference to the player's Health script

    private void Start()
    {
        if (pickupText != null)
        {
            pickupText.SetActive(false); // Hide the pickup text initially
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the trigger zone
        if (other.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<Health>();

            if (playerHealth != null)
            {
                if (pickupText != null)
                {
                    pickupText.SetActive(true); // Show the pickup text
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player has exited the trigger zone
        if (other.CompareTag("Player"))
        {
            if (pickupText != null)
            {
                pickupText.SetActive(false); // Hide the pickup text
            }
        }
    }

    private void Update()
    {
        if (playerHealth != null && Input.GetKeyDown(KeyCode.E))
        {
            // Log the current health before using the pickup
            Debug.LogWarning("Current Health before pickup: " + playerHealth.CurrentHealth);

            // Restore the player's health
            playerHealth.CurrentHealth = playerHealth.maxHealth; // Set health to full

            // Call UpdateHealth on UIManager to update the UI
            UIManager.Instance.UpdateHealth(playerHealth.CurrentHealth,
                                            playerHealth.maxHealth,
                                            UIManager.Instance.playerCurrentShield,
                                            UIManager.Instance.playerMaxShield);

            // Log the current health after using the pickup
            Debug.LogWarning("Current Health after pickup: " + playerHealth.CurrentHealth);

            // Destroy the health pickup object
            Destroy(gameObject);
        }
    }
}
