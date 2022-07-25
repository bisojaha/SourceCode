using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Warp : MonoBehaviour
{
    public GameObject player;
    public Transform gateIn;
    public Transform gateOut;
    public VideoPlayer videoPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<OVRPlayerController>().enabled = false;
            if (this.gameObject.name == "GateOut")
            {
                player.transform.forward = gateIn.forward;
                player.transform.position = gateIn.position;
                videoPlayer.Stop();
            }
            else if (this.gameObject.name == "GateIn")
            {
                player.transform.forward = gateOut.forward;
                player.transform.position = gateOut.position;
                videoPlayer.Play();
            }
            player.GetComponent<CharacterController>().enabled = true;
            player.GetComponent<OVRPlayerController>().enabled = true;
        }
    }
}
