using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance; // Singleton instance

    private Transform currentCheckpoint; // The current checkpoint position

    private void Awake()
    {
        // Ensure there's only one instance of CheckpointManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); // Optional: Make this manager persist across scenes
    }

    // Set the current checkpoint
    public void SetCheckpoint(Transform checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    // Get the current checkpoint
    public Transform GetCheckpoint()
    {
        return currentCheckpoint;
    }
}

