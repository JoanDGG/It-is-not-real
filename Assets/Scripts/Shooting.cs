using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private GameObject bullet;
    private Rigidbody2D rigidbody2d_bullet;

    public float bulletForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space")) {
            Shoot();
        }
    }

    void Shoot()
    {
        bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        rigidbody2d_bullet = bullet.GetComponent<Rigidbody2D>();
        rigidbody2d_bullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
