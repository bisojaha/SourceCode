using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;


public class RightHand : MonoBehaviour
{
    public Transform handRight;
    public LineRenderer lr;
    public GameObject trigger;
    //[HideInInspector]
    public bool onVideoButton = false;

    bool isRayOn = true;
    bool ishaptic = false;

    void Update()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        //Ray On/Off
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            if (isRayOn) isRayOn = false;
            else isRayOn = true;
        }

        // 의자 착석 On/Off
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
            transform.GetComponent<OVRPlayerController>().enabled = true;

        // Ray On 일 때
        if (isRayOn)
        {
            RaycastHit hitInfo = new RaycastHit();
            Ray ray = new Ray(handRight.position, handRight.forward);
            lr.gameObject.SetActive(true);
            lr.SetPosition(0, ray.origin);

            if (Physics.Raycast(ray, out hitInfo))
            {
                lr.SetPosition(1, hitInfo.point);
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Button"))
                {
                    onVideoButton = true;
                }
                else onVideoButton = false;
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Haptic"))
                {
                    if (!ishaptic) StartCoroutine("HapticTimer");
                }

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,
                                     OVRInput.Controller.RTouch))
                {
                    if (hitInfo.collider.tag == "X")
                        ControllerSound.instance.BackSound();
                    else ControllerSound.instance.HoverSound();

                    switch (hitInfo.collider.tag)
                    {
                        case "BUTTON":
                            PrisonTrigger lowTrigger = trigger.GetComponent<PrisonTrigger>();
                            lowTrigger.OnVideoOff(); break;
                        case "CHAIR":
                            Transform target = hitInfo.transform;
                            transform.position = new Vector3(target.position.x, target.position.y + 1.5f, target.position.z);
                            transform.forward = target.forward;
                            transform.GetComponent<OVRPlayerController>().enabled = false; break;
                        case "DOOR":
                            hitInfo.transform.GetComponent<DoorRota>().enabled = true; break;
                        case "START":
                            Tutorial.instance.StartButton(); break;
                        case "QUIT":
                            Tutorial.instance.QuitButton(); break;
                        case "GUIDE":
                            Tutorial.instance.GuideButton(); break;
                        case "PRODUCER":
                            Tutorial.instance.ProducerButton(); break;
                        case "X":
                            Tutorial.instance.X_Button(); break;
                        case "TICKET":
                            Tutorial.instance.TicketButton(); break;
                    }
                }
            }
            else
            {
                lr.SetPosition(1, ray.origin + ray.direction * 100);
                onVideoButton = false;
            }
        }
        else lr.gameObject.SetActive(false);
    }

    IEnumerator HapticTimer()
    {
        ishaptic = true;
        OVRInput.SetControllerVibration(0.1f, 0.1f, OVRInput.Controller.RTouch);
        ControllerSound.instance.HoverSound();
        yield return new WaitForSeconds(0.1f);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        yield return new WaitForSeconds(2.9f);
        ishaptic = false;
    }
}
