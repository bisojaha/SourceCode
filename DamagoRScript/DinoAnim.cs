using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoAnim : MonoBehaviour
{
    public GameObject dino;
    public static DinoAnim instance;
    private void Awake()
    {
        instance = this;
    }

    public Animator anim;

    enum State
    {
        Eat,
        Move,
        Happy,
        Idle,
        Die
    }
    State state;

    public void Update()
    {
        switch (state)
        {
            case State.Idle: UpdateIdle(); break;
            case State.Die: UpdateDie(); break;
            case State.Move: Updatemove(); break;
            case State.Eat: UpdateEat(); break;
            case State.Happy: UpdateHappy(); break;
        }
    }

    public void UpdateIdle()
    {
        anim.SetTrigger("Idle");
    }
    public void Updatemove()
    {

    }
    public void UpdateEat()
    {
        int radom = Random.Range(0, 2);
        if (radom == 0)
        {
            anim.SetTrigger("Eat");
        }
        else if (radom == 1)
        {
            anim.SetTrigger("Eat2");
        }
        state = State.Idle;
    }
    public void UpdateHappy()
    {
        int radom = Random.Range(0, 2);
        if (radom == 0)
        {
            anim.SetTrigger("Happy");
        }
        else if (radom == 1)
        {
            anim.SetTrigger("Hello");
        }
        state = State.Idle;
    }

    float time = 0;
    public void UpdateDie()
    {
        anim.SetTrigger("Die");
        StartCoroutine(die());
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(2);
        dino.gameObject.SetActive(false);
    }

}