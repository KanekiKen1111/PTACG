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

    public void QuitGame()
    {
        Application.Quit();
    }
}