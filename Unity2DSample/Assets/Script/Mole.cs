using UnityEngine;
using System.Collections;

public class Mole : MonoBehaviour
{
    Animator anim;
	void Start ()
    {
        anim = GetComponent<Animator>();
	}

    bool touchPossible = false;
    public void Open()
    {
        touchPossible = true;
        Debug.Log("Open ====== ");
    }

    public void Close()
    {
        touchPossible = false;
        Debug.Log("Close ====== ");
    }

    public void OnMouseDown()
    {
        if (touchPossible)
        {
            touchPossible = false;
            anim.SetTrigger("catch");
        }
    }

    public IEnumerator CloseEvent()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));
        anim.SetTrigger("open");
    }

}
