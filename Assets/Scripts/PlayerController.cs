using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float respawnDelay = 1f; // Time delay before respawning (if needed)
    private Rigidbody2D rb;         // Reference to the Rigidbody2D component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Call this method to respawn the player
    public void Respawn()
    {
        if (CheckpointManager.Instance.GetCheckpoint() != null)
        {
            // Optionally, you can add a delay before respawning
            Invoke("PerformRespawn", respawnDelay);
        }
        else
        {
            Debug.LogWarning("No checkpoint set. Respawn failed.");
        }
    }

    // Perform the actual respawn
    private void PerformRespawn()
    {
        // Set the player's position to the last checkpoint
        transform.position = CheckpointManager.Instance.GetCheckpoint().position;

        // Reset player velocity and other properties if needed
        rb.velocity = Vector2.zero;
        // Reset health or other properties here if needed
    }
}
