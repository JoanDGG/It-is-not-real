using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(DestroyBullet(2f));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(DestroyBullet(0.15f));
        if(other.gameObject.tag == "Wall")
        {
            StartCoroutine(DestroyBullet(0.15f));
        }
    }
    public IEnumerator DestroyBullet(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
