using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
public class RandomArranger : MonoBehaviour
{
    public float width = 10f;
    public float height = 10f;
    public List<GameObject> objectsToArrange;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 1f));
    }

    public void ArrangeObjects()
    {
        if (objectsToArrange == null || objectsToArrange.Count == 0)
        {
            Debug.LogWarning("No objects to arrange.");
            return;
        }

        foreach (var obj in objectsToArrange)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(transform.position.x - width / 2, transform.position.x + width / 2),
                Random.Range(transform.position.y - height / 2, transform.position.y + height / 2)
            );

            obj.transform.position = randomPosition;
        }
    }
}
