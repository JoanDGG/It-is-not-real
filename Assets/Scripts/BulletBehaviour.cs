using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyBullet(2f));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(DestroyBullet(0.15f));
        if(gameObject.tag != other.gameObject.tag)
        {
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
