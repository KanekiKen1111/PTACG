using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RandomPrefabArranger))]
public class RandomPrefabArrangerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RandomPrefabArranger arranger = (RandomPrefabArranger)target;

        if (GUILayout.Button("Arrange Objects"))
        {
            arranger.ArrangeObjects();
        }
    }
}
