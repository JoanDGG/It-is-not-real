using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool facingRight = true;
    public float movementSpeed = 5;

    private float horizontal;
    private float vertical;

    Rigidbody2D rigidbody2d;
    Animator animator;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Cursor.visible = true;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //animator.SetFloat("velocity", Mathf.Abs(rigidbody2d.velocity.x + rigidbody2d.velocity.y));
    }

    void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);

        if ((horizontal > 0.0f && !facingRight) || (horizontal < 0.0f && facingRight))
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }
}
