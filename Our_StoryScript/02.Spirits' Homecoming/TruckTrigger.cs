using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TruckTrigger : MonoBehaviour
{
    public Transform carDoor_01;
    public Transform carDoor_02;
    public Transform doorTarget;
    public GameObject truck;
    public GameObject truckVideo;
    public GameObject butterflyGate;
    VideoPlayer videoPlayer;
    public float doorSpeed = 0.3f;
    bool isTriggerOn = false;

    void Update()
    {
        if (truck.activeSelf == false)
        {
            truckVideo.gameObject.SetActive(true);
            butterflyGate.SetActive(true);
        }
        if (isTriggerOn)
        {
            StartCoroutine("TruckMove");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggerOn = true;
        }
    }

    IEnumerator TruckMove()
    {
        carDoor_01.rotation = Quaternion.Slerp(carDoor_01.rotation,
                                       doorTarget.rotation,
                                       Time.deltaTime * doorSpeed);
        carDoor_02.rotation = Quaternion.Slerp(carDoor_02.rotation,
                                               doorTarget.rotation,
                                               Time.deltaTime * doorSpeed);
        yield return new WaitForSeconds(8.0f);
        truck.transform.position += Vector3.back * 5.0f * Time.deltaTime;
        truck.GetComponent<WheelRota>().enabled = true;
        yield return new WaitForSeconds(7.0f);
        truck.gameObject.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        isTriggerOn = false;
        gameObject.SetActive(false);
    }
}
