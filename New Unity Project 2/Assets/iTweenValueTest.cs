using UnityEngine;
using System.Collections;

public class iTweenValueTest : MonoBehaviour
{
    Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Hashtable hash = new Hashtable();

            hash.Add("from", 0.0f);
            hash.Add("to", 255.0f);
            hash.Add("time", 5.0f);
            hash.Add("onupdate", "UpdateValue");

            iTween.ValueTo(gameObject, hash);
        }
    }

    void UpdateValue(float value)
    {
        Debug.Log(value);

        mat.color = Color.red * value / 255.0f;
    }
}
