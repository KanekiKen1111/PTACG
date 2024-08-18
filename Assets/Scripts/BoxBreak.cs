using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBreak : Projectile
{
    [SerializeField] GameObject drop;
    [SerializeField] int dropCount = 15;
    [SerializeField] float spread = 3f;

    protected Projectile _bulletComponent;

    // Contains the logic of the collectable 
    private void HitLogic()
    {
        if (!CanBeHit())
        {
            return;
        }

        Hit();
    }

    // Override to add custom colletable behaviour
    protected virtual void Hit()
    {
        Debug.Log("Hitting the box");
        while (dropCount > 0)
        {
            dropCount -= 1;
            Vector3 pos = transform.position;
            pos.x += spread * UnityEngine.Random.value - spread / 2;
            pos.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject go = Instantiate(drop);
            go.transform.position = pos;
        }

        Destroy(gameObject);
    }

    // Returns if this colletable can pe picked, True if it is colliding with the player
    private bool CanBeHit()
    {
        return _bulletComponent != null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Projectile>() != null)
        {
            _bulletComponent = other.GetComponent<Projectile>();
            HitLogic();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _bulletComponent = null;
    }

}