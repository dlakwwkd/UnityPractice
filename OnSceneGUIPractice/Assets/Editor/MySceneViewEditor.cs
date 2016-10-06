using UnityEngine;
using UnityEditor;
using System.Collections;


[CustomEditor(typeof(MySceneView))]
public class MySceneViewEditor : Editor
{
    Color arcColor = new Color(1, 1, 1, 0.1f);
    void OnSceneGUI()
    {
        Handles.BeginGUI();
        if(GUI.Button(new Rect(10,10,100,50), "Show Window"))
        {
            MyWindow window = (MyWindow)EditorWindow.GetWindow(typeof(MyWindow));
            window.title = "Menu 1";
        }

        if(GUI.Button(new Rect(10,70,100,50), "Dialog Window"))
        {
            if(EditorUtility.DisplayDialog("Warning Message", "This is My warning dialog.", "ok", "cancel") == true)
            {
                Debug.Log("Clicked OK button");
            }
            else
            {
                Debug.LogWarning("Clicked Cancel button");
            }
        }
        Handles.EndGUI();


        MySceneView mySceneView = target as MySceneView;
        Transform myTransform = mySceneView.transform;

        Handles.color = arcColor;
        Handles.DrawSolidArc(myTransform.position, Vector3.up, myTransform.forward - myTransform.right, 90.0f, 5.0f);
        Handles.color = Color.white;

        Handles.color = Color.blue;
        Handles.ArrowCap(0, myTransform.position, myTransform.rotation, 1.0f);
        Handles.color = Color.white;


        Event e = Event.current;
        if(e.type == EventType.mouseDown)
        {
            if(e.button == 1)   // 0 : 마우스 왼쪽 버튼
            {
                arcColor.r = Random.Range(0.0f, 1.0f);
                arcColor.g = Random.Range(0.0f, 1.0f);
                arcColor.b = Random.Range(0.0f, 1.0f);
            }
        }
        if(e.isKey)
        {
            if (e.character == '1')
                Debug.Log("1 Key is down");
            if (e.character == '2')
                Debug.LogWarning("2 Key is down");
            if (e.alt)
                Debug.Log("Alt key is down");
            if (e.control)
                Debug.Log("Ctrl key is down");
        }
    }
}
