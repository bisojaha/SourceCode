using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{
    public AudioSource audioSource;
    public RightHand rightHand;
    public VideoPlayer videoPlay;
    public GameObject videoButton;
    public Button puese_play;
    public Button stop_play;
    public Button mute_play;
    public Sprite[] sprite;

    void Update()
    {
        if (rightHand.onVideoButton == true)
            videoButton.SetActive(true);
        else videoButton.SetActive(false);

        if (videoPlay.isPlaying)
        {
            puese_play.gameObject.SetActive(true);
            puese_play.image.sprite = sprite[0];
            stop_play.image.sprite = sprite[2];
        }
        else
        {
            puese_play.image.sprite = sprite[1];
            stop_play.image.sprite = sprite[1];
            if(stop_play.image.sprite == sprite[1])
            { puese_play.gameObject.SetActive(false); }
        }
    }

    public void VideoPause_Play()
    {
        if (videoPlay.isPlaying)
        {
            videoPlay.Pause();
            audioSource.mute = false;
        }
        else
        {
            videoPlay.Play();
            audioSource.mute = true;
        }
    }

    public void VideoStop_Play()
    {
        if (videoPlay.isPlaying)
        {
            videoPlay.Stop();
            audioSource.mute = false;
        }
        else
        {
            videoPlay.Play();
            audioSource.mute = true;
        }
    }

    public void AudioMute_Play()
    {
        if (mute_play.image.sprite == sprite[3])
        {
            mute_play.image.sprite = sprite[4];
            videoPlay.SetDirectAudioMute(0, true);
        }
        else
        {
            mute_play.image.sprite = sprite[3];
            videoPlay.SetDirectAudioMute(0, false);
        }
    }
}
