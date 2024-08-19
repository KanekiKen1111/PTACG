using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    public AudioClip backgroundMusic; // Assign your background music here
    private AudioSource audioSource;

    private int sceneChangeCount = 0; // Counter for scene changes
    private int maxSceneChanges = 4; // Number of scene changes before stopping music

    void Awake()
    {
        // Check if instance already exists
        if (Instance == null)
        {
            // Set this as the singleton instance
            Instance = this;
            // Make sure this object is not destroyed on scene load
            DontDestroyOnLoad(gameObject);
            // Set up the AudioSource
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.Play();

            // Subscribe to sceneLoaded event
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            // Destroy this object if another instance already exists
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from sceneLoaded event when this object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneChangeCount++;
        if (sceneChangeCount >= maxSceneChanges)
        {
            // Stop the music after the fourth scene change
            audioSource.Stop();
        }
    }
}