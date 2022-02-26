using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Rigidbody2D rigidbody2d;
    public float bulletForce;
    private bool IsAvailable = true;
    public float CooldownDuration = 0.2f;
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
        if (gameObject.tag == "Player") 
        {
            if(Input.GetKey("space"))
                Shoot();
        }
        else
        {
            Vector2 playerPosition = GameObject.FindWithTag("Player").transform.position;
            RaycastHit2D hit2D = Physics2D.Linecast(child.transform.position, playerPosition);
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
        if (IsAvailable == false)
        {
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, child.transform.position, child.transform.rotation);
        bullet.tag = gameObject.tag;
        Rigidbody2D rigidbody2d_bullet = bullet.GetComponent<Rigidbody2D>();
        rigidbody2d_bullet.AddForce(child.transform.up * bulletForce, ForceMode2D.Impulse);
        StartCoroutine(StartCooldown());
    }

    public IEnumerator StartCooldown()
     {
         IsAvailable = false;
         yield return new WaitForSeconds(CooldownDuration);
         IsAvailable = true;
     }

}
