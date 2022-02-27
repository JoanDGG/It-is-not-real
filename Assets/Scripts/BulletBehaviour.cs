using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Vector2 moveDirection;
    public float moveSpeed;
    public bool homing = false;

    public PickObject PickObject;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyBullet(2f));
        moveSpeed = 6f;
    }
     void Update()
    {
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
            print(other.gameObject.name);
            StartCoroutine(DestroyBullet(0.15f));
            if(other.gameObject.name.Contains("Enemy"))
            {
                // Lower HP
                other.gameObject.GetComponent<HealthPoints>().ChangeHealt(-1);
            }
            else if (other.gameObject.name.Contains("Player") && PickObject.shieldEnabled == false) {
                other.gameObject.GetComponent<HealthPoints>().ChangeHealt(-1);
            }
        }
    }
    
    public IEnumerator DestroyBullet(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
