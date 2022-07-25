using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour
{
    public GameObject animAll;
    public GameObject dino00;
    public Transform dinoCameraMod;
    public Transform dinoOriginMod;
    public GameObject eatFactory;
    public GameObject eatPoint;
    public float rotaSpeed = 600;

    public void Hello()
    {
        DinoAnim.instance.anim.SetTrigger("Hello");
    }
    public void Die()
    {
        DinoAnim.instance.anim.SetTrigger("Die");
    }
    public void Move()
    {
        DinoAnim.instance.anim.SetTrigger("Move");

    }
    public void Eat()
    {
        DinoAnim.instance.anim.SetTrigger("Eat");
    }

    public void OnClickAinmButton()
    {
        if (animAll.activeSelf)
        {
            animAll.SetActive(false);
        }
        else
        {
            animAll.SetActive(true);
        }
    }

    public void OnClikeDinoMod()
    {
        if (dino00.transform.rotation == dinoCameraMod.rotation)
        {
            dino00.transform.rotation = dinoOriginMod.rotation;
        }
        else
        {
            dino00.transform.rotation = dinoCameraMod.rotation;
        }
    }

    public void OnClikeLunchBox()
    {
        GameObject eat = Instantiate(eatFactory);
        eat.transform.position = eatPoint.transform.position;
    }
}
