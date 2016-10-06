using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public Transform cameraTransform;

    public float moveSpeed = 10.0f;
    public float jumpSpeed = 10.0f;
    public float gravity = -20.0f;

    CharacterController characterController = null;
    float yVelocity = 0.0f;

    PlayerState playerState = null;

    void Awake()
    {
    }

    void OnEnable()
    {
    }

	void Start () 
    {
        characterController = GetComponent<CharacterController>();
        playerState = GetComponent<PlayerState>();
	}
	
	void Update () 
    {
        if (playerState.isDead)
            return;

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(x, 0, z);
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;

        if(Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpSpeed;
        }

        yVelocity += (gravity * Time.deltaTime);
        moveDirection.y = yVelocity;

        characterController.Move(moveDirection * Time.deltaTime);

        if(characterController.collisionFlags == CollisionFlags.Below)
        {
            yVelocity = 0.0f;
        }
	}

    void FixedUpdate()
    {

    }
}
