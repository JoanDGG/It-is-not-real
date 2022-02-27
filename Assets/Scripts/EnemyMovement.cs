using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int facingRight = 1;
    public float movementSpeed = 3f;
    Rigidbody2D rigidbody2d;
    Vector2 playerPosition;
    Vector2 lookDirection;
    Vector2 movementDirection;
    private GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        child = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        RaycastHit2D hit2D = Physics2D.Linecast(child.transform.position, playerPosition);
        Debug.DrawLine(child.transform.position, playerPosition, Color.red);

        if(gameObject.name.Contains("Enemy 2"))
        {
            movementDirection = followPlayerMovement();
        }
        else if(gameObject.name.Contains("Enemy 4"))
        {
            // Doesnt move
        }
        else
        {
            movementDirection = horizontalMovement();
        }
        
        if(hit2D.collider != null)
        {
            if(hit2D.collider.CompareTag("Player"))
            {
                lookDirection =  playerPosition - rigidbody2d.position;
            }
            else
            {
                lookDirection = movementDirection;
            }
        }
        
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rigidbody2d.rotation = angle;
    }

    public Vector2 horizontalMovement()
    {
        if(transform.position.x > 7f)
        {
            facingRight = -1;
        }
        else if (transform.position.x < -7f)
        {
            facingRight = 1;
        }

        Vector2 direction = new Vector2(transform.position.x + movementSpeed * facingRight * Time.deltaTime, 
                                         transform.position.y);
        transform.position = direction;

        return direction;
    }

    public Vector2 followPlayerMovement()
    {
        Vector2 direction = playerPosition - (Vector2)transform.position;
        direction.Normalize();
        rigidbody2d.MovePosition((Vector2)transform.position + (direction * movementSpeed * Time.deltaTime));

        return direction;
    }
}
