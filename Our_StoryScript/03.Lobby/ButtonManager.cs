using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    public List<GameObject> doorList = new List<GameObject>();
    public List<GameObject> hallList = new List<GameObject>();

    public void OnClickDoor_01()
    {
        doorList[0].gameObject.GetComponent<DoorRota>().enabled = true;
        hallList[0].gameObject.SetActive(true);
    }
    public void OnClickDoor_02()
    {
        doorList[1].gameObject.GetComponent<DoorRota>().enabled = true;
        hallList[1].gameObject.SetActive(true);

    }
    public void OnClickDoor_03()
    {
        doorList[2].gameObject.GetComponent<DoorRota>().enabled = true;
        hallList[2].gameObject.SetActive(true);
    }
    public void OnClickDoor_04()
    {
        doorList[3].gameObject.GetComponent<DoorRota>().enabled = true;
        hallList[3].gameObject.SetActive(true);
    }
    public void OnClickDoor_05()
    {
        doorList[4].gameObject.GetComponent<DoorRota>().enabled = true;
        hallList[4].gameObject.SetActive(true);
    }
    public void OnClickDoor_06()
    {
        doorList[5].gameObject.GetComponent<DoorRota>().enabled = true;
        hallList[5].gameObject.SetActive(true);
    }
    public void OnClickDoor_07()
    {
        doorList[6].gameObject.GetComponent<DoorRota>().enabled = true;
        hallList[6].gameObject.SetActive(true);
    }
    public void OnClickDoor_08()
    {
        doorList[7].gameObject.GetComponent<DoorRota>().enabled = true;
        hallList[7].gameObject.SetActive(true);
    }
    public void OnClickDoor_09()
    {
        doorList[8].gameObject.GetComponent<DoorRota>().enabled = true;
        hallList[8].gameObject.SetActive(true);
    }
}
