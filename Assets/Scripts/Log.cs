using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{

    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    public List<string> collisionTags = new List<string>(); // List of tags to check for collisions
    public List<GameObject> taggedObjects = new List<GameObject>(); // List of game objects with tags

    public int damage = 3; // Damage dealt by the log

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position,
            transform.position) <= chaseRadius
            && Vector3.Distance(target.position,
                transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                target.position, moveSpeed * Time.deltaTime);
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

            // Apply damage if the collided object has a Health component
            Health health = collidedObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
                Debug.Log("Fireball dealt " + damage + " damage to " + collidedObject.name);
            }
        }

    }
}