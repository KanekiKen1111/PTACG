using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LogHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Maximum health of the guard
    public float currentHealth; // Current health of the guard
    public Slider healthBar; // Reference to the UI Slider for the health bar

    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth; // Set the maximum value of the health bar
            healthBar.value = currentHealth; // Set the initial value of the health bar
        }

        animator = GetComponent<Animator>(); // Get the Animator component
    }

    // Method to take damage
    public void TakeDamage(float damageAmount)
    {
        if (isDead) return; // Prevent further damage if already dead

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
        if (isDead) return; // Prevent multiple calls to Die()

        isDead = true; // Set the dead flag to true
        Debug.Log("Guard has died.");
        animator.SetBool("Die", true); // Trigger the death animation

        // Start the coroutine to wait for the animation to finish before destroying the object
        StartCoroutine(WaitForDeathAnimation());
    }

    private IEnumerator WaitForDeathAnimation()
    {
        // Wait until the animation is finished
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);

        // Destroy the guard GameObject
        Destroy(gameObject);
    }
}