using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Door : MonoBehaviour
{
    public string requiredKey = "SilverKey"; // The name of the key required to open the door
    public Text doorMessage; // Reference to the UI Text element for displaying messages
    public float messageDisplayTime = 2f; // Duration to display the door message
    public DoorController doorController; // Reference to the DoorController script
    public GameObject objectToDestroy; // GameObject to destroy when door is opened

    private bool isPlayerNearby = false;
    private bool isMessageShowing = false;
    private InventoryManager inventoryManager;
    private Coroutine messageCoroutine;

    void Start()
    {
        doorMessage.gameObject.SetActive(false); // Hide the message initially
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            TryOpenDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (!isMessageShowing)
            {
                ShowDoorMessage();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            HideDoorMessage();
        }
    }

    private void ShowDoorMessage()
    {
        isMessageShowing = true;

        // Check if the player has the required key
        InventoryManager.KeyData keyData = inventoryManager.keys.Find(k => k.keyName == requiredKey);

        if (keyData != null && keyData.keyCount > 0)
        {
            // Display message to open door with the key
            doorMessage.text = $"Press 'E' to open the door with {requiredKey}";
        }
        else
        {
            // Display message that key is not found
            doorMessage.text = $"Key not found: {requiredKey}";
        }

        doorMessage.gameObject.SetActive(true);

        // Start coroutine to hide message after some time
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
        }
        messageCoroutine = StartCoroutine(HideMessageAfterDelay());
    }

    private IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDisplayTime);
        HideDoorMessage();
    }

    private void HideDoorMessage()
    {
        isMessageShowing = false;
        doorMessage.gameObject.SetActive(false);
    }

    private void TryOpenDoor()
    {
        // Check if the player has the required key
        InventoryManager.KeyData keyData = inventoryManager.keys.Find(k => k.keyName == requiredKey);

        if (keyData != null && keyData.keyCount > 0)
        {
            // Open the door
            doorController.SetDoorState(true);
            // Remove one key from the inventory
            keyData.keyCount--;
            // Update the panel text
            inventoryManager.UpdateKeyCountText(requiredKey);

            // Destroy the specified GameObject
            if (objectToDestroy != null)
            {
                Destroy(objectToDestroy);
            }

            // Hide the message
            HideDoorMessage();
        }
        else
        {
            // Display key not found message
            ShowDoorMessage();
        }
    }
}
