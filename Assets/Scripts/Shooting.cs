using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Rigidbody2D rigidbody2d;
    private bool IsAvailable = true;
    public float CooldownDuration = 0.2f;
    private GameObject child;
    private float angle = 0f;
    private float startAngle = 0f, endAngle = 180;
    [SerializeField]
    private int bulletsAmount = 5;
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

        if(gameObject.name.Contains("Enemy 2"))
        {
            DoubleFire();
        }
        else if(gameObject.name.Contains("Enemy 3"))
        {
            MultiFire();
        }
        else if(gameObject.name.Contains("Enemy 4"))
        {
            HomingFire();
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, child.transform.position, child.transform.rotation);
            bullet.tag = gameObject.tag;
            Rigidbody2D rigidbody2d_bullet = bullet.GetComponent<Rigidbody2D>();
            bullet.GetComponent<BulletBehaviour>().SetMoveDirection(child.transform.up);
        }

        StartCoroutine(StartCooldown());
    }
    private void DoubleFire()
    {
        for (int i = 0; i <= 1; i++)
        {
            float bulDirX = child.transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = child.transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (GameObject.FindWithTag("Player").transform.position - bulMoveVector).normalized;
            
            GameObject bullet = Instantiate(bulletPrefab, child.transform.position, child.transform.rotation);
            bullet.tag = gameObject.tag;
            Rigidbody2D rigidbody2d_bullet = bullet.GetComponent<Rigidbody2D>();
            bullet.GetComponent<BulletBehaviour>().SetMoveDirection(bulDir);
            bullet.GetComponent<BulletBehaviour>().moveSpeed = 8f;
        }

        angle += 10f;

        if(angle >= 360f)
            angle = 0f;
    }
    private void MultiFire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = child.transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = child.transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (GameObject.FindWithTag("Player").transform.position - bulMoveVector).normalized;
            
            GameObject bullet = Instantiate(bulletPrefab, child.transform.position, child.transform.rotation);
            bullet.tag = gameObject.tag;
            Rigidbody2D rigidbody2d_bullet = bullet.GetComponent<Rigidbody2D>();
            bullet.GetComponent<BulletBehaviour>().SetMoveDirection(bulDir);
            bullet.GetComponent<BulletBehaviour>().moveSpeed = 4f;

            angle += angleStep;
        }

    }

    private void HomingFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, child.transform.position, child.transform.rotation);
        bullet.tag = gameObject.tag;
        Rigidbody2D rigidbody2d_bullet = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<BulletBehaviour>().SetMoveDirection(child.transform.up);
        bullet.GetComponent<BulletBehaviour>().homing = true;
        bullet.GetComponent<BulletBehaviour>().SetMoveSpeed(10f);
    }

    public IEnumerator StartCooldown()
     {
         IsAvailable = false;
         yield return new WaitForSeconds(CooldownDuration);
         IsAvailable = true;
     }

}
