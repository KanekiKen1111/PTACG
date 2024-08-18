using UnityEngine;

public class StartUIController : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject startUI; // Reference to the UI that will be shown at the start

    private void Start()
    {
        if (startUI != null)
        {
            startUI.SetActive(true); // Show the UI at the start
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CloseStartUI();
        }
    }

    private void CloseStartUI()
    {
        if (startUI != null)
        {
            startUI.SetActive(false); // Hide the UI when `C` is pressed
        }
    }
}
