using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour
{
    public int healthPoint = 5;
    public bool isDead = false;

    CameraShake cameraShake = null;

    void Start()
    {
        cameraShake = GetComponentInChildren<CameraShake>();
    }

    void OnGUI()
    {
        float x = (Screen.width / 2.0f) - 100;

        Rect rect = new Rect(x, 10, 200, 25);
        if (isDead == true)
            GUI.Box(rect, "Game Over !");
        else
            GUI.Box(rect, "My Health : " + healthPoint);

        int myScore = ScoreManager.Instance().myScore;
        int bestScore = ScoreManager.Instance().bestScore;
        rect.y += 30;
        rect.height = 40;
        GUI.Box(rect, "Score: " + myScore + "\n" + "Best Score: " + bestScore);
    }

    public void DamageByEnemy()
    {
        if (isDead)
            return;

        if (--healthPoint <= 0)
        {
            isDead = true;
        }
        cameraShake.PlayCameraShake();
    }
}
