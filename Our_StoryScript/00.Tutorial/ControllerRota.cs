using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRota : MonoBehaviour
{
    public float rotaSpeed;

    void Start()
    {

    }


    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.LTouch))
        {
            print("123");
            this.transform.Rotate(Vector3.up * rotaSpeed * Time.deltaTime);
        }
        else if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.LTouch))
        {
            this.transform.Rotate(Vector3.down * rotaSpeed * Time.deltaTime);
        }
                else if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            print("aaaaaaaaaaa");
        }
    }
}
