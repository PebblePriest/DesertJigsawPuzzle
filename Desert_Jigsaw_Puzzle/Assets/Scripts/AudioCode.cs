using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCode : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip Lesson1clip;
    public AudioClip BiomeClip;

    public void PlayLesson1()
    {
        audioSource.clip = Lesson1clip;
        audioSource.Play();
    }

    public void PlayBiomeAudio()
    {
        audioSource.clip = BiomeClip;
        audioSource.Play();
    }
    public void StopAudio()
    {
        audioSource.Stop();
    }
    // Start is called before the first frame update
   
}
