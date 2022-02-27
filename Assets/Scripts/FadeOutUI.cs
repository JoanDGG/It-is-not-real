using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutUI : MonoBehaviour
{
    [System.NonSerialized] public bool forceOut = false;
    public float fadeTime = 3.0f;
    public float lifeTime = 5.0f;

    private Text texto;

    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<Text>();
        FadeOutText();
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
        }
    }
}
