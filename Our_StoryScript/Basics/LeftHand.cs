using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeftHand : MonoBehaviour
{
    public GameObject controller;
    public GameObject menu;
    public float rotaSpeed = 50;

    void Start()
    {

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "00.Tutorial")
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.LTouch))
            {
                controller.transform.Rotate(Vector3.down * rotaSpeed * Time.deltaTime);
            }
            else if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.LTouch))
            {
                controller.transform.Rotate(Vector3.up * rotaSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
            {
                SceneManager.LoadScene(3);
            }
                        if (OVRInput.GetDown(OVRInput.Button.Start, OVRInput.Controller.LTouch))
            {
                menu.SetActive(true);
            }
        }
    }
}
