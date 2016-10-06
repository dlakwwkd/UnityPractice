using UnityEngine;
using System.Collections;

public class Temp : MonoBehaviour
{
    void OnGUI()
    {
        if(GUI.Button(new Rect(100,100,100,100), "launch"))
        {
            if (Application.platform != RuntimePlatform.Android)
                return;

            // Load package
            AndroidJavaClass pluginClass = new AndroidJavaClass("com.dz.DzPlugin");

            // Get class Instance
            AndroidJavaObject _plugin = pluginClass.CallStatic<AndroidJavaObject>("Instance");

            // call Java Method.
            _plugin.Call("ShowToast", "Test Tost 2", true);
            _plugin.Call("ShowAlert", "1", "This is Alert Box", "Yeeees", "Canceeeel");
        }
    }

    public void alertButtonClicked(string buttonText)
    {
        Debug.Log("Button Click : =============== " + buttonText);
    }

    public void alertButtonCancelled(string buttonText)
    {
        Debug.Log("Cancel Button Click : =============== " + buttonText);
    }

}
