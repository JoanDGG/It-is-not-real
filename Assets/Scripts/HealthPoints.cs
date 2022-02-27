using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoints : MonoBehaviour
{
    public float hp = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Player")
            GameObject.Find("HPText").GetComponent<Text>().text = hp + " HP";
    }
    public void ChangeHealt(int amount)
    {
        hp += amount;
        if (hp <= 0) {
            hp = 0;
            if (gameObject.tag == "Player") 
            {
                // Destroy and show canvas of game over
                // Time.timeScale = 0;
            }
            else if (gameObject.tag == "Enemy")
            {
                GameObject.Find("GameManager").GetComponent<EnemySpawner>().enemies2NextWave -= 1;
            }
            Destroy(gameObject);
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != gameObject.tag && other.gameObject.name.Contains("Bullet")) 
        {
            hp -= 1f;
            Destroy(other.gameObject);
        }
    }
    */
}
