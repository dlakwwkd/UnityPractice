using UnityEngine;
using System.Collections;

public class iTweenMoveTest : MonoBehaviour
{
    public Transform target;

	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.A))
        {
            Hashtable hash = new Hashtable();
            hash.Add("position", target);
            hash.Add("orienttopath", true);
            hash.Add("looktime", 2.0f);
            hash.Add("time", 2.0f);
            hash.Add("easetype", iTween.EaseType.easeInOutExpo);

            iTween.MoveTo(gameObject, hash);
        }
	}
}
