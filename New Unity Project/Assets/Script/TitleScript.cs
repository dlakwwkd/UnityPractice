using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour
{
    public Texture2D playTexture;

    void OnGUI()
    {
        float x = (Screen.width / 2.0f) - 100;
        float y = (Screen.height / 2.0f);

        Rect rect = new Rect(x, y, 200, 70);
        if(GUI.Button(rect, playTexture))
        {
            Application.LoadLevel("Game");
        }
    }
}
