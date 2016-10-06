using UnityEngine;
using UnityEditor;
using System.Collections;

public class MyEditorWindow : EditorWindow
{
    enum UIMODE
    {
        MODE1 = 0,
        MODE2
    }
    UIMODE uiMode = UIMODE.MODE1;

    bool isShow = false;


    [MenuItem("MyMenu/Create Window")]
    static void CreateWindow()
    {
        MyEditorWindow window = (MyEditorWindow)EditorWindow.GetWindow(typeof(MyEditorWindow));
    }

    void OnEnable()
    {
        SceneView.onSceneGUIDelegate += SceneGUI;
    }
    void OnDisable()
    {
        SceneView.onSceneGUIDelegate -= SceneGUI;
    }

    void SceneGUI(SceneView sceneView)
    {
        Event e = Event.current;
        Handles.BeginGUI();
        switch (uiMode)
        {
            case UIMODE.MODE1:
            {
                if (GUI.Button(new Rect(10, 10, 100, 50), "to MODE2"))
                    uiMode = UIMODE.MODE2;
            }
            break;
            case UIMODE.MODE2:
            {
                if (GUI.Button(new Rect(10, 10, 100, 50), "to MODE1"))
                    uiMode = UIMODE.MODE1;

                if (GUI.Button(new Rect(150, 10, 200, 50), "Show My Window"))
                {
                    Debug.Log("Hello =====================");
                    isShow = !isShow;
                }

                if (isShow)
                    GUILayout.Window(0, new Rect(10, 90, 300, 300), ShowMyWindow, "Unity Objects");
            }
            break;
        }
        Handles.EndGUI();
    }

    void ShowMyWindow(int windowID)
    {
        GUILayout.Label("Test Label =====");

        GUILayout.BeginHorizontal();
        GUILayout.Button("Button 1");
        GUILayout.Button("Button 2");
        GUILayout.EndHorizontal();

        for (int i = 0; i < 3; ++i)
        {
            Rect rect = new Rect(10 + i * 110, 70, 100, 100);
            GUI.Button(rect, "Big Button " + i);
        }
    }

}
