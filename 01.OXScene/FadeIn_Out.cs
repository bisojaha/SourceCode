using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn_Out : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public float fadeTime;
    float accumTime;
    Coroutine fadeCor;


    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        accumTime = 0;
    }
    private void OnEnable()
    {
        StartFadeOut();
    }

    public void StartFadeIn()
    {
        if (fadeCor != null)
        {
            StopAllCoroutines();
            fadeCor = null;
        }
        fadeCor = StartCoroutine("FadeIn");
    }
    public void StartFadeOut()
    {
        if (fadeCor != null)
        {
            StopAllCoroutines();
            fadeCor = null;
        }
        fadeCor = StartCoroutine("FadeOut");
    }

    IEnumerator FadeIn()
    {
        accumTime = 0f;
        while (accumTime < fadeTime)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, accumTime / fadeTime);
            yield return 0;
            accumTime += Time.deltaTime;
        }
        canvasGroup.alpha = 1f;
    }
    IEnumerator FadeOut()
    {
        accumTime = 0f;
        while (accumTime < fadeTime)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, accumTime / fadeTime);
            yield return 0;
            accumTime += Time.deltaTime;
        }
        canvasGroup.alpha = 0f;
    }



    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
