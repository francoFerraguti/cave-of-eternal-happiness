using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;

    public GameObject camera;

    public bool hasSaidWallText = false;
    public bool hasSaidMeetsEye = false;
    float timerThanksBuddy = 0;
    float timeToThanksBuddy = 2.7f;


    public bool hasSaidGhostUseful = false;
    float timerGhostUseful = 0;
    float timeToVoiceGone = 2.2f;
    float timeToTextScreen = 2.5f;

    bool hasSaidNoCanFly = false;
    float timerNoCanFly = 0;
    float timeNoCanFly = 0.5f;
    float timeStupid = 1.4f;


    public bool hasSaidName = false;
    float timerHasSaidName = 0;
    float timeHonor = 2.3f;
    float timeMyNameIs = 4.4f;
    float timeMemories = 6.8f;
    float timeGoBack = 10f;
    float timeDreams = 12.5f;

    void Update()
    {
        if (hasSaidName)
        {
            timerHasSaidName += Time.deltaTime;

            if (timerHasSaidName >= timeHonor)
            {
                timeHonor = float.MaxValue;
                SetText("May I have the honor of knowing your name?", 2);
            }

            if (timerHasSaidName >= timeMyNameIs)
            {
                timeMyNameIs = float.MaxValue;
                SetText("My name is... My name is...", 3, 0.8f);
            }

            if (timerHasSaidName >= timeMemories)
            {
                timeMemories = float.MaxValue;
                SetText("You're even taking away my memories now, huh?", 4, 1.5f);
            }

            if (timerHasSaidName >= timeGoBack)
            {
                timeGoBack = float.MaxValue;
                SetText("You can still go back... Think about it", 1);
            }

            if (timerHasSaidName >= timeDreams)
            {
                timeDreams = float.MaxValue;
                SetText("In your dreams", 3, 0.8f);
                camera.GetComponent<MovementScript>().canMove = true;
                camera.GetComponent<MouseScript>().enabled = false;
            }
        }

        if (hasSaidNoCanFly)
        {
            timerNoCanFly += Time.deltaTime;

            if (timerNoCanFly >= timeNoCanFly)
            {
                timeNoCanFly = float.MaxValue;
                SetText("Great, now I can't even fly", 3, 0.9f);
            }

            if (timerNoCanFly >= timeStupid)
            {
                timeStupid = float.MaxValue;
                SetText("Stupid cave. To hell it is", 4, 0.8f);
            }
        }

        if (hasSaidGhostUseful)
        {
            timerGhostUseful += Time.deltaTime;

            if (timerGhostUseful >= timeToVoiceGone)
            {
                timerGhostUseful = 0;
                timeToVoiceGone = float.MaxValue;
                SetText("Weird, my voice is gone", 4, 1.2f);
            }

            if (timeToVoiceGone > 999 && timerGhostUseful >= timeToTextScreen)
            {
                timeToTextScreen = float.MaxValue;
                SetText("At least what I say keeps being printed onto the screen", 3, 1.8f);
                camera.GetComponent<MovementScript>().canMove = true;
            }
        }

        if (hasSaidMeetsEye)
        {
            timerThanksBuddy += Time.deltaTime;

            if (timerThanksBuddy >= timeToThanksBuddy)
            {
                timeToThanksBuddy = float.MaxValue;
                GameObject.Find("Main Camera").GetComponent<SoundManagerScript>().playTip();
                SetText("Thanks for the tip, buddy", 3, 0.7f);
            }
        }
    }

    public void SetText(string text, int n, float duration = 0)
    {
        if (n == 1)
        {
            text1.GetComponent<TextScript>().Show(text);
        }

        if (n == 2)
        {
            text2.GetComponent<TextScript>().Show(text);
        }

        if (n == 3)
        {
            text3.GetComponent<TextPlayerScript>().Show(text, duration);
        }

        if (n == 4)
        {
            text4.GetComponent<TextPlayerScript>().Show(text, duration);
        }
    }

    public void sayWallText()
    {
        hasSaidWallText = true;
        GameObject.Find("Main Camera").GetComponent<SoundManagerScript>().playGhostWalls();
        SetText("Aren't ghosts supposed to go through walls? This game sucks...", 3, 2.0f);
    }

    public void sayMeetsEye()
    {
        hasSaidMeetsEye = true;
        GameObject.Find("Main Camera").GetComponent<SoundManagerScript>().playMoreEye();
        SetText("There's more to this room than meets the eye", 1);
    }

    public void sayGhostUseful()
    {
        hasSaidGhostUseful = true;
        camera.GetComponent<MovementScript>().canMove = false;
        GameObject.Find("Main Camera").GetComponent<SoundManagerScript>().playGhostUseful();
        SetText("Being a ghost sure is useful", 3, 0.8f);
    }

    public void sayNoCanFly()
    {
        hasSaidNoCanFly = true;
    }

    public void sayName()
    {
        hasSaidName = true;
        camera.GetComponent<MovementScript>().canMove = false;
        SetText("Good job making it this far", 1);
    }
}
