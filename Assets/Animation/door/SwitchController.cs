using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public DoorController doorController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        doorController.SetDoorState(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        doorController.SetDoorState(false);
    }
}
