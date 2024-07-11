using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RandomArranger))]
public class RandomArrangerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RandomArranger arranger = (RandomArranger)target;

        if (GUILayout.Button("Arrange Objects"))
        {
            arranger.ArrangeObjects();
        }
    }
}
