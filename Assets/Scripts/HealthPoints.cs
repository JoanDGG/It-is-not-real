using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoints : MonoBehaviour
{
    public float hp = 100f;
    public GameObject centerText;
    public GameObject canvasGameOver;
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
                canvasGameOver.SetActive(true);
                centerText.SetActive(true);
                centerText.GetComponent<FadeOutUI>().Exit();
                gameObject.layer = 4;
                PlayerPrefs.SetInt("Waves", GameObject.Find("GameManager").GetComponent<EnemySpawner>().actualWave);
            }
            else if (gameObject.tag == "Enemy")
            {
                GameObject.Find("GameManager").GetComponent<EnemySpawner>().enemies2NextWave -= 1;
                Destroy(gameObject);
            }
        }
    }
}
