using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public DoorController doorController;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorController.SetDoorState(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        // Reset the flag when the object exits the trigger
        if (other.CompareTag("Player"))
        {
            doorController.SetDoorState(false);
        }
    }


}
