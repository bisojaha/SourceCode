using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    GameObject target;
    public float speed = 3;
    Vector3 dir;

    void Start()
    {
        target = GameObject.Find("Dino");
        dir = target.transform.position - transform.position;
        dir.Normalize();
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }        
}
