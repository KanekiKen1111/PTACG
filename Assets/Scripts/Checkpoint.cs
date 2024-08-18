using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	
    public Transform checkpointPosition; // The position to respawn at

    // This method will be called when the player reaches this checkpoint
    public void ActivateCheckpoint()
    {
        CheckpointManager.Instance.SetCheckpoint(checkpointPosition);
    }
	private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        ActivateCheckpoint();
    }
}
}
