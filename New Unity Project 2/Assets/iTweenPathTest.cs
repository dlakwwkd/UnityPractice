using UnityEngine;
using System.Collections;

public class iTweenPathTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Hashtable hash = new Hashtable();
            hash.Add("path", iTweenPath.GetPath("New Path 1"));
            hash.Add("orienttopath", true);
            hash.Add("looktime", 1.0f);
            hash.Add("time", 3.0f);
            hash.Add("easetype", iTween.EaseType.easeInOutQuint);
            hash.Add("looptype", iTween.LoopType.none);
            iTween.MoveTo(gameObject, hash);
        }
    }
}
