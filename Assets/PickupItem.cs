using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 4f;
    [SerializeField] float pickupDistance = 2.5f;
    [SerializeField] float despawnTime = 10f;

    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }

    private void Update()
    {
        despawnTime -= Time.deltaTime;
        if (despawnTime < 0)
        {
            Destroy(gameObject);

        }
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > pickupDistance)
        {
            return;
        }
        transform.position = Vector3.MoveTowards
            (transform.position, player.position, speed * Time.deltaTime);
        if (distance < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}