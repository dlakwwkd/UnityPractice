using UnityEngine;
using UnityEditor;
using System.Collections;

public class MyWindow : EditorWindow
{
    void OnGUI()
    {
        GUILayout.Space(10);
        GUILayout.Label("This is My First Window!", GUILayout.MinWidth(20));
        GUILayout.Space(10);
    }
}
