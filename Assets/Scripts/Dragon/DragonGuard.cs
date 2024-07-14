using UnityEngine;
using System.Collections;

public class DragonGuard : MonoBehaviour
{
    public Vector2 patrolAreaSize = new Vector2(10, 10); // Width and height of the patrol area in the XY plane
    public float speed = 2.0f;
    public float detectionRadius = 2.0f; // Radius for detection and attack
    public GameObject fireballPrefab;
    public Transform fireballSpawnPoint;
    public float fireballInterval = 1.0f; // Time between each fireball shot

    private Vector3 patrolAreaCenter;
    private Transform player;
    private Animator animator;
    private Vector3 patrolTarget;
    private bool isChasing;
    private bool isAttacking;
    private bool canShoot = true; // To control shooting rate

    void Start()
    {
        patrolAreaCenter = transform.position; // Set patrol area center to the initial position of the guard
        animator = GetComponent<Animator>();
        SetNewPatrolTarget();
    }

    void Update()
    {
        DetectPlayer();

        if (player == null)
        {
            Patrol();
        }
        else if (Vector3.Distance(transform.position, player.position) > detectionRadius)
        {
            ChasePlayer();
        }
        else
        {
            AttackPlayer();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(patrolAreaCenter, new Vector3(patrolAreaSize.x, patrolAreaSize.y, 0.1f)); // Draw patrol area in XY plane

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius); // Draw detection area around the guard
    }

    void Patrol()
    {
        if (!isChasing && !isAttacking)
        {
            animator.SetBool("isRunning", true); // Set running animation during patrol
        }

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, patrolTarget, step);

        // Make the guard look in the direction of patrol movement
        Vector3 direction = (patrolTarget - transform.position).normalized;
        if (direction.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(direction.x), 1, 1);
        }

        if (Vector3.Distance(transform.position, patrolTarget) < 0.1f)
        {
            SetNewPatrolTarget();
        }
    }

    void SetNewPatrolTarget()
    {
        float patrolX = Random.Range(-patrolAreaSize.x / 2, patrolAreaSize.x / 2);
        float patrolY = Random.Range(-patrolAreaSize.y / 2, patrolAreaSize.y / 2);
        patrolTarget = patrolAreaCenter + new Vector3(patrolX, patrolY, 0); // Adjust in XY plane
    }

    void DetectPlayer()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(patrolAreaCenter, patrolAreaSize, 0);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                player = hitCollider.transform;
                isChasing = true;
                return;
            }
        }

        if (isChasing && player != null && Vector3.Distance(transform.position, player.position) > detectionRadius)
        {
            player = null;
            isChasing = false;
        }
    }

    void ChasePlayer()
    {
        if (player == null) return;

        isChasing = true;
        isAttacking = false;
        animator.SetBool("isRunning", true);
        animator.SetBool("isAttacking", false);

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        // Make the guard look in the direction of the player
        if (direction.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(direction.x), 1, 1);
        }
    }

    void AttackPlayer()
    {
        if (player == null) return;

        isChasing = false;
        isAttacking = true;
        animator.SetBool("isRunning", false);
        animator.SetBool("isAttacking", true);

        // Ensure the attack animation plays only once and stays in attack state
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("attack");
        }

        // Shoot fireballs at regular intervals
        if (canShoot)
        {
            StartCoroutine(ShootFireballs());
        }
    }

    IEnumerator ShootFireballs()
    {
        canShoot = false; // Prevent firing more fireballs until the interval has passed

        ShootFireball(); // Shoot the first fireball immediately

        // Shoot fireballs at intervals
        while (isAttacking && player != null)
        {
            yield return new WaitForSeconds(fireballInterval);
            ShootFireball();
        }

        canShoot = true; // Allow firing again
    }

    // This method can be called via Animation Event
    public void ShootFireball()
    {
        if (fireballPrefab != null && fireballSpawnPoint != null && player != null)
        {
            GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, Quaternion.identity);
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

            // Calculate direction from fireballSpawnPoint to player
            Vector2 direction = (player.position - fireballSpawnPoint.position).normalized;

            // Set the velocity of the fireball
            rb.velocity = direction * 10f; // Adjust the speed as needed
        }
    }
}
