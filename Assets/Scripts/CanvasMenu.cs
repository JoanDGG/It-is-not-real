using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMenu : MonoBehaviour
{
    public Text pressText;
    public GameObject canvasMenu;

    public GameObject player;

    public GameObject canvasMain;
    public GameObject canvasPause;
    // Start is called before the first frame update
    void Awake()
    {
        player.SetActive(false);
        canvasMain.SetActive(false);
        canvasPause.SetActive(false);
    }

    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            canvasMenu.SetActive(false);
            Cursor.visible = true;
            player.SetActive(true);
            canvasMain.SetActive(true);
        }
    }
}
