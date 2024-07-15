using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 10f; // Amount of damage this projectile deals

    void OnTriggerEnter2D(Collider2D collider)
    {
        GuardHealth guardHealth = collider.gameObject.GetComponent<GuardHealth>();
        if (guardHealth != null)
        {
            Debug.Log("Fireball collided with: " + collider.gameObject.name);
            guardHealth.TakeDamage(damageAmount);
            Destroy(gameObject); // Destroy the projectile after dealing damage
        }
        else
        {
            Debug.Log("Fireball collided with a non-guard object: " + collider.gameObject.name);
        }
    }
}
