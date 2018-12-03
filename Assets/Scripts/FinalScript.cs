using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScript : MonoBehaviour
{
    public GameObject textEnd;
    public GameObject textCredits;

    float timer = 0;

    float time1 = 1.0f;
    float time2 = 7.0f;
    float time3 = 13.0f;

    float timeBirds = 19.0f;

    float timeUnblacken = 22.0f;

    float timeDad = 28.0f;

    float timeEnd = 32;

    float timeExit = 37;

    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;
    public GameObject cloud4;


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= time1)
        {
            time1 = float.MaxValue;
            GameObject.Find("Text").GetComponent<FinalTextScript>().Show("Why is everything so dark?");
        }

        if (timer >= time2)
        {
            time2 = float.MaxValue;
            GameObject.Find("Text").GetComponent<FinalTextScript>().Show("What is this place?");
        }

        if (timer >= time3)
        {
            time3 = float.MaxValue;
            GameObject.Find("Text").GetComponent<FinalTextScript>().Show("Who am I?");
        }

        if (timer >= timeBirds)
        {
            timeBirds = float.MaxValue;
            GetComponent<SoundManagerFinalScript>().playBirds();
        }

        if (timer >= timeDad)
        {
            timeDad = float.MaxValue;
            GetComponent<SoundManagerFinalScript>().playDad();
        }

        if (timer >= timeUnblacken)
        {
            timeUnblacken = float.MaxValue;
            cloud1.GetComponent<CloudScript>().moving = true;
            cloud2.GetComponent<CloudScript>().moving = true;
            cloud3.GetComponent<CloudScript>().moving = true;
            cloud4.GetComponent<CloudScript>().moving = true;

            GameObject.Find("Black").GetComponent<FinalBlackScript>().Unblacken();
        }

        if (timer >= timeEnd)
        {
            timeEnd = float.MaxValue;
            GameObject.Find("Black").GetComponent<FinalBlackScript>().Alpha1();
            textEnd.SetActive(true);
            textCredits.SetActive(true);
        }

        if (timer >= timeExit)
        {
            Application.Quit();
        }
    }
}
