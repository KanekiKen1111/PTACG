using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    [System.Serializable]
    public class KeyData
    {
        public string keyName;
        public int keyCount;
    }

    public List<KeyData> keys = new List<KeyData>(); // List to store keys
    public GameObject inventoryPanel; // The panel that will be toggled
    public KeyCode toggleKey = KeyCode.K; // Key to toggle inventory display

    // Dictionary to hold references to text elements for different keys
    public List<Text> keyCountTexts; // List of Text elements
    private Dictionary<string, Text> keyCountTextDictionary;

    private bool isInventoryVisible = false;

    // Event declaration for key collection
    public delegate void KeyCollectedEvent();
    public static event KeyCollectedEvent OnKeyCollected;

    void Start()
    {
        // Ensure the key panel is hidden at the start
        inventoryPanel.SetActive(false);

        // Initialize the dictionary
        keyCountTextDictionary = new Dictionary<string, Text>();

        // Populate the dictionary with the text elements based on their names
        foreach (Text textElement in keyCountTexts)
        {
            if (textElement != null)
            {
                Debug.Log($"Adding text element with name: {textElement.name} to dictionary.");
                keyCountTextDictionary[textElement.name] = textElement;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleInventory();
        }
    }

    public void AddKey(string keyName)
    {
        Debug.Log($"Adding key: {keyName}");
        KeyData keyData = keys.Find(k => k.keyName == keyName);
        if (keyData != null)
        {
            keyData.keyCount++;
        }
        else
        {
            keys.Add(new KeyData { keyName = keyName, keyCount = 1 });
        }

        UpdateKeyCountText(keyName);

        // Trigger event when key is collected
        if (OnKeyCollected != null)
        {
            OnKeyCollected();
        }
    }

    private void ToggleInventory()
    {
        isInventoryVisible = !isInventoryVisible;
        inventoryPanel.SetActive(isInventoryVisible);
    }

    private void UpdateKeyCountText(string keyName)
    {
        if (keyCountTextDictionary.ContainsKey(keyName))
        {
            KeyData keyData = keys.Find(k => k.keyName == keyName);
            if (keyData != null)
            {
                Debug.Log($"Updating text for {keyName} with count {keyData.keyCount}");
                keyCountTextDictionary[keyName].text = $"{keyName}: {keyData.keyCount}";
            }
        }
        else
        {
            Debug.LogWarning($"No text element found for key: {keyName}");
        }
    }

    // Public method to get the key count text dictionary
    public Dictionary<string, Text> GetKeyCountTextDictionary()
    {
        return keyCountTextDictionary;
    }
}
