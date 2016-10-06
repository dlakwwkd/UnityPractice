using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject fireObject;
    public float forwardPower = 20.0f;
    public float upPower = 5.0f;

    public Transform firePosTransform;

    PlayerState playerState = null;

    void Start()
    {
        playerState = GetComponent<PlayerState>();
    }

	void Update ()
    {
        if (playerState.isDead)
            return;

	    if(Input.GetButtonDown("Fire1"))
        {
            GameObject obj = Instantiate(fireObject) as GameObject;

            obj.transform.position = firePosTransform.position;
            obj.GetComponent<Rigidbody>().velocity = cameraTransform.forward * forwardPower + Vector3.up * upPower;

            var rand = Random.Range(0.0f, 10.0f);
            Vector3 force = new Vector3(rand, rand, rand);
            obj.GetComponent<Rigidbody>().AddTorque(force, ForceMode.Impulse);
        }
	}
}
