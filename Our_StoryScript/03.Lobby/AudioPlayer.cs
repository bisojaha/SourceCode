using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip[] audioList;
    AudioSource audioSource;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        StartCoroutine("AudioPlay");
    }

    IEnumerator AudioPlay()
    {
        audioSource.clip = audioList[0];
        audioSource.Play();
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            if (!audioSource.isPlaying)
            {
                for (int i = 0; i < audioList.Length; i++)
                {
                    audioSource.clip = audioList[i];
                }
            }
        }
    }
}
