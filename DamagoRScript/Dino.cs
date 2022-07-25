using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dino : MonoBehaviour
{
    public GameObject eatEF;
    public GameObject touchEF;

    public Transform dinoCameraMod;
    public float maxAffection = 100;
    float affection;
    public Slider sliderAffection;
    public Transform dinoChild;

    void Start()
    {
        sliderAffection.maxValue = maxAffection;
        sliderAffection.value = 10;
        Affection = 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        DinoAnim.instance.UpdateEat();
        Affection += 12;
        Destroy(other.gameObject);
        eatEF.SetActive(true);
        StartCoroutine("EF");
        if (affection >= maxAffection)
        {
            affection = 10;
            sliderAffection.value = 10;
        }
    }
    void LateUpdate()
    {
        if (affection <= 0)
        {
            StartCoroutine(die());
        }
    }
    IEnumerator die()
    {
        DinoAnim.instance.UpdateDie();
        yield return new WaitForSeconds(5);

    }

    void Update()
    {
        if (affection > 0)
        {
            Affection -= 0.005f;
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
#else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
#endif
            RaycastHit hitinfo;
            if (Physics.Raycast(ray, out hitinfo))
            {
                if (hitinfo.collider.tag.Contains("Dino"))
                {
                    Affection += 12;
                    DinoAnim.instance.UpdateHappy();
                    touchEF.SetActive(true);
                    StartCoroutine("EF");
                }
            }
            if (affection >= maxAffection)
            {
                affection = 10;
                sliderAffection.value = 10;
            }
#if UNITY_EDITOR
#else
            }

#endif
        }
    }

    public float Affection
    {
        get
        {
            return affection;
        }
        set
        {
            affection = value;
            sliderAffection.value = affection;
        }
    }

    IEnumerator EF()
    {
        yield return new WaitForSeconds(1f);
        eatEF.SetActive(false);
        touchEF.SetActive(false);
    }
}