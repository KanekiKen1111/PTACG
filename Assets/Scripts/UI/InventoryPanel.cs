using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();

        // Subscribe to the event when a key is collected
        InventoryManager.OnKeyCollected += UpdateKeyPanel;

        // Update the UI initially
        UpdateKeyPanel();
    }

    void OnDestroy()
    {
        // Unsubscribe from the event when this object is destroyed
        InventoryManager.OnKeyCollected -= UpdateKeyPanel;
    }

    // Update the key panel UI when a key is collected
    private void UpdateKeyPanel()
    {
        var keyCountTextDictionary = inventoryManager.GetKeyCountTextDictionary();

        foreach (var key in inventoryManager.keys)
        {
            Debug.Log($"Key: {key.keyName}, Count: {key.keyCount}");
            if (keyCountTextDictionary.ContainsKey(key.keyName))
            {
                Text keyText = keyCountTextDictionary[key.keyName];
                keyText.text = $"{key.keyName}: {key.keyCount}";
            }
        }
    }
}