using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int facingRight = 1;
    private float movementSpeed = 3f;
    Rigidbody2D rigidbody2d;
    Vector2 playerPosition;
    Vector2 lookDirection;
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

        Vector2 movementDirection = horizontalMovement();
        
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
}
