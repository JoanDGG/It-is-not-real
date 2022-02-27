using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Object") 
        {
            if(Input.GetKeyDown("f")) {
                spriteRenderer.sprite = Resources.Load<Sprite>(other.gameObject.name);
                Destroy(other.gameObject);
            }
        }
    }
}
