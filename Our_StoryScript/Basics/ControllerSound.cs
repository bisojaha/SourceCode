using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSound : MonoBehaviour
{
    public static ControllerSound instance;
    private void Awake()
    {
        instance = this;
    }

    public AudioClip[] audioClip;
    AudioSource audioSource;
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("1");
            BackSound();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("2");
            HoverSound();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("3");
            ButtonSound();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            print("4");
            MenuSound();
        }
    }

    public void BackSound()
    {
        PlaySound(audioClip[0], audioSource);
    }
    public void HoverSound()
    {
        PlaySound(audioClip[1], audioSource);
    }
    public void ButtonSound()
    {
        PlaySound(audioClip[2], audioSource);
    }
    public void MenuSound()
    {
        PlaySound(audioClip[3], audioSource);
    }

    void PlaySound(AudioClip clip, AudioSource audioPlayer)
    {
        // audioPlayer.Stop();
        // audioPlayer.time = 0;
        audioPlayer.clip = clip;
        audioPlayer.Play();
    }

}
