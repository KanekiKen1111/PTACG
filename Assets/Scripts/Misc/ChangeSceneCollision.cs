using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneToLoad = "YourSceneName"; // Name of the scene to load

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected. Changing scene to: " + sceneToLoad);
            // Change the scene when the player collides with the object
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.Log("Non-player object collided: " + other.gameObject.name);
        }
    }
}
