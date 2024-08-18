using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public int damageAmount = 1; // Amount of damage to inflict

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Log the name of the object this projectile collided with
        Debug.Log("Projectile collided with: " + collider.gameObject.name);

        // Check if the collided object has the "Player" tag
        if (collider.CompareTag("Player"))
        {
            // Log when hitting the player
            Debug.Log("Projectile hit the player!");

            // Get the Health component from the collided object
            Health health = collider.GetComponent<Health>();
            if (health != null)
            {
                // Apply damage to the health component
                health.TakeDamage(damageAmount);
                Debug.Log("Damage applied: " + damageAmount);
            }
            else
            {
                Debug.LogWarning("Player does not have a Health component.");
            }

            // Destroy the projectile after applying damage
            Destroy(gameObject);
        }
        else
        {
            // Optionally, destroy the projectile if it hits something that's not the player
            Debug.Log("Projectile hit something other than the player.");
            Destroy(gameObject);
        }
    }
}
