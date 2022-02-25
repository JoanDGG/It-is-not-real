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

    public Camera cam;
    Vector2 mousePos;
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
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);

        Vector2 lookDirection = mousePos - rigidbody2d.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rigidbody2d.rotation = angle;
        /*
        if ((horizontal > 0.0f && !facingRight) || (horizontal < 0.0f && facingRight))
        {
            Flip();
        }
        */
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }
}
