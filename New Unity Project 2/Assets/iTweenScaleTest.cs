using UnityEngine;
using System.Collections;

public class iTweenScaleTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = Vector3.zero;

            iTween.StopByName("A");
            iTween.StopByName("B");

            Hashtable hash = new Hashtable();
            hash.Add("name", "A");
            hash.Add("scale", Vector3.one);
            hash.Add("time", 2.0f);
            hash.Add("easetype", iTween.EaseType.easeOutElastic);
            iTween.ScaleTo(gameObject, hash);

            hash.Clear();

            hash.Add("name", "B");
            hash.Add("y", 1080.0f);
            hash.Add("time", 2.0f);
            hash.Add("easetype", iTween.EaseType.easeOutExpo);
            iTween.RotateTo(gameObject, hash);
        }
    }
}
