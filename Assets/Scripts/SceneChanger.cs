using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // This method changes to the specified scene.
    // Call this method and pass the name of the scene you want to load.
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Example of changing scenes based on a collision with a GameObject
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Change to a scene named "NextScene"
            ChangeScene("Nana");
        }
    }
}
