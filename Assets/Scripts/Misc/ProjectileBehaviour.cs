using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private Vector2 startPoint;
    private Vector2 endPoint;
    private float speed;
    private float destroyAfter;

    private float startTime;

    public void Initialize(Vector2 start, Vector2 end, float projectileSpeed, float destroyTime)
    {
        startPoint = start;
        endPoint = end;
        speed = projectileSpeed;
        destroyAfter = destroyTime;
        startTime = Time.time;
    }

    private void Update()
    {
        // Move the projectile
        float journeyLength = Vector2.Distance(startPoint, endPoint);
        float distanceCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distanceCovered / journeyLength;

        transform.position = Vector2.Lerp(startPoint, endPoint, fractionOfJourney);

        // Destroy the projectile if it reaches the end point or after a set time
        if (fractionOfJourney >= 1f || Time.time - startTime >= destroyAfter)
        {
            Destroy(gameObject);
        }
    }
}