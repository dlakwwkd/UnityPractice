using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

[CustomEditor(typeof(SimpleClass))]
public class SimpleClassEditor : Editor
{
    bool fold = false;
    bool fold2 = false;
    bool fold3 = false;

    public override void OnInspectorGUI()
    {
        SerializedProperty iterator = serializedObject.FindProperty("showButton");
        EditorGUILayout.PropertyField(iterator);

        iterator = serializedObject.FindProperty("level");
        EditorGUILayout.PropertyField(iterator);

        return;

        SimpleClass simpleClass = target as SimpleClass;

        simpleClass.showButton = EditorGUILayout.Toggle("Show Button !", simpleClass.showButton);

        #region Button
        if (simpleClass.showButton)
        {
            EditorGUILayout.BeginHorizontal();
            if(GUILayout.Button("Save Button"))
            {
                Debug.Log("Save Files...");
            }
            if (GUILayout.Button("Load Button"))
            {
                Debug.Log("Load Files...");
            }
            EditorGUILayout.EndHorizontal();
        }
        #endregion

        MyEditorUtility.DrawSeparator();

        if (GUILayout.Button("Create File"))
        {
            string dataPath = Application.dataPath;
            string fullPath = dataPath + "/test.txt";

            FileStream fs = new FileStream(fullPath, FileMode.Create);
            TextWriter textWriter = new StreamWriter(fs);

            textWriter.Write("width : 10" + "\n");

            textWriter.Close();

            // copy
            string copyPath = dataPath + "/test_copy.txt";
            FileUtil.CopyFileOrDirectory(fullPath, copyPath);

            AssetDatabase.Refresh();
        }

        MyEditorUtility.DrawSeparator();


        int level = EditorGUILayout.IntField("Level", simpleClass.level);
        if(level != simpleClass.level)
        {
            MyEditorUtility.RecordObject(simpleClass, "Change Level");
            simpleClass.level = level;
        }

        simpleClass.weight = EditorGUILayout.FloatField("Weight", simpleClass.weight);
        simpleClass.nickName = EditorGUILayout.TextField("Nick Name", simpleClass.nickName);


        MyEditorUtility.DrawSeparator();

        simpleClass.heroType = 
            (HEROTYPE)EditorGUILayout.EnumPopup("Hero Type", simpleClass.heroType);

        GUI.backgroundColor = (simpleClass.mainCameraObject != null) ? Color.green : Color.red;
        simpleClass.mainCameraObject =
            (GameObject)EditorGUILayout.ObjectField("Main Camera", simpleClass.mainCameraObject, typeof(GameObject), true);
        GUI.backgroundColor = Color.white;

        GUI.color = (simpleClass.myTransform != null) ? Color.green : Color.red;
        simpleClass.myTransform =
            (Transform)EditorGUILayout.ObjectField("My Transform", simpleClass.myTransform, typeof(Transform), true);
        GUI.color = Color.white;

        MyEditorUtility.DrawSeparator();

        fold = EditorGUILayout.Foldout(fold, "My List");
        if(fold)
        {
            for (int i = 0; i < simpleClass.myList.Count; ++i)
            {
                string name = "My List : " + i;
                simpleClass.myList[i] =
                    EditorGUILayout.IntField(name, simpleClass.myList[i]);
            }
        }
        fold2 = EditorGUILayout.Foldout(fold2, "My FloatArray");
        if(fold2)
        {
            for (int i = 0; i < simpleClass.arrayFloat.Length; ++i)
            {
                string name = "My FloatArray : " + i;
                simpleClass.arrayFloat[i] =
                    EditorGUILayout.FloatField(name, simpleClass.arrayFloat[i]);
            }
        }
        fold3 = EditorGUILayout.Foldout(fold3, "My VectorArray");
        if(fold3)
        {
            for (int i = 0; i < simpleClass.arrayVector3.Length; ++i)
            {
                string name = "My VectorArray : " + i;
                simpleClass.arrayVector3[i] =
                    EditorGUILayout.Vector3Field(name, simpleClass.arrayVector3[i]);
            }
        }
    }
}
