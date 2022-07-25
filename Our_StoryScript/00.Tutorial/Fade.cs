using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public float fadeTime = 5.0f;
    public float activeTime = 1.2f;
    public GameObject ticket;
    Material mat;
    float lerpTime = 0.05f, lerpStart = 1.0f, lerpEnd = 0.0f;

    void Start()
    {
        mat = this.GetComponent<SpriteRenderer>().material;
    }
    void Update()
    {
        FadeStart();
    }

    void FadeStart()
    {
        Color color = mat.color;
        lerpTime += Time.deltaTime / fadeTime;
        color.a = Mathf.Lerp(lerpStart, lerpEnd, lerpTime);
        mat.color = color;
        if (lerpTime > activeTime) this.gameObject.SetActive(false);
        if(this.gameObject.activeSelf==false)
        {
            ticket.gameObject.SetActive(true);
        }
    }
}
