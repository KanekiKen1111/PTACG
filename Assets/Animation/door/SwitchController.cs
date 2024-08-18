using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public DoorController doorController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorController.SetDoorState(true);
        }
    }
}
