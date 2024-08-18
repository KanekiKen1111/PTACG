using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    public Transform player; // Reference to the player's position
    // Reference to boundary objects
    public Transform leftBoundary;
    public Transform rightBoundary;
    public Transform topBoundary;
    public Transform bottomBoundary;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        // Set the limits based on the boundary objects' positions
        leftLimit = leftBoundary.position.x;
        rightLimit = rightBoundary.position.x;
        topLimit = topBoundary.position.y;
        bottomLimit = bottomBoundary.position.y;
    }

    void LateUpdate()
    {
        // Get the current camera position
        Vector3 newPosition = transform.position;

        // Set the camera's position to follow the player
        newPosition.x = player.position.x;
        newPosition.y = player.position.y;

        // Calculate the camera's half-width and half-height based on its orthographic size and aspect ratio
        float halfHeight = cam.orthographicSize;
        float halfWidth = cam.aspect * halfHeight;

        // Clamp the camera's position to ensure it stays within the bounds
        newPosition.x = Mathf.Clamp(newPosition.x, leftLimit + halfWidth, rightLimit - halfWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, bottomLimit + halfHeight, topLimit - halfHeight);

        // Set the camera's position to the clamped value
        transform.position = newPosition;
    }

    void OnDrawGizmos()
    {
        // Draw a wireframe of the bounds in the Scene view for visual reference
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
    }

    // Boundary limits (private since they're now set in Start)
    private float leftLimit;
    private float rightLimit;
    private float topLimit;
    private float bottomLimit;
}
