using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(TileGridLayout))]
public class TileGridScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var myScript = (TileGridLayout)target;
        if (GUILayout.Button("Generate"))
        {
            myScript.SetGrids();
        }
    }
}
