using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DoorRota : MonoBehaviour
{
    public GameObject doorL;
    public GameObject doorR;
    public Transform targetL;
    public Transform targetR;
    public float doorSpeed = 0.3f;

    void Update()
    {
        doorL.transform.rotation = Quaternion.Slerp(doorL.transform.rotation, targetL.rotation, Time.deltaTime * doorSpeed);
        doorR.transform.rotation = Quaternion.Slerp(doorR.transform.rotation, targetR.rotation, Time.deltaTime * doorSpeed);
    }
}
