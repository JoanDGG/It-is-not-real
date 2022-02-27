using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public float objectHealth = 250f;
    private bool objectPickedUp;
    public static bool weaponEnabled;
    public static bool shieldEnabled;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        objectPickedUp = false;
        weaponEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (objectPickedUp) {
            if (Input.GetKey("left shift")) {
                objectHealth -= 0.1f;
                weaponEnabled = false;
                shieldEnabled = true;
            }
            else if (Input.GetKey("space")) {
                objectHealth -= 0.1f;
                weaponEnabled = true;
                shieldEnabled  = false;
            }

            if (objectHealth <= 0) {
                spriteRenderer.sprite = Resources.Load<Sprite>("None");
                objectPickedUp = false;
                weaponEnabled = false;
                shieldEnabled = false;
            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Object") 
        {
            //transform.GetChild(0).gameObject.SetActive(true);
            if(Input.GetKeyDown("f")) {
                spriteRenderer.sprite = Resources.Load<Sprite>(other.gameObject.name);
                Destroy(other.gameObject);
                objectPickedUp = true;
                weaponEnabled = true;
                objectHealth = 250;
            }
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Object") 
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    */
}
