using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRota : MonoBehaviour
{
    public List<Transform> wheelPlus = new List<Transform>();
    public List<Transform> wheelMinus = new List<Transform>();

    public float rotaSpeed = 50;
    void Start()
    {
    }

    void Update()
    {
        for (int i = 0; i < wheelPlus.Count; i++)
        {
            wheelPlus[i].Rotate(Vector3.right * rotaSpeed * Time.deltaTime);
        }
        for (int i = 0; i < wheelMinus.Count; i++)
        {
            wheelMinus[i].Rotate(Vector3.left * rotaSpeed * Time.deltaTime);
        }
    }
}
