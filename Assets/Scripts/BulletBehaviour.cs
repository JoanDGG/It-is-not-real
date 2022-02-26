using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Vector2 moveDirection;
    public float moveSpeed;
    public bool homing = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyBullet(2f));
        moveSpeed = 6f;
    }
    void Update()
    {
        //transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        if(homing)
        {
            SetMoveSpeed(35f);
            Vector3 direction = GameObject.FindWithTag("Player").transform.position - transform.position;
            direction.Normalize();
            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + ((Vector2)direction * moveSpeed * Time.deltaTime));
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }
    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.tag != other.gameObject.tag)
        {
            StartCoroutine(DestroyBullet(0.15f));
            if(other.gameObject.tag == "Player")
            {
                // Lower player HP
                // Destroy(other.gameObject);
                // Time.timeScale = 0;
            }
            else if(other.gameObject.tag == "Enemy")
            {
                // Lower enemy HP
                Destroy(other.gameObject);
            }
        }
    }
    public IEnumerator DestroyBullet(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
