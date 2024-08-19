using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{

    public void ExitLobby()
    {
        SceneManager.LoadScene("StartScene");
        Debug.Log("Loading!");
    }

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quit the application
            QuitGame();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}