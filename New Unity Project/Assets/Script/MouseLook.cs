using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 700.0f;
    public float xRange = 60.0f;
    public float yRange = 60.0f;
    float rotationX;
    float rotationY;

    PlayerState playerState = null;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerState = GetComponentInParent<PlayerState>();
    }

	void Update ()
    {
        if (playerState.isDead)
            return;

        float mouseMoveValueX = Input.GetAxis("Mouse X");
        float mouseMoveValueY = Input.GetAxis("Mouse Y");

        rotationY += mouseMoveValueX * sensitivity * Time.deltaTime;
        rotationX += mouseMoveValueY * sensitivity * Time.deltaTime;

        rotationX %= 360;
        rotationY %= 360;

        rotationX = Mathf.Clamp(rotationX, -yRange, yRange);
        rotationY = Mathf.Clamp(rotationY, -xRange, xRange);
// 
//         Debug.Log("Rotation X : " + rotationX);
//         Debug.Log("Rotation Y : " + rotationY);

        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0.0f);
	}
}
