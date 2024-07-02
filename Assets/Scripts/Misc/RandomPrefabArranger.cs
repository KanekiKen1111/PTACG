using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
public class RandomPrefabArranger : MonoBehaviour
{
    public float width = 10f;
    public float height = 10f;
    public GameObject prefab;
    public int numberOfDuplicates = 10;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 1f));
    }

    public void ArrangeObjects()
    {
        if (prefab == null)
        {
            Debug.LogWarning("Prefab not assigned.");
            return;
        }

        // Clear previously spawned objects
        foreach (var obj in spawnedObjects)
        {
            if (Application.isPlaying)
            {
                Destroy(obj);
            }
            else
            {
                DestroyImmediate(obj);
            }
        }
        spawnedObjects.Clear();

        // Instantiate and arrange objects
        for (int i = 0; i < numberOfDuplicates; i++)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(transform.position.x - width / 2, transform.position.x + width / 2),
                Random.Range(transform.position.y - height / 2, transform.position.y + height / 2)
            );

            GameObject newObj = Instantiate(prefab, randomPosition, Quaternion.identity);
            newObj.transform.parent = transform;
            spawnedObjects.Add(newObj);
        }
    }
}
