using UnityEngine;
using System.Collections.Generic; // Required for List<T>

public class Fireball : MonoBehaviour
{
    public float lifetime = 5.0f; // Duration of the fireball before being destroyed
    public float explosionLifetime = 2.0f; // Duration of the explosion effect
    public GameObject explosionPrefab; // Explosion effect prefab
    private Rigidbody2D rb;

    public List<string> collisionTags = new List<string>(); // List of tags to check for collisions
    public List<GameObject> taggedObjects = new List<GameObject>(); // List of game objects with tags

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("DestroyFireball", lifetime); // Schedule destruction
        UpdateTaggedObjects(); // Initialize the list of tagged objects
    }

    void Update()
    {
        if (rb.velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the collided GameObject
        GameObject collidedObject = collision.gameObject;

        // Check if the collided object is in the taggedObjects list
        if (taggedObjects.Contains(collidedObject))
        {
            Debug.Log("Fireball collided with tagged object: " + collidedObject.name);

            // Instantiate explosion effect
            if (explosionPrefab != null)
            {
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(explosion, explosionLifetime); // Destroy the explosion effect after explosionLifetime seconds
            }

            // Destroy the fireball
            Destroy(gameObject);
        }
        else
        {
            // Optionally log collision with other objects
            Debug.Log("Fireball collided with an untagged object: " + collidedObject.name);
        }
    }

    void DestroyFireball()
    {
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, explosionLifetime); // Destroy the explosion effect after explosionLifetime seconds
        }
        Destroy(gameObject); // Destroy the fireball
    }

    void UpdateTaggedObjects()
    {
        // Clear the list before updating
        taggedObjects.Clear();

        // Loop through each tag in collisionTags
        foreach (string tag in collisionTags)
        {
            // Find all GameObjects with this tag
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in objectsWithTag)
            {
                if (!taggedObjects.Contains(obj))
                {
                    taggedObjects.Add(obj);
                }
            }
        }
    }
}
