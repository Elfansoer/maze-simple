using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ElfansoerMazeSimple))]
public class ElfansoerMazeSimpleEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        if ( GUILayout.Button("Generate") ) {
            ElfansoerMazeSimple mg = (ElfansoerMazeSimple) serializedObject.targetObject;
            mg.Rebuild_Editor();
        } 
    }
}