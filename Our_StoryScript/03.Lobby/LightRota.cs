using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRota : MonoBehaviour
{
    public float rotaSpeed = 2;

    void Update()
    {
        this.transform.Rotate(Vector3.up * rotaSpeed * Time.deltaTime);
    }
}
