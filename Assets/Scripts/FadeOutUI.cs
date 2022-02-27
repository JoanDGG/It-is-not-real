using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOutUI : MonoBehaviour
{
    [System.NonSerialized] public bool forceOut = false;
    public float fadeTime = 3.0f;
    public float lifeTime = 5.0f;

    private Text texto;
    public GameObject titleText;
    public GameObject controlsText;
    private bool IsAvailable = true;
    public float CooldownDuration;

    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<Text>();
        if(gameObject.name == "PressText")
        {
            StartCoroutine(lifeTimeCoroutine());
            titleText.SetActive(false);
            controlsText.SetActive(false);
        }
        else if(gameObject.name == "CenterText")
        {
            texto.color = new Color(texto.color.r,
                                    texto.color.g,
                                    texto.color.b, 0f);
            FadeInText();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(SceneManager.GetActiveScene().name != "Main")
            {
                if (IsAvailable == true)
                    SceneManager.LoadScene("Main");
            }
            else
            {
                gameObject.GetComponent<Animator>().SetTrigger("Start");
            }
        }
    }

    public void FadeInText()
    {
        texto = GetComponent<Text>();
        texto.color = new Color(texto.color.r, texto.color.g, texto.color.b, 0f);
        StartCoroutine(FadeInRoutine());
    }

    public void FadeOutText()
    {
        texto.color = new Color(texto.color.r, texto.color.g, texto.color.b, 1f);
        StartCoroutine(FadeOutRoutine());
    }

    private IEnumerator lifeTimeCoroutine()
    {
        CooldownDuration = lifeTime + 2.0f;
        StartCoroutine(StartCooldown());

        yield return new WaitForSeconds(2.5f);
        FadeOutText();
        yield return new WaitForSeconds(lifeTime/2);
        texto.text = "";
        print("B");
        titleText.SetActive(true);
        controlsText.SetActive(true);
    }
    private IEnumerator FadeInRoutine()
    {
        while (texto.color.a < 1.0f)
        {
            if (!forceOut)
            {
                texto.color = new Color(texto.color.r,
                                        texto.color.g,
                                        texto.color.b,
                                        texto.color.a + (Time.deltaTime / fadeTime));
                yield return null;
            }
            else
            {
                texto.color = new Color(texto.color.r,
                                        texto.color.g,
                                        texto.color.b, 1f);
                FadeOutText();
                break;
            }
        }
        if (texto.color.a >= 0.9f)
        {
            texto.color = new Color(texto.color.r,
                                    texto.color.g,
                                    texto.color.b, 1f);
            FadeOutText();
        }
    }

    private IEnumerator FadeOutRoutine()
    {
        while (texto.color.a > 0.0f)
        {
            if(!forceOut)
            {
                texto.color = new Color(texto.color.r,
                                        texto.color.g,
                                        texto.color.b,
                                        texto.color.a - (Time.deltaTime / fadeTime));
                yield return null;
            }
            else
            {
                texto.color = new Color(texto.color.r,
                                        texto.color.g,
                                        texto.color.b, 0f);
                FadeInText();
                break;
            }
        }
        if (texto.color.a <= 0.1f)
        {
            texto.color = new Color(texto.color.r,
                                    texto.color.g,
                                    texto.color.b, 0f);
            FadeInText();
        }
    }
    private IEnumerator StartCooldown()
    {
        IsAvailable = false;
        yield return new WaitForSeconds(CooldownDuration);
        print("A");
        texto.text = "Press space to start";
        IsAvailable = true;
    }
}
