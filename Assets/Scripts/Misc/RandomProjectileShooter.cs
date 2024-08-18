using UnityEngine;
using System.Collections;

public class RandomProjectileShooter : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public Transform shootPoint; // The point from which the projectile will be shot
    public float projectileSpeed = 10f; // Speed of the projectile
    public float spawnInterval = 2f; // Time interval between projectile spawns

    private void Start()
    {
        if (projectilePrefab == null)
        {
            Debug.LogError("Projectile prefab is not assigned!");
            return;
        }

        if (shootPoint == null)
        {
            Debug.LogError("Shoot point is not assigned!");
            return;
        }

        // Start the coroutine to shoot projectiles at intervals
        StartCoroutine(ShootProjectiles());
    }

    private IEnumerator ShootProjectiles()
    {
        while (true)
        {
            // Spawn the projectile
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

            // Set the projectile's direction and speed
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Generate a random direction
                float randomAngle = Random.Range(0f, 360f);
                Vector2 direction = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

                // Apply force to the projectile
                rb.velocity = direction * projectileSpeed;
            }
            else
            {
                Debug.LogError("Projectile prefab does not have a Rigidbody2D component!");
            }

            // Wait for the specified interval before shooting the next projectile
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
