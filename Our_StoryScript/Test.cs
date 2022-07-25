using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Test : MonoBehaviour
{
    public static Test instance;
    void Awake() 
    {
      instance = this;   
    }
    public GameObject player;
    public GameObject videoButton;
    public GameObject pause_play, stop_play, mute_on;
    public VideoPlayer prisonkVideo;
    public VideoPlayer truckVideo;
    public Sprite[] sprite;
    VideoPlayer videoPlayer;
    SpriteRenderer spriteRenderer;
    RightHand rightHand;

    void Start()
    {
        rightHand = player.GetComponent<RightHand>();
        switch (this.transform.name)
        {
            case "PrisonVideo" :
            videoPlayer = prisonkVideo; break;
            case "TruckVideo" :
            videoPlayer = truckVideo; break;
        }
    }

    void Update()
    {
        if (rightHand.onVideoButton == true)
        videoButton.SetActive(true);
        else videoButton.SetActive(false);
    }

    public void VideoPause_Play()
    {
        if (pause_play.GetComponent<SpriteRenderer>().sprite == sprite[0])
        {
            videoPlayer.Pause();
            pause_play.GetComponent<SpriteRenderer>().sprite = sprite[1];
        }
        else
        {
            videoPlayer.Play();
            pause_play.GetComponent<SpriteRenderer>().sprite = sprite[0];
        }
    }

    public void VideoStop_Play()
    {
        if (stop_play.GetComponent<SpriteRenderer>().sprite == sprite[2])
        {
            videoPlayer.Stop();
            stop_play.GetComponent<SpriteRenderer>().sprite = sprite[1];
        }
        else
        {
            videoPlayer.Play();
            stop_play.GetComponent<SpriteRenderer>().sprite = sprite[2];
        }
    }

    public void AudioMute_On()
    {
        if (mute_on.GetComponent<SpriteRenderer>().sprite == sprite[3])
        {
            videoPlayer.SetDirectAudioMute(0, true);
            mute_on.GetComponent<SpriteRenderer>().sprite = sprite[4];
        }
        else
        {
            videoPlayer.SetDirectAudioMute(0, false);
            mute_on.GetComponent<SpriteRenderer>().sprite = sprite[3];
        }
    }

    public void Esc()
    {
        gameObject.SetActive(false);
    }
}
