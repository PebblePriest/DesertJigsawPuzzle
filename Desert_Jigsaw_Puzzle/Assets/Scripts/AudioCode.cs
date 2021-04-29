using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCode : MonoBehaviour
{

    public AudioSource audioSource;

    public AudioClip Lesson1clip;
    public AudioClip BiomeClip;
    public AudioClip Reminder;
    public AudioClip HumpClip;
    public AudioClip OasisClip;
    public AudioClip HabitatClip;
    public AudioClip AdaptClip;

    public bool stopAudio = false;
    public void PlayLesson1()
    {
        if(stopAudio == false)
        {
            audioSource.clip = Lesson1clip;
            audioSource.Play();
            stopAudio = true;
        }
        else
        {
            audioSource.Stop();
            stopAudio = false;
        }
        
    }

    public void PlayBiomeAudio()
    {
        if(stopAudio == false)
        {
            audioSource.clip = BiomeClip;
            audioSource.Play();
            stopAudio = true;
        }
        else
        {
            audioSource.Stop();
            stopAudio = false;

        }
    }
    public void StopAudio()
    {
        audioSource.Stop();
    }
    public void ReminderAudio()
    {
        audioSource.clip = Reminder;
        audioSource.Play();
    }
    public void PlayHumpAudio()
    {
        if (stopAudio == false)
        {
            audioSource.clip = HumpClip;
            audioSource.Play();
            stopAudio = true;
        }
        else
        {
            audioSource.Stop();
            stopAudio = false;

        }
    }
    public void PlayLesson2()
    {
        if (stopAudio == false)
        {
            audioSource.clip = OasisClip;
            audioSource.Play();
            stopAudio = true;
        }
        else
        {
            audioSource.Stop();
            stopAudio = false;

        }
    }
    public void PlayAdaptAudio()
    {
        if (stopAudio == false)
        {
            audioSource.clip = AdaptClip;
            audioSource.Play();
            stopAudio = true;
        }
        else
        {
            audioSource.Stop();
            stopAudio = false;

        }
    }
    public void PlayHabitatAudio()
    {
        if (stopAudio == false)
        {
            audioSource.clip = HabitatClip;
            audioSource.Play();
            stopAudio = true;
        }
        else
        {
            audioSource.Stop();
            stopAudio = false;

        }
    }
   
    // Start is called before the first frame update
   
}
