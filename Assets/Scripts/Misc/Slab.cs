using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Slab : MonoBehaviour
{
    public string requiredKey = "SilverKey"; // The name of the key required
    public Text messageText; // Reference to the UI Text element for displaying messages
    public float messageDisplayTime = 2f; // Duration to display the message
    public GameObject objectToActivate; // The GameObject to activate when the key is used

    private bool isPlayerNearby = false;
    private bool isMessageShowing = false;
    private InventoryManager inventoryManager;
    private Coroutine messageCoroutine;

    void Start()
    {
        messageText.gameObject.SetActive(false); // Hide the message initially
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            UseKey();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("Player entered slab's trigger zone.");
            if (!isMessageShowing)
            {
                DisplayMessage();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            Debug.Log("Player exited slab's trigger zone.");
            HideMessage();
        }
    }

    private void DisplayMessage()
    {
        isMessageShowing = true;

        // Check if the player has the required key
        InventoryManager.KeyData keyData = inventoryManager.keys.Find(k => k.keyName == requiredKey);

        if (keyData != null && keyData.keyCount > 0)
        {
            // Display message to place the key
            messageText.text = $"Press 'E' to place the {requiredKey}";
            Debug.Log($"{requiredKey} found in inventory. Prompting player to place the key.");
        }
        else
        {
            // Display message that the key is required
            messageText.text = $"Requires: {requiredKey}";
            Debug.Log($"{requiredKey} not found in inventory. Prompting player that the key is required.");
        }

        messageText.gameObject.SetActive(true);

        // Start coroutine to hide the message after some time
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
        }
        messageCoroutine = StartCoroutine(HideMessageAfterDelay());
    }

    private IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDisplayTime);
        HideMessage();
    }

    private void HideMessage()
    {
        isMessageShowing = false;
        messageText.gameObject.SetActive(false);
        Debug.Log("Hiding message.");
    }

    private void UseKey()
    {
        // Check if the player has the required key
        InventoryManager.KeyData keyData = inventoryManager.keys.Find(k => k.keyName == requiredKey);

        if (keyData != null && keyData.keyCount > 0)
        {
            // Activate the specified GameObject
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
                Debug.Log($"{requiredKey} used. Activating associated GameObject.");
            }

            // Remove one key from the inventory
            keyData.keyCount--;
            // Update the panel text
            inventoryManager.UpdateKeyCountText(requiredKey);
            Debug.Log($"{requiredKey} count decreased by 1.");

            // Hide the message
            HideMessage();
        }
        else
        {
            // Display key required message
            DisplayMessage();
        }
    }
}
