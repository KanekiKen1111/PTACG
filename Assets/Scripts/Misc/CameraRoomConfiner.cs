using UnityEngine;
using Cinemachine;

public class CameraRoomConfiner : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public PolygonCollider2D roomCollider;
    public float orthographicSize = 5f;  // Adjust this size for each room in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var confiner = virtualCamera.GetComponent<CinemachineConfiner>();
            if (confiner != null)
            {
                confiner.m_BoundingShape2D = roomCollider; // Set the new bounding shape
                virtualCamera.m_Lens.OrthographicSize = orthographicSize; // Set the new orthographic size
            }
            else
            {
                Debug.LogWarning("Cinemachine Confiner2D component not found on the Virtual Camera.");
            }
        }
    }
}
