using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private GameObject bullet;
    private Rigidbody2D rigidbody2d_bullet;
    private Rigidbody2D rigidbody2d;

    public float bulletForce;

    public GameObject player;
    Vector2 playerPosition;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Player") 
        {
            if(Input.GetKey("space"))
                Shoot();
        }
        else
        {
            playerPosition = player.transform.position;
            RaycastHit2D hit2D = Physics2D.Linecast(transform.position, playerPosition);
            if(hit2D.collider != null)
            {
                if(hit2D.collider.CompareTag("Player"))
                {
                    Shoot();
                }
            }
        }
    }

    void Shoot()
    {
        bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        rigidbody2d_bullet = bullet.GetComponent<Rigidbody2D>();
        rigidbody2d_bullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

}
