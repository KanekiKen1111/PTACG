using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void LevelKen()
    {
        SceneManager.LoadScene("Ken");
        Debug.Log("Loading!");
    }

    public void LevelNana()
    {
        SceneManager.LoadScene("Nana");
        Debug.Log("Loading!");
    }

    public void LevelRohith()
    {
        SceneManager.LoadScene("VillageScene");
        Debug.Log("Loading!");
    }

}
