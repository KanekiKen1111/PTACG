using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class GuardHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Maximum health of the guard
    public float currentHealth; // Current health of the guard
    public Slider healthBar; // Reference to the UI Slider for the health bar

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth; // Set the maximum value of the health bar
            healthBar.value = currentHealth; // Set the initial value of the health bar
        }
    }

    // Method to take damage
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }

        // Update the health bar
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
    }

    // Method called when health reaches zero
    void Die()
    {
        Debug.Log("Guard has died.");
        // Add logic here for what happens when the guard dies
        // For example: playing a death animation, removing the guard, etc.
        Destroy(gameObject); // Destroy the guard GameObject
    }
}
