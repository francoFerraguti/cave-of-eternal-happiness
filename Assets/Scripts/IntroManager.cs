using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{

    GameObject camera;
    GameObject textManager;

    float timer = 0;

    float time1 = 2.5f;
    float time2 = 6.5f;

    float timeIntroMoveForward = 7.0f;

    float time3 = 12.5f;

    float timeIntroKneel = 18.5f;

    float time4 = 20.5f;

    float timeDisableFire = 24.5f;

    float timeMoveAltar = 25.5f;

    float timeGuardianExit = 28.0f;

    void Awake()
    {
        textManager = GameObject.Find("TextManager");
        camera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log("Intro timer: " + timer.ToString());

        if (timer >= time1)
        {
            time1 = float.MaxValue;
            textManager.GetComponent<TextManager>().SetText("Come forth, traveller", 1);
        }

        if (timer >= time2)
        {
            time2 = float.MaxValue;
            textManager.GetComponent<TextManager>().SetText("You've reached the cave of eternal happiness", 2);
        }

        if (timer >= timeIntroMoveForward)
        {
            timeIntroMoveForward = float.MaxValue;
            camera.GetComponent<CameraScript>().SetIntroMoveForward();
        }

        if (timer >= time3)
        {
            time3 = float.MaxValue;
            textManager.GetComponent<TextManager>().SetText("Kneel before me if you wish to partake in this trial", 1);
        }

        if (timer >= timeIntroKneel)
        {
            timeIntroKneel = float.MaxValue;
            camera.GetComponent<CameraScript>().SetIntroKneeling();
        }

        if (timer >= time4)
        {
            time4 = float.MaxValue;
            textManager.GetComponent<TextManager>().SetText("But beware... You just might lose yourself along the way", 1);
        }

        if (timer >= timeDisableFire)
        {
            timeDisableFire = float.MaxValue;
            GameObject.Find("Fire").SetActive(false);
        }

        if (timer >= timeMoveAltar)
        {
            timeMoveAltar = float.MaxValue;
            GameObject.Find("altar").GetComponent<AltarScript>().SetMoving();
        }

        if (timer >= timeGuardianExit)
        {
            timeGuardianExit = float.MaxValue;
            GameObject.Find("guardian").GetComponent<GuardianScript>().SetExit();
        }
    }

}
