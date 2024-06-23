using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // The target position where the player will be teleported to
    public Transform targetPosition;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Teleport the player to the target position
            other.transform.position = targetPosition.position;
        }
    }
}

