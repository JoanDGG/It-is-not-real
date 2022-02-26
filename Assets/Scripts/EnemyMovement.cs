using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int facingRight = 1;
    private float movementSpeed = 3f;
    public GameObject player;
    Rigidbody2D rigidbody2d;
    Vector2 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        Vector2 lookDirection =  playerPosition - rigidbody2d.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rigidbody2d.rotation = angle;

        horizontalMovement();
    }

    public void horizontalMovement()
    {
        if(transform.position.x > 7f)
        {
            facingRight = -1;
        }
        else if (transform.position.x < -7f)
        {
            facingRight = 1;
        }

        transform.position = new Vector2(transform.position.x + movementSpeed * facingRight * Time.deltaTime, 
                                         transform.position.y);
    } 
}
