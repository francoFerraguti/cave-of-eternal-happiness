using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    AudioSource source;

    public AudioClip wind;

    public AudioClip beware;
    public AudioClip cave;
    public AudioClip comeForth;
    public AudioClip ghostWalls;
    public AudioClip ghostUseful;
    public AudioClip kneel;
    public AudioClip moreEye;
    public AudioClip neat;
    public AudioClip tip;

    public AudioClip what;

    bool fading = false;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (fading)
        {
            source.volume -= 0.008f;
        }
    }

    public void playComeForth()
    {
        source.PlayOneShot(comeForth);
    }

    public void playCave()
    {
        source.PlayOneShot(cave);
    }
    public void playKneel()
    {
        source.PlayOneShot(kneel);
    }

    public void playBeware()
    {
        source.PlayOneShot(beware);
    }

    public void playWhat()
    {
        source.PlayOneShot(what);
    }

    public void playNeat()
    {
        source.PlayOneShot(neat);
    }

    public void playGhostWalls()
    {
        source.PlayOneShot(ghostWalls);
    }

    public void playMoreEye()
    {
        source.PlayOneShot(moreEye);
    }

    public void playTip()
    {
        source.PlayOneShot(tip);
    }

    public void playGhostUseful()
    {
        source.PlayOneShot(ghostUseful);
        fading = true;
    }

    public void playWind()
    {
        source.PlayOneShot(wind);
    }

}
