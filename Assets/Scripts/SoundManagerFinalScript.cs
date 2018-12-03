using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerFinalScript : MonoBehaviour
{
    AudioSource source;

    public AudioClip birds;

    public AudioClip dad;
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    public void playBirds()
    {
        source.PlayOneShot(birds);
    }

    public void playDad()
    {
        source.PlayOneShot(dad);
    }
}
