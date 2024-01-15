using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigid;

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;

    private Vector3 moveDirection = Vector3.back;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        CharacterController controller = GetComponent<CharacterController>();
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        moveDirection.y -= gravity;
        if (controller.isGrounded)
        {
            moveDirection.y = 0;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        controller.Move(moveDirection * Time.deltaTime);

    }
}
