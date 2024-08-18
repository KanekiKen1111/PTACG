using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public Transform startPoint; // Start point of the projectile
    public Transform endPoint; // End point of the projectile
    public float projectileSpeed = 10f; // Speed of the projectile
    public float spawnInterval = 2f; // Time interval between projectile spawns
    public float destroyAfter = 5f; // Time after which the projectile should be destroyed

    private void Start()
    {
        if (projectilePrefab == null)
        {
            Debug.LogError("Projectile prefab is not assigned!");
            return;
        }

        if (startPoint == null || endPoint == null)
        {
            Debug.LogError("Start point or end point is not assigned!");
            return;
        }

        // Start the coroutine to spawn and move projectiles
        StartCoroutine(SpawnAndMoveProjectiles());
    }

    private IEnumerator SpawnAndMoveProjectiles()
    {
        while (true)
        {
            // Spawn the projectile
            GameObject projectile = Instantiate(projectilePrefab, startPoint.position, Quaternion.identity);
            ProjectileBehavior projectileBehavior = projectile.GetComponent<ProjectileBehavior>();

            if (projectileBehavior != null)
            {
                // Initialize the projectile movement
                projectileBehavior.Initialize(startPoint.position, endPoint.position, projectileSpeed, destroyAfter);
            }
            else
            {
                Debug.LogError("ProjectileBehavior script is missing from the prefab!");
            }

            // Wait for the specified interval before spawning the next projectile
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

