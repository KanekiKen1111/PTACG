using UnityEngine;

public class CheckAndActivateObject : MonoBehaviour
{
    [Header("Objects to Check")]
    public GameObject[] objectsToCheck; // Array of objects to check for active status

    [Header("Target Object")]
    public GameObject targetObject; // The object to activate when all objects are active

    private void Update()
    {
        if (AreAllObjectsActive())
        {
            ActivateTargetObject();
        }
    }

    private bool AreAllObjectsActive()
    {
        foreach (GameObject obj in objectsToCheck)
        {
            if (obj == null || !obj.activeInHierarchy)
            {
                return false; // Return false if any object is not active
            }
        }
        return true; // All objects are active
    }

    private void ActivateTargetObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }
}
