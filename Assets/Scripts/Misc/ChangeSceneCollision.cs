using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneToLoad = "YourSceneName"; // Name of the scene to load

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Change the scene when the player collides with the object
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
