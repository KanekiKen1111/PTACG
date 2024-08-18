using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCollectible : MonoBehaviour
{
    protected CharacterController _playerComponent;

    // Contains the logic of the collectable 
    private void CollectLogic()
    {
        if (!CanBePicked())
        {
            return;
        }

        Collect();
    }

    // Override to add custom colletable behaviour
    protected virtual void Collect()
    {
        Debug.Log("This is working!!!");
        Destroy(gameObject);
    }

    // Returns if this colletable can pe picked, True if it is colliding with the player
    private bool CanBePicked()
    {
        return _playerComponent != null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {     
            _playerComponent = other.GetComponent<CharacterController>();
            CollectLogic();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _playerComponent = null;
    }
}