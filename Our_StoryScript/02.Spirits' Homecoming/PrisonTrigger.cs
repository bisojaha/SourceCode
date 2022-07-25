using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PrisonTrigger : MonoBehaviour
{
    public GameObject lr_02;
    public VideoPlayer prisonvideo;
    public float vidioTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine("PlayVideo");
    }

    IEnumerator PlayVideo()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        lr_02.gameObject.SetActive(true);
        prisonvideo.gameObject.SetActive(true);
        yield return new WaitForSeconds(vidioTime);
        prisonvideo.Stop();
        prisonvideo.gameObject.SetActive(false);
    }

    public void OnVideoOff()
    {
        prisonvideo.Stop();
        prisonvideo.SetDirectAudioMute(0, true);
        prisonvideo.gameObject.SetActive(false);
    }
}
